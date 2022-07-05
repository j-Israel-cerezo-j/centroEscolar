using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Querys
{
    public class Query
    {
        public static string getCounts(Dictionary<string,string> campos,string table)
        {
            string fieldTblUnions = "";         
                            foreach (var item in campos)
                            {
                    fieldTblUnions += " union (select '"+item.Key+"' as 'field', COUNT(*) as 'count' from "+ table + " where "+item.Key+" = '"+item.Value+"') as table"+item.Key;
                            }
            fieldTblUnions = fieldTblUnions.Remove(0, 7);
            string query = "select * from " + fieldTblUnions;
            return query;
        }
        public static string IfExists(Dictionary<string, string> campos, string table)
        {
            string fieldTblUnions = "";
            foreach (var item in campos)
            {
                fieldTblUnions += " and " + item.Key + " = '" + item.Value+"'";
            }
            fieldTblUnions = fieldTblUnions.Remove(0, 5);
            string query = "select * from "+table+" where " + fieldTblUnions;
            return query;
        }
    }
}
