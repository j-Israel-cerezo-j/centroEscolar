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
using CapaLogicaNegocio.MessageErrors;
using CapaLogicaNegocio.Onkeyups;
using CapaLogicaNegocio.Insert;
using CapaDatos.Exceptions;
using CapaLogicaNegocio.tablesInner;
using CapaLogicaNegocio.Selects;
using System.Web.UI.WebControls;

namespace CapaLogicaNegocio
{
    public class GroupService
    {
        private Delete delete = new Delete();
        private AddGroup addGroup=new AddGroup();
        private ListGroups listGroups = new ListGroups();
        private ListCarrers listCarrers = new ListCarrers();
        private RecoverDataGroups recoverDatesGroups = new RecoverDataGroups();
        private UpdateGroup updateGroups = new UpdateGroup();
        private DeleteGroup deleteGroups = new DeleteGroup();
        private TableGroup tableGroup = new TableGroup();
        public bool add(Dictionary<string, string> submit)
        {
            bool ban = false;

            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                try
                {
                    var camposWhere = new Dictionary<string, string>();
                    Group group = new Group();
                    group.nombre = RetrieveAtributes.values(submit, "grupo");

                    camposWhere.Add("nombre", group.nombre);
                    string strNumStudent = RetrieveAtributes.values(submit, "numAlum");
                    string strChecksCarrers = RetrieveAtributes.values(submit, "checksCarrers");

                    validatenNumberOfStudentsException(strNumStudent);
                    validatenCarrersOfGroupException(strChecksCarrers);

                    var groupDuplicate=validateDuplicateAddInTableGroup(camposWhere,"Nombre del grupo ya agregado","grupos",strChecksCarrers, strNumStudent);
                    if (groupDuplicate)
                    {
                        bool duplicateCombination=validateDuplicityOfCombinationOfRacesWithGroup(camposWhere, "Nombre del grupo ya agregado", "grupos", strChecksCarrers, strNumStudent);
                        if (!duplicateCombination)
                        {
                            var idExistingGroup = Select.findFieldWhere("idGrupo", "grupos", camposWhere.Keys.FirstOrDefault(), camposWhere.Values.FirstOrDefault());
                            addGroupCarrers(strChecksCarrers, Convert.ToInt32(idExistingGroup), strNumStudent);
                            ban = true;
                        }
                        else
                        {
                            throw new ServiceException("Grupo ya agregado");
                        }
                    }
                    else
                    {
                        int IdRetrievedGroup = addGroup.add(group);
                        if (IdRetrievedGroup != 0)
                        {
                            addGroupCarrers(strChecksCarrers, IdRetrievedGroup, strNumStudent);
                            ban = true;
                        }
                        else
                        {
                            throw new ServiceException(MessageError.failedToAddToGroup);
                        }
                    }
                }
                catch (ServiceException se)
                {
                    throw new ServiceException(se.getMessage());
                }
                catch(DaoException de)
                {
                    throw new ServiceException(de.getMessage() + MessageError.failedToAddToGroup);
                }
            }
            else
            {
                foreach (var item in camposEmptysOrNull)
                {
                    if (item.Value)
                    {
                        throw new ServiceException(item.Key + " esta vacío");
                    }
                }
            }
            return ban;
        }
        private void addGroupCarrers(string strChecksCarrers,int IdRetrievedGroup,string strNumStudent)
        {           
            try
            {
                var listCarrers = Converter.ToList(strChecksCarrers);
                var campos = new Dictionary<object, List<object>>();
                campos.Add(IdRetrievedGroup, listCarrers);
                List<object> extraFields = new List<object>();
                extraFields.Add(strNumStudent);
                var exito= Inserts.Many(campos, "gruposCarreas", extraFields);
                if (!exito)
                {
                    throw new ServiceException(MessageError.failedToAddToGroup);
                }
            }catch(DaoException e)
            {
                throw new ServiceException(e.getMessage()+ MessageError.failedToAddToGroup);
            }
        }
        private void rollbackGrupoInsert(int IdRetrievedGroup)
        {
            delete.deleteWhere("grupos", "idGrupo", IdRetrievedGroup.ToString());
        }
        private void validatenNumberOfStudentsException(string strNumStudent)
        {           
            if (!Validation.numericalFormat(strNumStudent))
            {
                throw new ServiceException(MessageError.incorrectFormatNumber);
            }
        }
        private void validatenCarrersOfGroupException(string strChecksCarrers)
        {
            if (!Validation.FormantCheck(strChecksCarrers))
            {
                throw new ServiceException(MessageError.carrersNotSelected);
            }
        }
        public string jsonRecoverData(string strId)
        {
            string jsonRecoerDtes = "";
            if (strId != "")
            {
                var groups = new List<Group>();
                groups.Add(recoverDatesGroups.recoverData(Convert.ToInt32(strId)));
                jsonRecoerDtes = Converter.ToJson(groups);
            }
            return jsonRecoerDtes;
        }
        public string jsonGroups()
        {
            return Converter.ToJson(tableGroup.tableGroupss(), "id").ToString();
        }
        public bool updateGroup(Dictionary<string, string> submit, string strId)
        {
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            bool ban = false;
            if (camposEmptysOrNull.Count == 0)
            {
                Group group = new Group();
                group.idGrupo = Convert.ToInt32(strId);
                group.nombre = RetrieveAtributes.values(submit, "grupo");
                return updateGroups.update(group);
            }
            else
            {
                foreach (var item in camposEmptysOrNull)
                {
                    if (item.Value)
                    {
                        throw new ServiceException(item.Key + " esta vacío");
                    }
                }
            }
            return ban;
        }
        public bool deleteG(string strIds)
        {
            return deleteGroups.delete(strIds);
        }
        public List<string> onkeyupSearch(string caracteres)
        {
            var fields = new Dictionary<string, string>();
            fields.Add("nombre", caracteres);            
            var table = Onkeyup.onkeyubSearchh(fields, "grupos");
            return Converter.ToList(table);

        }
        public StringBuilder onkeyupSearchTable(string caracteres)
        {
            var fields = new Dictionary<string, string>();
            fields.Add("nombre", caracteres);
            fields.Add("idGrupo", caracteres);

            var table = Onkeyup.onkeyubSearchhTable(fields, "grupos");
            return Converter.ToJson(table, "idGrupo", "id");

        }
        public List<Carrer> listCarrersG()
        {
            return listCarrers.listarCarres();
        }
        private bool validateDuplicateAddInTableGroup(Dictionary<string, string> camposWhere,string msjExeception,string table,string strCarrers,string strNumStudent)
        {
            //Si delvuelbe renglones significa que el grupo ya existe en la tabla grupos
            var fields = Select.findFromAll(table, camposWhere);
            return fields.Rows.Count >= 1;
        }
        private bool validateDuplicityOfCombinationOfRacesWithGroup(Dictionary<string, string> camposWhere, string msjExeception, string table, string strCarrers, string strNumStudent)
        {
            bool ban=false;
            var idExistingGroup = Select.findFieldWhere("idGrupo", table, camposWhere.Keys.FirstOrDefault(), camposWhere.Values.FirstOrDefault());
            //Si es false, significa que no existe duplicidad de las carreras y el grupo en la tabla gruposCarreras
            var fieldDuplicate = validateDuplicateFieldsGroupCarrer(idExistingGroup.ToString(), strCarrers);
            if (fieldDuplicate)
            {
                throw new ServiceException("Grupo ya asignado a las carrera(s) seleccionada(s)");
            }
            return ban;
        }
        private bool validateDuplicateFieldsGroupCarrer(string strIdGroup, string strCarrers)
        {
            bool ban = false;
            var listPrivileges = Converter.ToList(strCarrers);
            var camposWhere = new Dictionary<string, string>();
            foreach (var item in listPrivileges)
            {
                camposWhere.Add("fkCarrea", item.ToString());
                camposWhere.Add("fkGrupo", strIdGroup);
                var fields = Select.findFromAll("gruposCarreas", camposWhere);
                if (fields.Rows.Count >= 1)
                {
                    throw new ServiceException("Grupo ya asignado a carrera(s) seleccionada(s)");
                }
                camposWhere.Clear();
            }
            return ban;
        }
    }
}
