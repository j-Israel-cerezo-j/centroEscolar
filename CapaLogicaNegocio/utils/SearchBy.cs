using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace CapaLogicaNegocio.utils
{
    public class SearchBy
    {
        public static string field(DataTable table, string fieldToSearch)
        {
            string foundField = "";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    if (table.Columns[j].ColumnName == fieldToSearch)
                    {
                        return table.Rows[i][j].ToString();
                    }
                }
            }
            return foundField;
        }       
    }
}
