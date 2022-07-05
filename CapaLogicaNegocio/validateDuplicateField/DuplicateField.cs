using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaLogicaNegocio.validateDuplicateField
{   
    public class DuplicateField
    {
       
        public static DataTable fieldsCouts(Dictionary<string,string> campos,string table)
        {
            ValidateIfExits validateIfExits = new ValidateIfExits();
            return validateIfExits.getCounts(campos,table);
        }
        public static bool duplicate(Dictionary<string, string> campos, string table)
        {
            ValidateIfExits validateIfExits = new ValidateIfExits();
            return validateIfExits.ifExits(campos, table).Rows.Count>0;
        }
        public static bool duplicate(string fieldName, string fieldValue, string table)
        {
            bool ban = false;
            var campos = new Dictionary<string, string>();
            campos.Add(fieldName,fieldValue);
            var tableCounts= fieldsCouts(campos, table);

            if (tableCounts.Rows[0][1].ToString() == "1")
            {
                ban = true;
            }
            return ban;
        }

    }
}
