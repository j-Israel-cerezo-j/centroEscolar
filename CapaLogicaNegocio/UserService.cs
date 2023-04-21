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
using CapaLogicaNegocio.encryptPassword;
using Newtonsoft.Json;
using CapaLogicaNegocio.validateDuplicateField;
using Validaciones.util;
using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.tablesInner;
using CapaLogicaNegocio.MessageErrors;
using CapaLogicaNegocio.Session;
using CapaLogicaNegocio.Selects;
using System.Web;
using System.Windows.Forms;
using System.IO;
using CapaDatos.Exceptions;
using System.Threading;
using System.Web.UI.WebControls;


namespace CapaLogicaNegocio
{
    public class UserService
    {
        private List<string> tablesUsers = new List<string>() { "tabajadorLocal", "tabajadorGeneral", "studentsCantidant", "alumnos" };
        private UpdateAddress updateAddress = new UpdateAddress();
        private Sessions session = new Sessions();
        private TableEmployes tableEmployes = new TableEmployes();
        private ListStatusUsers listStatusUser = new ListStatusUsers();
        private Delete delete = new Delete();
        protected User getUserDataFromRequest(Dictionary<string, string> submit)
        {
            User user=null;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {

                validateRulesAttibutres_Tel_EmailP_EDO_MUN_CP(submit);
                validateDateOfBith(submit);                
                user = retriveAttributesDataPerson(submit);
                validateCurpUsersExisting(user.curp);
                validatePersonalEmailUserExisting(user.correoP);
            }
            else
            {
                foreach (var item in camposEmptysOrNull)
                {
                    if (item.Value)
                    {
                        throw new ServiceException("El campo " + item.Key + " esta vacío");
                    }
                }
            }
            return user;
        }
        protected void validateCurpUsersExisting(string curp)
        {
            
            var existsCurp= DuplicateField.duplicate("curp", curp, tablesUsers[0]);
            var existsCurp2= DuplicateField.duplicate("curp", curp, tablesUsers[1]);
            var existsCurp3= DuplicateField.duplicate("curp", curp, tablesUsers[2]);
            var existsCurp4 = DuplicateField.duplicate("curp", curp, tablesUsers[3]);
            if (existsCurp || existsCurp2 || existsCurp3 || existsCurp4)
            {
                throw new ServiceException(MessageError.curpAlreadyExisting);
            }
        }
        protected void validatePersonalEmailUserExisting(string correoP)
        {
            var existsEmail = DuplicateField.duplicate("correoP", correoP, tablesUsers[0]);
            var existsEmail2 = DuplicateField.duplicate("correoP",  correoP, tablesUsers[1]);
            var existsEmail3 = DuplicateField.duplicate("correoP",  correoP, tablesUsers[2]);
            var existsEmail4 = DuplicateField.duplicate("correoP",  correoP, tablesUsers[3]);
            if (existsEmail || existsEmail2 || existsEmail3 || existsEmail4)
            {
                throw new ServiceException(MessageError.existingEmail);
            }
        }
        protected Domicilie getDomicilieDataFromRequest(Dictionary<string, string> submit)
        {
            return retriveAttributesDomicilies(submit);
        }
        protected User getUserDataFromRequestForUpdate(Dictionary<string, string> submit, string table,string strIdUser)
        {
            User user = null;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {

                validateRulesAttibutres_Tel_EmailP_EDO_MUN_CP(submit);
                user = retriveAttributesDataPersonForUpdate(submit);
                user.id = Convert.ToInt32(strIdUser);
                validateDuplicateEmailiISpecificTable(user, table);               
                Domicilie domicilie = retriveAttributesDomicilies(submit);
                domicilie.idDomicilio = Convert.ToInt32(
                                                    RetrieveAtributes.values(submit, "idDomicilie"));
                updateAddress.update(domicilie);
            }
            else
            {
                foreach (var item in camposEmptysOrNull)
                {
                    if (item.Value)
                    {
                        throw new ServiceException("El campo " + item.Key + " esta vacío");
                    }
                }
            }
            return user;
        }
        private Domicilie retriveAttributesDomicilies(Dictionary<string, string> submit)
        {
            Domicilie domicilie = new Domicilie();
            domicilie.calle = RetrieveAtributes.values(submit, "nomcalle");
            domicilie.noInterior = RetrieveAtributes.values(submit, "noInterior");
            domicilie.noExterior = RetrieveAtributes.values(submit, "noExterior");
            domicilie.estado = RetrieveAtributes.values(submit, "state");
            domicilie.municipio = RetrieveAtributes.values(submit, "municipio");
            domicilie.cp = RetrieveAtributes.values(submit, "cp");
            domicilie.colonia = RetrieveAtributes.values(submit, "colonia");           
            return domicilie;
        }

