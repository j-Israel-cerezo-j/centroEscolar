using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaLogicaNegocio.tablesInner
{
    public class TableRolesPrivileges
    {
        private DatosRolePrivileges datos = new DatosRolePrivileges();
        public DataTable tablePrivilegesTheRoless()
        {
            return datos.tablePrivilegesTheRoles();
        }
        public DataTable tablePrivilegesRolessByidRol(int id)
        {
            return datos.tablePrivilegesByIdRol(id);
        }
        public DataTable tablePrivilegesRolessByCharacters(string characters)
        {
            return datos.tablePrivilegesRolessByCharacters(characters);
        }
    }
}
