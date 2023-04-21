using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
using System.Data;
using System.Data.SqlClient;
namespace CapaLogicaNegocio.tablesInner
{
    public class TableRoles
    {
        private DatosRoles datos = new DatosRoles();
        public DataTable tableRoless()
        {
            return datos.tableRoles();
        }
        public DataTable tableRolesBymatchingCharacters(string characters)
        {
            return datos.tableRolesByMatchingCharacterss(characters);
        }
    }
}
