using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogicaNegocio.Adds;
using Entidades;
using CapaLogicaNegocio.retrieveAtributesValues;
using CapaLogicaNegocio.Lists;
using CapaLogicaNegocio.utils;
using CapaLogicaNegocio.recoverDates;
using CapaLogicaNegocio.deletes;
using CapaLogicaNegocio.updates;
using Validaciones.util;
using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.tablesInner;
using System.Data;
using CapaLogicaNegocio.MessageErrors;
using CapaLogicaNegocio.Insert;
using System.Web;
using CapaLogicaNegocio.validateDuplicateField;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaLogicaNegocio.Selects;

namespace CapaLogicaNegocio
{
    public class EmployeService : UserService
    {
        private TableEmployes tablesEmployes = new TableEmployes();
        private AddDomicilie addDomicilie = new AddDomicilie();
        private ListTypesWorkers listTW = new ListTypesWorkers();
        private AddEmploye addEmploys = new AddEmploye();
        private ListCarrers listCarr = new ListCarrers();
        private ListDivisions listDivisionsO = new ListDivisions();
        private ListEmployes listsEmployes = new ListEmployes();
        private RecoverDataEmploye recoverDataEmploye= new RecoverDataEmploye();
        private RecoverDataDomicilie recoverDataAddress = new RecoverDataDomicilie();
        private ApiMexico apiMexico=new ApiMexico();
        private UpdateEmploye updateEmployeO= new UpdateEmploye();
        private Delete delete=new Delete();
        private UpdateStatusUser updateStatusUser = new UpdateStatusUser();
        public bool addEmploye(Dictionary<string, string> request, HttpPostedFile file)
        {
            bool exito = false;
            string typeWorker = validateTypeWorker(request);
            string strRoles = validateRoles(request);
            if (typeWorker == "Divisional")
            {
                
                exito = buildAndAddEmployeLocal(request, strRoles, file);

            }
            else if (typeWorker == "General")
            {
                exito = buildAndAddEmployeGeneral(request, strRoles, file);
            }
            return exito;
        }
        public bool updateEmploye(Dictionary<string, string> request,string strId, HttpPostedFile file)
        {
            bool exito = false;
            string typeWorker = validateTypeWorker(request);
            string strRoles = validateRoles(request);
            string antTypeWorker = RetrieveAtributes.values(request, "antTypeWorker");
            if (antTypeWorker== typeWorker)
            {
                if (typeWorker == "Divisional")
                {                    
                    exito = buildAndUpdateEmployeLocal(request, strRoles, strId, file);

                }
                else if (typeWorker == "General")
                {
                    exito = buildAndUpdateEmployeGeneral(request, strRoles, strId, file);
                }
            }
            else
            {
                throw new ServiceException("No puedes cambiar el tipo de trabajador a la hora de actualizar");
            }
            return exito;
        }
        private bool buildAndAddEmployeGeneral(Dictionary<string, string> request, string strRoles, HttpPostedFile file)
        {
            bool exito = false;
            User user = getUserDataFromRequest(request);
            if (user != null)
            {
                var generalEmploye = buildUser(user, new GeneralEmploye());
                generalEmploye.fkAddress = buildAndAddAddress(request);
                generalEmploye.fkStatusUser = "desbloqueado";
                generalEmploye.image=saveImageUser(file, "employeGeneral");
                generalEmploye.fileName = file.FileName;
                int idUserRecuperado = addEmploys.add(generalEmploye);
                if (idUserRecuperado != 0)
                {
                    var campos = buildCamposToDictionary(strRoles, idUserRecuperado);
                    exito = Inserts.Many(campos, "rolTrabajadorGenereal");
                }
                else
                {
                    rollbackAddress(generalEmploye.fkAddress, idUserRecuperado);
                    rollbackFile(idUserRecuperado, "employeGeneral", generalEmploye.fileName);
                    throw new ServiceException(MessageError.errorAddUser);
                }
               
            }
            return exito;
        }
        private Dictionary<object, List<object>> buildCamposToDictionary(string strValues,int id)
        {
            var valuesList = Converter.ToList(strValues);
            var campos = new Dictionary<object, List<object>>();
            campos.Add(id, valuesList);
            return campos;
        }
        private bool buildAndUpdateEmployeGeneral(Dictionary<string, string> request, string strRoles, string strId,HttpPostedFile file)
        {
            bool exito = false;
            User user = getUserDataFromRequestForUpdate(request, "tabajadorGeneral", strId);
            if (user != null)
            {
                var generalEmploye = buildUser(user, new GeneralEmploye());
                generalEmploye.id = Convert.ToInt32(strId);
                validateDateOfBith(request);
                generalEmploye.fechaNac = Convert.ToDateTime(RetrieveAtributes.values(request, "fechaNac"));
                generalEmploye.curp = RetrieveAtributes.values(request, "curp");
                generalEmploye.fileName = defineTheSourceOfTheFileName(file,"fileName", "tabajadorGeneral", "id", generalEmploye.id.ToString());               
                generalEmploye.image = defineImagePath(request, file, "employeGeneral");              
                bool exitoUpdate = updateEmployeO.update(generalEmploye);
                if (exitoUpdate)
                {
                    var campos = buildCamposToDictionary(strRoles, generalEmploye.id);
                    bool deleteExitoRoles = delete.deleteWhere("rolTrabajadorGenereal", "fkIdTrabajador", generalEmploye.id.ToString());
                    if (deleteExitoRoles)
                    {
                        exito = Inserts.Many(campos, "rolTrabajadorGenereal");
                    }
                }
            }
            return exito;
        }
        private bool buildAndUpdateEmployeLocal(Dictionary<string, string> request, string strRoles,string strId,HttpPostedFile file)
        {
            bool exito = false;
            User user = getUserDataFromRequestForUpdate(request, "tabajadorLocal", strId);
            if (user != null)
            {
                validateChecksDivisions(request);
                var localEmploye = buildLocalEmploye(user);
                localEmploye.id = Convert.ToInt32(strId);
                validateDateOfBith(request);
                localEmploye.curp = RetrieveAtributes.values(request, "curp");
                localEmploye.fechaNac =Convert.ToDateTime(RetrieveAtributes.values(request, "fechaNac"));
                localEmploye.image = defineImagePath(request, file, "employeLocal");
                localEmploye.fileName = defineTheSourceOfTheFileName(file, "fileName", "employeLocal", "id", localEmploye.id.ToString());
                bool exitoUpdate=updateEmployeO.update(localEmploye);
                if (exitoUpdate)
                {
                    var campos = buildCamposToDictionary(strRoles, localEmploye.id);
                    bool deleteExitoRoles = delete.deleteWhere("rolTrabajadorLocal", "fkIdTrabajador", localEmploye.id.ToString());
                    if (deleteExitoRoles)
                    {
                        exito = Inserts.Many(campos, "rolTrabajadorLocal");
                        if (exito)
                        {
                            bool deleteExitoDivisions = delete.deleteWhere("divisionTrabajadorLocal", "fkIdTrabajador", localEmploye.id.ToString());
                            if (deleteExitoDivisions)
                            {
                                addDivisionsTheEmploye(request, localEmploye.id);
                            }
                        }
                    }                   
                }
            }
            return exito;
        }
        private bool buildAndAddEmployeLocal(Dictionary<string, string> request,string strRoles,HttpPostedFile file)
        {
            bool exito = false;
            User user = getUserDataFromRequest(request);
            if (user != null)
            {
                validateChecksDivisions(request);
                var localEmploye = buildLocalEmploye(user);
                localEmploye.fkAddress = buildAndAddAddress(request);
                localEmploye.fkStatusUser = "desbloqueado";
                localEmploye.image = saveImageUser(file, "employeLocal");
                localEmploye.fileName = file.FileName;
                int idUserRecuperado = addEmploys.add(localEmploye);                
                if (idUserRecuperado != 0)
                {
                    var campos = buildCamposToDictionary(strRoles, idUserRecuperado);
                    exito = Inserts.Many(campos, "rolTrabajadorLocal");
                    if (exito)
                    {
                        addDivisionsTheEmploye(request, idUserRecuperado);
                    }
                }
                else
                {
                    rollbackAddress(localEmploye.fkAddress, idUserRecuperado);
                    rollbackFile(idUserRecuperado, "employeLocal", localEmploye.fileName);
                    throw new ServiceException(MessageError.errorAddUser);

                }               
            }
            return exito;
        }
        
