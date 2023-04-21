using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogicaNegocio.Adds;
using Entidades;
using CapaLogicaNegocio.Insert;
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
using CapaLogicaNegocio.tablesInner;
using CapaLogicaNegocio.Selects;

namespace CapaLogicaNegocio
{
    public class RolePrivilegesService
    {
        private ListarRoles listRoless = new ListarRoles();
        private ListPrivileges listPrivileges = new ListPrivileges();
        private TableRolesPrivileges tableRolesPrivileges = new TableRolesPrivileges();
        private Delete delete = new Delete();
        public bool add(Dictionary<string,string> request,bool banValidateDuplicateFields)
        {
            string strIdRol = RetrieveAtributes.values(request, "roles");
            string strPrivileges = RetrieveAtributes.values(request, "checksPrivileges");
            validateRequest(request);
            validateChecksPrivileges(request);
            if (banValidateDuplicateFields)
            {
                validateDuplicateFields(strIdRol, strPrivileges);
            }            
            var listPrivileges = Converter.ToList(strPrivileges);
            var campos =new Dictionary<object, List<object>>();
            campos.Add(strIdRol, listPrivileges);
            return Inserts.Many(campos,"privilegesRoles");
        }
        public List<Rol> listRoles()
        {
            return listRoless.listarRoles();
        }
        public List<Privilege> lisstPrivileges()
        {
            return listPrivileges.listarPrivilege();
        }
        public string jsonrolesPrivileges()
        {
            return Converter.ToJson(tableRolesPrivileges.tablePrivilegesTheRoless(),"id").ToString();
        }
        private void validateRequest(Dictionary<string, string> request)
        {
            string strIdRol = RetrieveAtributes.values(request, "roles");
            if (!Validation.Select(strIdRol))
            {
                throw new ServiceException(MessageError.invalidSelectorIn("roles"));
            }
        }
        private void validateDuplicateFields(string strIdRol, string strPrivileges)
        {
            var listPrivileges = Converter.ToList(strPrivileges);
            var camposWhere = new Dictionary<string, string>();
            foreach (var item in listPrivileges)
            {
                camposWhere.Add("fkidPrivilege", item.ToString());
                camposWhere.Add("fkRol", strIdRol);
                var fields = Select.findFromAll("privilegesRoles", camposWhere);
                if (fields.Rows.Count>=1)
                {
                    throw new ServiceException("Privilegio ya asignado al rol especificado");
                }
                camposWhere.Clear();
            }
        }
        private void validateChecksPrivileges(Dictionary<string, string> request)
        {
            string strDivisions = RetrieveAtributes.values(request, "checksPrivileges");
            if (strDivisions == "" || strDivisions == null)
            {
                throw new ServiceException(MessageError.privilegesNotSelected);
            }
        }
        public bool deletePrivilegesRoles(string ids)
        {
            bool privilegesRoles=false;
            if (ids != "")
            {
                 privilegesRoles = delete.whereIn("privilegesRoles", "fkRol", ids);
            }
            else
            {
                throw new ServiceException(MessageError.privilegesNotSelected);
            }
            return privilegesRoles;
        }
        public bool update(Dictionary<string, string> request,string strIdRolAnt)
        {
            string strIdRol = RetrieveAtributes.values(request, "roles");
            //string antIdRol = RetrieveAtributesValues.retrieveAtributesValues(request, "antidRol");
            bool updateSuccess=false;
            if (strIdRolAnt == strIdRol)
            {                
                deletePrivilegesRoles(strIdRol);
                updateSuccess=add(request,false);
            }
            else
            {
                throw new ServiceException("No puedes cambiar el tipo de rol a la hora de modificar");
            }
            return updateSuccess;
        }
        public string jsonRecoverData(string strId)
        {
            string jsonRecoerDtes = "";
            if (strId != "")
            {
                jsonRecoerDtes = Converter.ToJson(tableRolesPrivileges.tablePrivilegesRolessByidRol(Convert.ToInt32(strId))).ToString();
            }
            return jsonRecoerDtes;
        }
        public List<string> onkeyupSearch(string caracteres)
        {
            caracteres = "%" + caracteres + "%";
            var table = tableRolesPrivileges.tablePrivilegesRolessByCharacters(caracteres);
            return Converter.ToList(table);

        }
        public StringBuilder onkeyupSearchTable(string caracteres)
        {
            var table = tableRolesPrivileges.tablePrivilegesRolessByCharacters(caracteres);
            return Converter.ToJson(table,"id");

        }
    }
}