        protected T buildUser<T> (User user, T userChildInstance) where T : User
        {

            userChildInstance.matricula = user.matricula;
            userChildInstance.nombres = user.nombres;
            userChildInstance.apellidoP = user.apellidoP;
            userChildInstance.apellidoM = user.apellidoM;
            userChildInstance.curp = user.curp;
            userChildInstance.pass = user.pass;
            userChildInstance.correoIns = user.correoIns;
            userChildInstance.correoP = user.correoP;
            userChildInstance.telefono = user.telefono;
            userChildInstance.fechaNac = user.fechaNac;
            userChildInstance.fkAddress = user.fkAddress;
            return userChildInstance;
        }      
        private User retriveAttributesDataPerson(Dictionary<string, string> submit)
        {
            //fechaNac
            User user = new User();
            user.nombres = RetrieveAtributes.values(submit, "nombres");
            user.apellidoP = RetrieveAtributes.values(submit, "apellidoP");
            user.apellidoM = RetrieveAtributes.values(submit, "apellidoM");
            user.curp = RetrieveAtributes.values(submit, "curp");
            user.matricula = UserUtils.GenerateMatricula(user.curp);
            user.correoIns = UserUtils.GenerateInstitutionalEmail(user.matricula);
            user.fechaNac = Convert.ToDateTime(
                                        RetrieveAtributes.values(submit, "fechaNac"));
            user.pass =EncryptPassword.GetMD5(UserUtils.GeneratePasswordUser(user.fechaNac));            
            user.telefono = RetrieveAtributes.values(submit, "tel");
            user.correoP = RetrieveAtributes.values(submit, "email");
            return user;
        }
        protected void validateDateOfBith(Dictionary<string, string> request)
        {
            string strDateOfBirth = RetrieveAtributes.values(request, "fechaNac");
            if (!Validation.FormantDate(strDateOfBirth))
            {
                throw new ServiceException(MessageError.incorrectDateOfBirthFormat);
            }
        }

        private void validateRulesAttibutres_Tel_EmailP_EDO_MUN_CP(Dictionary<string, string> request)
        {
           
            string strTelefono = RetrieveAtributes.values(request, "tel");
            string strEmailPerson = RetrieveAtributes.values(request, "email");
            string strEstado = RetrieveAtributes.values(request, "state");
            string strMunicipio = RetrieveAtributes.values(request, "municipio");
            string strCP = RetrieveAtributes.values(request, "cp");

            if (!Validation.Select(strEstado))
            {
                throw new ServiceException(MessageError.invalidSelectorIn("estado"));
            }
            else if (!Validation.Select(strMunicipio))
            {
                throw new ServiceException(MessageError.invalidSelectorIn("municipio"));
            }
            else if (!Validation.Long(strCP, 5, 5))
            {
                throw new ServiceException(MessageError.wrongLength("CP", "5", "5"));
            }
            else if (!Validation.IsEmail(strEmailPerson))
            {
                throw new ServiceException(MessageError.incorrectFormatInEmail);
            }
            else
            {
                if (!Validation.numericalFormat(strTelefono))
                {
                    throw new ServiceException(MessageError.incorrectFormatInPhoneNumbere);
                }
                else if (!Validation.Long(strTelefono, 10, 10))
                {
                    throw new ServiceException(MessageError.wrongLength("telefono", "10", "10"));
                }
            }
        }
        protected void validateDuplicateEmailiISpecificTable(User user,string table)
        {

            var existsEmail = DuplicateField.duplicate("correoP", user.correoP, table);
            if (existsEmail)
            {
                var campos = new Dictionary<string, string>();
                campos.Add("correoP", user.correoP);
                campos.Add("id", user.id.ToString());

                var existsEmailAndID = DuplicateField.duplicate(campos, table);
                if (!existsEmailAndID)
                {
                    throw new ServiceException(MessageError.existingEmail);
                }
            }
        }