        private void addDivisionsTheEmploye(Dictionary<string, string> request, int idEmploye)
        {
            try
            {
                string strDivisions = retriveDivisionsByRequest(request);
                var listDivisions=Converter.ToList(strDivisions);
                var campos = new Dictionary<List<object>, object>();
                campos.Add(listDivisions,idEmploye);
                Inserts.Many(campos, "divisionTrabajadorLocal");
            }
            catch (ServiceException e)
            {
                throw new ServiceException("Error en el servidor");
            }
        }
        private string validateTypeWorker(Dictionary<string, string> request)
        {
            string typeWorker = RetrieveAtributes.values(request, "typeWorker");
            if (typeWorker == "" || typeWorker == null)
            {
                throw new ServiceException(MessageError.incorrectFormatInTypeWorker);
            }
            return typeWorker;
        }
        private string validateRoles(Dictionary<string, string> request)
        {
            string strRolesSelecionados = RetrieveAtributes.values(request, "cheksRolesSelec");
            if(strRolesSelecionados=="" || strRolesSelecionados == null)
            {
                throw new ServiceException(MessageError.incorrectFormatInRol);
            }
            return strRolesSelecionados;
        }
        private LocalEmploye buildLocalEmploye(User user)
        {            
            LocalEmploye localEmploye = buildUser(user, new LocalEmploye());
            return localEmploye;
        }
        private string retriveDivisionsByRequest(Dictionary<string, string> request)
        {
           return RetrieveAtributes.values(request, "cheksDivisionsSelec");
        }
        private int buildAndAddAddress(Dictionary<string, string> request)
        {
            Domicilie domicilie = getDomicilieDataFromRequest(request);
            return addDomicilie.addAddres(domicilie);            
        }
        //private bool buildAndUpdateAddress(Dictionary<string, string> request)
        //{
        //    Domicilie domicilie = getDomicilieDataFromRequest(request);
        //    domicilie.idDomicilio =
        //                        Convert.ToInt32(
        //                            RetrieveAtributesValues.retrieveAtributesValues(request,"idDomicilie"));
        //    return updateAddress.update(domicilie);
        //}
        public List<TypeWorker> listTypesWorker()
        {
            return listTW.listar();
        }
        public List<Carrer> listCarrers()
        {
            return listCarr.listarCarres();
        }
        public List<Division> listDivisions()
        {
            return listDivisionsO.listarDivisions();
        }
        public bool existingRecordsFullEmployes()
        {
            var employesDivisions=listsEmployes.lisstEmployesLocals();
            var employesGeneral=listsEmployes.lisstEmployesGenerales();
            return !(employesDivisions.Count > 0 && employesGeneral.Count > 0);
        }
        private string jsonTableEmployesLocales()
        {
            DataTable table = tablesEmployes.tableEmployesLocales();
            return Converter.ToJson(table,"id").ToString();
        }
        private string jsonTableEmployesGnerales()
        {
            DataTable table = tablesEmployes.tableEmployesGnerales();
            return Converter.ToJson(table,"id").ToString();
        }
       
