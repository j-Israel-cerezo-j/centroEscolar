using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.binderSurvey.Services.Selects
{
    internal class Select
    {
        public static DataTable findFromAll(string table)
        {
            FindFrom findFrom = new FindFrom("pollster");
            return findFrom.findFromAll(table);
        }
        public static DataTable findFromAll(string table, Dictionary<string, string> camposWhere,string field="*")
        {
            FindFrom findFrom = new FindFrom("pollster");
            return findFrom.findFromAll(camposWhere, table, field);
        }
        public static List<object> findFieldsWhereIn(string field, string table, string fieldWhere, string valueFieldWhere)
        {
            FindFrom findFrom = new FindFrom("pollster");
            return findFrom.findFieldsFrom(field, table, fieldWhere, valueFieldWhere);
        }
        public static object findFieldWhere(string field, string table, string fieldWhere, string valueFieldWhere)
        {
            FindFrom findFrom = new FindFrom("pollster");
            return findFrom.findFieldFrom(field, table, fieldWhere, valueFieldWhere);
        }
    }
}
