using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaLogicaNegocio.utils
{
    public  class Converter
    {
        public static string ToJson<T>(List<T> entities)
        {
            bool ban = false;
            StringBuilder jsonRoles = new StringBuilder();
            jsonRoles.Append("[");
            foreach (var entity in entities)
            {
                ban = true;
                jsonRoles.Append(
                    "{" + entity.ToString() +
                    "},"
                    ); ;
            }
            string json = jsonRoles.ToString();
            if (ban)
            {
                json = json.Substring(0, json.Length - 1);
            }
            json += "]";
            return json;
        }
        public static string ToJson(Dictionary<string,string> entities)
        {
            bool ban = false;
            StringBuilder jsonRoles = new StringBuilder();
            jsonRoles.Append("{");
            foreach (var entity in entities)
            {
                ban = true;
                jsonRoles.Append(
                    entity.Key+":'"+entity.Value  +"',"
                    ); ;
            }
            string json = jsonRoles.ToString();
            if (ban)
            {
                json = json.Substring(0, json.Length - 1);
            }
            json += "}";
            return json;
        }
        public static StringBuilder ToJson(DataTable table)
        {
            StringBuilder jsonSb = new StringBuilder();
            jsonSb.Append("[");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                jsonSb.Append("{");
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    jsonSb.Append(table.Columns[j].ColumnName+": '"+table.Rows[i][j].ToString()+"',");                    
                }
                jsonSb.Remove(jsonSb.Length-1, 1);
                jsonSb.Append("},");
            }
            if (table.Rows.Count > 0)
            {
                jsonSb.Remove(jsonSb.Length - 1, 1);
            }            
            jsonSb.Append("]");
            return jsonSb;
        }
        public static List<string> ToList(string str)
        {
            string atribute = "";
            List<string> atributes = new List<string>();
            str += ",";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ',')
                {
                    atributes.Add(atribute);
                    atribute = "";
                }
                else
                {
                    atribute += str[i];
                }
            }
            if (atribute != "")
            {
                atributes.Add(atribute);
            }
            return atributes;
        }
    }
}