        public string buildTableEmployeByTypeWorker(string strIdTypeWorker)
        {
            string jsonRecoerDtes = "";
            if (strIdTypeWorker == "Divisional")
            {
                jsonRecoerDtes = jsonTableEmployesLocales();
            }
            else if (strIdTypeWorker == "General")
            {
                jsonRecoerDtes = jsonTableEmployesGnerales();
            }
            return jsonRecoerDtes;
        }
        //public string jsonFullEmployes()
        //{
        //    string jsonEmployesLocales = jsonTableEmployesLocales();
        //    jsonEmployesLocales = jsonEmployesLocales.Remove(0,1);
        //    jsonEmployesLocales = jsonEmployesLocales.Substring(0, jsonEmployesLocales.Length - 1);

        //    string jsonEmployesGenerales = jsonTableEmployesGnerales();
        //    jsonEmployesGenerales= jsonEmployesGenerales.Remove(0,1);
        //    jsonEmployesGenerales = jsonEmployesGenerales.Substring(0, jsonEmployesGenerales.Length - 1);

        //    string fullEmployes="["+ jsonEmployesLocales+","+jsonEmployesGenerales+"]";
        //    return fullEmployes;
        //}
        public string jsonRecoverDataEmployeById(string strIdEmploye, string strIdTypeWorker)
        {
            
            string jsonRecoerDtes = "";
            if (strIdTypeWorker == "Divisional")
            {
                var datasStudent = tablesEmployes.tableEmployeLocaleByIdEmploye(Convert.ToInt32(strIdEmploye));
                jsonRecoerDtes = Converter.ToJson(datasStudent).ToString();
            }
            else if (strIdTypeWorker == "General")
            {
                var datasStudent = tablesEmployes.tableEmployeGenerealByIdEmploye(Convert.ToInt32(strIdEmploye));
                jsonRecoerDtes = Converter.ToJson(datasStudent).ToString();
            }
            return jsonRecoerDtes;
        }
        public string jsonRolesSelecctedByEmploye(string strIdEmploye, string strIdTypeWorker)
        {
            var camposWhere = new Dictionary<string, string>();
            var datasRoles = new DataTable();

            if (strIdTypeWorker == "Divisional")
            {                
                camposWhere.Add("fkIdTrabajador", strIdEmploye);
                datasRoles = recoverDataEmploye.finFromAllWhere(camposWhere, "rolTrabajadorLocal");
            }
            else if (strIdTypeWorker == "General")
            {
                camposWhere.Add("fkIdTrabajador", strIdEmploye);
                datasRoles = recoverDataEmploye.finFromAllWhere(camposWhere, "rolTrabajadorGenereal");
            }
            return  Converter.ToJson(datasRoles).ToString(); ;
        }
        public string jsonDivisionsSelecctedByEmploye(string strIdEmploye)
        {            

            var camposWhere = new Dictionary<string, string>();
            camposWhere.Add("fkIdTrabajador", strIdEmploye);
            var datasStudent = recoverDataEmploye.finFromAllWhere(camposWhere, "divisionTrabajadorLocal");
            return Converter.ToJson(datasStudent).ToString();
        }
        public string jsonMinicipesByStateEmploye(string strIdEmploye,string strIdTypeWorker)
        {
            var camposWhere = new Dictionary<string, string>();
            var datasEmploye = new DataTable();
            if (strIdTypeWorker == "Divisional")
            {
                camposWhere.Add("id", strIdEmploye);
                datasEmploye = recoverDataEmploye.finFromAllWhere(camposWhere, "tabajadorLocal");
            }
            else if (strIdTypeWorker == "General")
            {
                camposWhere.Add("id", strIdEmploye);
                datasEmploye = recoverDataEmploye.finFromAllWhere(camposWhere, "tabajadorGeneral");
            }

            if (datasEmploye == null)
            {
                throw new ServiceException(MessageError.nonexistentUser);
            }
            else
            {
                string foundField = SearchBy.field(datasEmploye, "fkAddress");
                if (foundField=="")
                {
                    throw new ServiceException(MessageError.nonexistentField());
                }
                else
                {
                    Domicilie domicilie = recoverDataAddress.recoverDataAddress(Convert.ToInt32(foundField));
                    if (domicilie == null)
                    {
                        throw new ServiceException(MessageError.nonexistentAddress);
                    }
                    else
                    {
                        return apiMexico.recoverDatas("municipios", domicilie.estado);
                    }
                }               
            }
        }
        private void validateChecksDivisions(Dictionary<string, string> request)
        {
           string strDivisions= RetrieveAtributes.values(request, "cheksDivisionsSelec");
            if (strDivisions == "" || strDivisions == null)
            {
                throw new ServiceException(MessageError.divisionsNotSelected);
            }
        }

