using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaLogicaNegocio.Selects
{
    public class Select
    {
        public static DataTable findFromAll(string table)
        {
            FindFrom findFrom = new FindFrom("centroEscolar");
            return findFrom.findFromAll(table);
        }
        public static DataTable findFromAll(string table, Dictionary<string, string> camposWhere)
        {
            FindFrom findFrom = new FindFrom("centroEscolar");
            return findFrom.findFromAll(camposWhere,table);
        }
        public static List<object> findFieldsWhereIn(string field, string table, string fieldWhere, string valueFieldWhere)
        {
            FindFrom findFrom = new FindFrom("centroEscolar");
            return findFrom.findFieldsFrom(field, table, fieldWhere,valueFieldWhere);
        }
        public static object findFieldWhere(string field, string table, string fieldWhere, string valueFieldWhere)
        {
            FindFrom findFrom = new FindFrom("centroEscolar");
            return findFrom.findFieldFrom(field, table, fieldWhere, valueFieldWhere);
        }

    }
}