        private User retriveAttributesDataPersonForUpdate(Dictionary<string, string> submit)
        {
            //fechaNac
            User user = new User();
            user.nombres = RetrieveAtributes.values(submit, "nombres");
            user.apellidoP = RetrieveAtributes.values(submit, "apellidoP");
            user.apellidoM = RetrieveAtributes.values(submit, "apellidoM");            
            user.telefono = RetrieveAtributes.values(submit, "tel");
            user.correoP = RetrieveAtributes.values(submit, "email");
            return user;
        }
        protected void validateFormantDivisions(Dictionary<string, string> request)
        {
            string fkDivision = RetrieveAtributes.values(request, "divisiones");
            if (!Validation.Select(fkDivision))
            {
                throw new ServiceException(MessageError.invalidSelectorIn("divisiones"));
            }
        }
        protected void deleteFaileUser(string binder,string fileName)
        {            
            string path = @"h:/root/home/jisraelcj-001/www/site1/gentelella-master/production/images/perzonalizadas/usuarios/" + binder+" / "+fileName;
            if (File.Exists(path))
            {                
                try
                {
                    File.Delete(path);
                }
                catch (IOException e)
                {
                    throw new ServiceException(e.Message);
                }
            }            
        }
        protected string saveImageUser(HttpPostedFile file, string binder)
        {
            string pathFileReturn = "";            
            string UpLoadPath = @"h:/root/home/jisraelcj-001/www/site1/gentelella-master/production/images/perzonalizadas/usuarios/" + binder;
            if (file==null)
            {
                throw new ServiceException("Cargar archivo correctamente");
            }
            else
            {
                try
                {
                    string ext = Path.GetExtension(file.FileName);
                    if (ext != ".jpg" && ext != ".png")
                    {
                        throw new ServiceException(MessageError.wrongFileExtension("png o jpg"));
                    }
                    string pathFile = UpLoadPath + "/" + file.FileName;
                    pathFileReturn = "images/perzonalizadas/usuarios/" + binder + "/" + file.FileName;
                    file.SaveAs(pathFile);
                }
                catch (Exception e)
                {
                    throw new ServiceException(MessageError.errorSavingUserImage);
                }
            }                       
            return pathFileReturn;
        }
        public bool loginUsua(string email, string passRequest,ref string urlRederic)
        {                        
            string passwordEncrypt = EncryptPassword.GetMD5(passRequest);
            User userLoggedIn = session.login(email.Trim()); ;                  
            //try
            //{              
                
            //}
            //catch (Exception ex)
            //{
            //    // Agregue el manejo de errores aquí para la depuración.
            //    // Este mensaje de error no debe devolverse a la persona que llama.
            //    System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
            //}

            // Si no se encuentra la contraseña, devuelve false.
            if (null == userLoggedIn.pass)
            {
                // Puede escribir aquí los intentos de inicio de sesión fallidos en el registro de eventos para mayor seguridad.
                return false;
            }
            bool successfulLogin= (0 == string.Compare(userLoggedIn.pass, passwordEncrypt, false));
            if (!successfulLogin)
            {
                throw new LoginException("Contraseña incorrecta");
            }
            if (userLoggedIn.fkStatusUser == "bloqueado")
            {
                throw new LoginException("Por el momento tu cuenta esta bloqueda.");
            }
            if (successfulLogin)
            {
                string rolLoggedIn = session.rolUserLoggedIn(userLoggedIn.id);

                //Volver mas autonomo la ruta de redireccionamiento
                if (rolLoggedIn == "Encuestado")
                {
                    urlRederic = "binderSurvey/Encuesta.aspx";
                }
                else if (rolLoggedIn == "Encuestador")
                {
                    urlRederic = "binderSurvey/answeredSurveys.aspx";
                }
                else
                {
                    urlRederic = "indexUser.aspx";
                }
            }
            // Compare lookupPassword e ingrese passWord, utilizando una comparación que distingue entre mayúsculas y minúsculas.
            return successfulLogin;
        }
        public string rolLoggedIn(int idUser)
        {
            return session.rolUserLoggedIn(idUser);
        }
        public bool validateIfExistEmailInstitutional(string email)
        {

            var existsEmailTL = DuplicateField.duplicate("correoIns", email.Trim(), "tabajadorLocal");
            var existsEmailTG = DuplicateField.duplicate("correoIns", email.Trim(), "tabajadorGeneral");
            var existsEmailAL = DuplicateField.duplicate("correoIns", email.Trim(), "alumnos");
            return existsEmailTL || existsEmailTG || existsEmailAL;
        }
        public User retriveUser(string email,List<string> camposView=null)
        {
            User user = null;           
            var camposWhere = new Dictionary<string, string>();
            camposWhere.Add("correoIns", email.Trim());

            var existsEmailTL = DuplicateField.duplicate("correoIns", email.Trim(), "tabajadorLocal");
            var existsEmailTG = DuplicateField.duplicate("correoIns", email.Trim(), "tabajadorGeneral");
            var existsEmailAL = DuplicateField.duplicate("correoIns", email.Trim(), "alumnos");
            if (existsEmailTL)
            {
                user = retriveObjUser(Converter.ToDictionary(Select.findFromAll("tabajadorLocal", camposWhere).Rows[0]), camposView);
                user.typeUser = "tabajadorLocal";
            }                
            else if (existsEmailTG)
            {
                user = retriveObjUser(Converter.ToDictionary(Select.findFromAll("tabajadorGeneral", camposWhere).Rows[0],"nombre", "nombres"), camposView);
                user.typeUser = "tabajadorGeneral";
            }                
            else if (existsEmailAL)
            {
                user = retriveObjUser(Converter.ToDictionary(Select.findFromAll("alumnos", camposWhere)), camposView);
                user.typeUser = "alumno";
            }                
            return user;
        }
        private User retriveObjUser(Dictionary<string, string> fields,List<string> fieldsView=null)
        {
            User user = new User();

            if (fieldsView != null)
            {
                if (fieldsView.Contains("id"))
                {
                    user.id = Convert.ToInt32(
                        RetrieveAtributes.values(fields, "id"));
                }
                if (fieldsView.Contains("nombres"))
                {
                    user.nombres = RetrieveAtributes.values(fields, "nombres");
                }
                if (fieldsView.Contains("apellidoP"))
                {
                    user.apellidoP = RetrieveAtributes.values(fields, "apellidoP");
                }
                if (fieldsView.Contains("apellidoM"))
                {
                    user.apellidoM = RetrieveAtributes.values(fields, "apellidoM");
                }
                if (fieldsView.Contains("matricula"))
                {
                    user.matricula = RetrieveAtributes.values(fields, "matricula");
                }
                if (fieldsView.Contains("correoIns"))
                {
                    user.correoIns = RetrieveAtributes.values(fields, "correoIns");
                }
                if (fieldsView.Contains("telefono"))
                {
                    user.telefono = RetrieveAtributes.values(fields, "telefono");
                }
                if (fieldsView.Contains("image"))
                {
                    user.image = RetrieveAtributes.values(fields, "image");
                }
                if (fieldsView.Contains("nameCookie"))
                {
                    user.nameCookie = RetrieveAtributes.values(fields, "nameCookie");
                }
            }
            else
            {
                user.id = Convert.ToInt32(
                RetrieveAtributes.values(fields, "id"));
                user.nombres = RetrieveAtributes.values(fields, "nombres");
                user.apellidoP = RetrieveAtributes.values(fields, "apellidoP");
                user.apellidoM = RetrieveAtributes.values(fields, "apellidoM");
                user.matricula = RetrieveAtributes.values(fields, "matricula");
                user.telefono = RetrieveAtributes.values(fields, "telefono");
                user.correoIns = RetrieveAtributes.values(fields, "correoIns");
                user.image = RetrieveAtributes.values(fields, "image");
            }            
            return user;
        }
        /// <summary>
        /// Obtiene los permisos junto con sus privilegios del usuarui logueado.
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <returns>Un string con los privilegios del usuario logueado.</returns>
        public string permisosUsuarioLogueado(User usuarioLogueado)
        {
            string strPermisos = "";
            //Se contruye un mapa con los roles exitentes.
            if (usuarioLogueado!=null)
            {
                if (usuarioLogueado.typeUser== "tabajadorLocal")
                {
                    var row = tableEmployes.tableRolesByEmployeLocalID(usuarioLogueado.id);
                    if (row != null)
                    {
                        strPermisos = row[3].ToString();
                    }

                }
                else if (usuarioLogueado.typeUser == "tabajadorGeneral")
                {
                    var row = tableEmployes.tableRolesByEmployeGenerallID(usuarioLogueado.id);
                    if (row != null)
                    {
                        strPermisos = row[3].ToString();
                    }                    
                }
                else if (usuarioLogueado.typeUser == "alumno")
                {

                }                
            }
            return strPermisos;
        }

