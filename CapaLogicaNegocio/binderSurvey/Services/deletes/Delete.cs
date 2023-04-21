using CapaDatos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.binderSurvey.Services.deletes
{
    public class Delete
    {
        private DeleteWhere delete = new DeleteWhere("pollster");
        public bool deleteWhere(string table, string field, string fieldValue)
        {
            return delete.where(table, field, fieldValue);
        }
        public bool whereIn(string table, string field, List<string> valiesField)
        {
            return delete.whereIn(table, field, valiesField);
        }
        public bool whereIn(string table, string field, string strValiesField)
        {
            return delete.whereIn(table, field, strValiesField);
        }
        public bool whereInAnd(Dictionary<string,string> campos,string table)
        {
            return delete.whereInAnd(campos,table);
        }
    }
}
