using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using CapaLogicaNegocio.Adds;

namespace CapaLogicaNegocio.tablesInner
{
    public class TableEmployes
    {
        DatosEmploye datos = new DatosEmploye();
        public DataTable tableEmployesLocales()
        {
            return datos.tableEmployesLocales();
        }
        public DataTable tableEmployesGnerales()
        {
            return datos.tableEmployesGenerales();
        }
        public DataTable tableEmployeLocaleByIdEmploye(int idEmploye)
        {
            return datos.tableEmployeLocaleByIDEmploye(idEmploye);
        }
        public DataRow tableRolesByEmployeLocalID(int idEmploye)
        {
            DataRow row = null;
            DataTable table= datos.tableRolesByEmployeLocalID(idEmploye);
            if (table.Rows.Count > 0)
            {
                row = table.Rows[0];
            }
            return row;
        }
        public DataRow tableRolesByEmployeGenerallID(int idEmploye)
        {
            DataRow row = null;
            DataTable table = datos.tableRolesByEmployeGenerallID(idEmploye);
            if (table.Rows.Count > 0)
            {
                row = table.Rows[0];
            }
            return row;
        }
        public DataTable tableEmployeGenerealByIdEmploye(int idEmploye)
        {
            return datos.tableEmployeGeneralByIDEmploye(idEmploye);
        }
        public DataTable tableEmployesBymatchingCharacters(string characters,string strIdTypeWorker)
        {
            DataTable table = new DataTable();
            if (strIdTypeWorker == "Divisional")
            {
                table= datos.tableEmployesLocalesByMatchingCharacterss(characters);
            }
            else if (strIdTypeWorker == "General")
            {
                table = datos.tableEmployesGeneralesByMatchingCharacterss(characters);
            }
            return table;
        }
        public DataTable tablePrivilegesByEmployeGeneralID(int idEmploye)
        {
           return datos.privilegesByEmployeGeneralID(idEmploye);
        }
        public DataTable privilegesByEmployeLocaID(int idEmploye)
        {
            return datos.privilegesByEmployeLocalID(idEmploye);
        }
    }
}
