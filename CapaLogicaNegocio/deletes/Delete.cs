using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaLogicaNegocio.deletes
{
    public class Delete
    {
        private DeleteWhere delete = new DeleteWhere("centroEscolar");
        public bool deleteWhere(string table, string field,string fieldValue)
        {
            return delete.where(table,field, fieldValue);
        }
        public bool whereIn(string table, string field, List<string> valiesField)
        {
            return delete.whereIn(table, field, valiesField);
        }
        public bool whereIn(string table, string field,string strValiesField)
        {
            return delete.whereIn(table, field, strValiesField);
        }
    }
}