        public List<string> permisosUsuarioLogueadoList(User usuarioLogueado)
        {
            var privilegesUser = new List<string>();
            if (usuarioLogueado != null)
            {
                if (usuarioLogueado.typeUser == "tabajadorLocal")
                {
                    privilegesUser = Converter.ToList(tableEmployes.privilegesByEmployeLocaID(usuarioLogueado.id));                    

                }
                else if (usuarioLogueado.typeUser == "tabajadorGeneral")
                {
                    privilegesUser= Converter.ToList( tableEmployes.tablePrivilegesByEmployeGeneralID(usuarioLogueado.id));
                  
                }
                else if (usuarioLogueado.typeUser == "alumno")
                {

                }
            }
            return privilegesUser;
        }
        protected string defineImagePath(Dictionary<string, string> request, HttpPostedFile file,string binder)
        {
            return file == null || file.FileName == "" ? RetrieveAtributes.values(request, "imageUploadAut") : saveImageUser(file, binder);
        }
        public string jsonStatusuUsers()
        {
            return Converter.ToJson(listStatusUser.listarStatusUsers());
        }
        protected void retiveFileNamesUsersAndDeleteFiles(string binder,string field,string table,string fieldWhere,string idsUser)
        {
            var namesFilesUsers = Select.findFieldsWhereIn(field, table, fieldWhere, idsUser);
            foreach (string name in namesFilesUsers)
            {
                deleteFaileUser(binder, name);
            }
        }
        protected string retiveFileNameUser(string field,string table,string fieldWhere,string idsUser)
        {
            return Select.findFieldWhere(field, table, fieldWhere, idsUser).ToString();
        }
        protected void rollbackAddress(int idDomicilio, int idUser)
        {
            if (idUser == 0)
            {
                delete.deleteWhere("addresses", "idDomicilio", idDomicilio.ToString());

            }
        }
        protected void rollbackFile(int idUser,string binder,string fileNme)
        {
            if (idUser == 0)
            {
                deleteFaileUser(binder,fileNme);

            }
        }
        protected string defineTheSourceOfTheFileName(HttpPostedFile file,string slcField,string table,string fieldWhere,string idUser)
        {            
            return file==null||file.FileName==""? retiveFileNameUser(slcField, table, fieldWhere, idUser): file.FileName;
        }

        public User findStatusUser(User user)
        {
            return session.findStatusUserLoggeIn(user.id);
        }
    }
}