        public bool deleteEmployes(string strIdTypeWorker, string recordIds,User userLoggedIn)
        {
            bool deleteSuccess=false;
            var idsList = Converter.ToList(recordIds);
            if (idsList.Contains(userLoggedIn.id.ToString()))
            {
                if (idsList.Count > 1)
                {
                    throw new ServiceException("No se puede eliminar al usuario logueado, con matricula: " + userLoggedIn.matricula+
                        " .Deseleaccionar a este usuario para poder eliminar a los demas usuarios seleccionado.");
                }
                else
                {
                    throw new ServiceException("No se puede eliminar al usuario logueado, con matricula: " + userLoggedIn.matricula);
                }
                
            }
            else
            {
                if (recordIds == "")
                {
                    throw new ServiceException("Seleccione algún registro para eliminar");
                }
                else if (!Validation.Select(strIdTypeWorker))
                {
                    throw new ServiceException("Seleccione un tipo de trabajador en ¡mostrar tabla de! para eliminar");
                }
                else
                {
                    if (strIdTypeWorker == "Divisional")
                    {
                        bool deleteExitoDivisions = delete.whereIn("divisionTrabajadorLocal", "fkIdTrabajador", recordIds);
                        buildExceptionInDelete(deleteExitoDivisions);

                        retiveFileNamesUsersAndDeleteFiles("employeLocal", "fileName", "tabajadorLocal", "id", recordIds);
                        bool deleteRolesEmploye = delete.whereIn("rolTrabajadorLocal", "fkIdTrabajador", recordIds);
                        buildExceptionInDelete(deleteRolesEmploye);
                        var idsAddressesByEmploye = Select.findFieldsWhereIn("fkAddress", "tabajadorLocal", "id", recordIds);
                        deleteSuccess = delete.whereIn("addresses", "idDomicilio", Converter.ToString(idsAddressesByEmploye).ToString());
                        buildExceptionInDelete(deleteSuccess);
                    }
                    else if (strIdTypeWorker == "General")
                    {
                        retiveFileNamesUsersAndDeleteFiles("employeGeneral", "fileName", "tabajadorGeneral", "id", recordIds);
                        bool deleteRolesEmploye = delete.whereIn("rolTrabajadorGenereal", "fkIdTrabajador", recordIds);
                        buildExceptionInDelete(deleteRolesEmploye);
                        var idsAddressesByEmploye = Select.findFieldsWhereIn("fkAddress", "tabajadorGeneral", "id", recordIds);
                        deleteSuccess = delete.whereIn("addresses", "idDomicilio", Converter.ToString(idsAddressesByEmploye).ToString());
                        buildExceptionInDelete(deleteSuccess);
                    }
                }
            }           
            return deleteSuccess;
        }
        private void buildExceptionInDelete(bool result)
        {
            if (!result)
            {
                throw new ServiceException("Ha ocurrido un error a la hora de eliminar");
            }
        }
        public List<string> onkeyupSearch(string caracteres,Dictionary<string,string> request)
        {
            var table = new DataTable();
            string strTypeWorker = RetrieveAtributes.values(request, "typeWorkerSlc");
            if(Validation.Select(strTypeWorker))
            {
                caracteres = "%" + caracteres + "%";
                table = tablesEmployes.tableEmployesBymatchingCharacters(caracteres, strTypeWorker);
            }
            else
            {
                throw new ServiceException("Tipo de trabajador no seleccionado");
            }
         
            return Converter.ToList(table);
        }
        public StringBuilder onkeyupSearchTable(string caracteres,Dictionary<string,string> request)
        {
            var table = new DataTable();
            string strTypeWorker = RetrieveAtributes.values(request, "typeWorkerSlc");
            if (strTypeWorker != "")
            {
                caracteres = "%" + caracteres + "%";
                table = tablesEmployes.tableEmployesBymatchingCharacters(caracteres, strTypeWorker);
            }
            else
            {
                throw new ServiceException("Tipo de trabajador no seleccionado");
            }
            return Converter.ToJson(table,"id");
        }
        public bool updateStatus(string fkStatus, string idEmploye,string strIdTypeWorker,User userLoggedIn)
        {
            bool exito = false;
            if (userLoggedIn.id.ToString()==idEmploye)
            {
                throw new ServiceException("No se puede cambiar el estatus de la persona logueada");
            }
            else
            {
                if (strIdTypeWorker == "Divisional")
                {
                    exito = updateStatusUser.updateStatusUsers("tabajadorLocal", "id", fkStatus, "fkStatusUser", idEmploye);
                }
                else if (strIdTypeWorker == "General")
                {
                    exito = updateStatusUser.updateStatusUsers("tabajadorGeneral", "id", fkStatus, "fkStatusUser", idEmploye);
                }               
            }           
            return exito;
        }
    }
}
