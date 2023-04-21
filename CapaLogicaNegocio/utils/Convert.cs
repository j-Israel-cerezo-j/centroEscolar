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
            StringBuilder jsonSB = new StringBuilder();
            jsonSB.Append("[");
            foreach (var entity in entities)
            {
                if (entity!=null)
                {
                    ban = true;
                    jsonSB.Append(
                        "{" + entity.ToString() +
                        "},"
                        ); ;
                }                
            }
            string json = jsonSB.ToString();
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
        public static string ToJson(Dictionary<string, string> entities,List<string> camposView)
        {
            bool ban = false;
            StringBuilder jsonRoles = new StringBuilder();
            jsonRoles.Append("{");
            foreach (var entity in entities)
            {
                if (camposView.Contains(entity.Key))
                {
                    ban = true;
                    jsonRoles.Append(
                        entity.Key + ":'" + entity.Value + "',"
                        ); ;
                }
            }
            string json = jsonRoles.ToString();
            if (ban)
            {
                json = json.Substring(0, json.Length - 1);
            }
            json += "}";
            return json;
        }
        public static StringBuilder ToString(string[] entities)
        {            
            StringBuilder jsonSB = new StringBuilder();            
            foreach (var entity in entities)
            {                
                jsonSB.Append("'"+entity + "',");
            }
            if (entities.Length > 0)
            {
                jsonSB.Remove(jsonSB.Length - 1, 1);
            }                        
            return jsonSB;
        }
        public static StringBuilder ToString(List<object> entities)
        {
            StringBuilder jsonSB = new StringBuilder();
            foreach (var entity in entities)
            {
                jsonSB.Append("'" + entity + "',");
            }
            if (entities.Count > 0)
            {
                jsonSB.Remove(jsonSB.Length - 1, 1);
            }
            return jsonSB;
        }
        public static string ToJson(Dictionary<string, string[]> entities)
        {
            bool ban = false;
            StringBuilder jsonSB = new StringBuilder();
            jsonSB.Append("{");
            foreach (var entity in entities)
            {
                jsonSB.Append(entity.Key + ":[");
                foreach (var item in entity.Value)
                {
                    ban = true;
                    jsonSB.Append(
                       "'" + item + "',");
                }
                jsonSB.Remove(jsonSB.Length - 1, 1);
                jsonSB.Append("]");
            }
            string json = jsonSB.ToString();
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
        public static StringBuilder ToJson(DataTable table,string field)
        {
            int idAux = 0;
            StringBuilder jsonSb = new StringBuilder();
            jsonSb.Append("[");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (idAux != Convert.ToInt32(table.Rows[i][field].ToString()))
                {
                    jsonSb.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {                      
                        jsonSb.Append(table.Columns[j].ColumnName + ": '" + table.Rows[i][j].ToString() + "',");                                               
                    }
                    jsonSb.Remove(jsonSb.Length - 1, 1);
                    jsonSb.Append("},");
                }
                idAux = Convert.ToInt32(table.Rows[i][field].ToString());                
            }
            if (table.Rows.Count > 0)
            {
                jsonSb.Remove(jsonSb.Length - 1, 1);
            }
            jsonSb.Append("]");
            return jsonSb;
        }
        public static StringBuilder ToJson(DataTable table, string field, string asField)
        {
            StringBuilder jsonSb = new StringBuilder();
            jsonSb.Append("[");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                jsonSb.Append("{");
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    if (table.Columns[j].ColumnName == field)
                    {
                        jsonSb.Append(asField + ": '" + table.Rows[i][j].ToString() + "',");
                    }
                    else
                    {
                        jsonSb.Append(table.Columns[j].ColumnName + ": '" + table.Rows[i][j].ToString() + "',");
                    }
                }
                jsonSb.Remove(jsonSb.Length - 1, 1);
                jsonSb.Append("},");
            }
            if (table.Rows.Count > 0)
            {
                jsonSb.Remove(jsonSb.Length - 1, 1);
            }
            jsonSb.Append("]");
            return jsonSb;
        }
        public static List<object> ToList(string str)
        {
            string atribute = "";
            List<object> atributes = new List<object>();
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
        public static List<string> ToList(DataTable table)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    if (!list.Contains(table.Rows[i][j].ToString()))
                    {
                        list.Add(table.Rows[i][j].ToString());
                    }
                }
            }
            return list;
        }
        public static Dictionary<string,string> ToDictionary(DataTable table,bool isKeyColumnName=true)
        {
            var fields=new Dictionary<string,string>();
            for (int i = 0; i < table.Rows.Count; i++)
            {              
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    if (!fields.ContainsKey(table.Rows[i][j].ToString()))
                    {
                        if (isKeyColumnName)
                        {
                            fields.Add(table.Columns[j].ColumnName, table.Rows[i][j].ToString());
                        }
                        else
                        {
                            if (!fields.ContainsKey(table.Rows[i][0].ToString()))
                            {
                                fields.Add(table.Rows[i][0].ToString(), table.Rows[i][1].ToString());
                            }                                
                        }
                    }                        
                }
            }
            return fields;
        }

        public static Dictionary<string, string> ToDictionary(DataRow row,string antField, string asField)
        {
            var fields = new Dictionary<string, string>();
            for (int j = 0; j < row.ItemArray.Count(); j++)
            {
                if (!fields.ContainsKey(row.Table.Columns[j].ColumnName))
                {
                    if (row.Table.Columns[j].ColumnName == antField)
                    {
                        fields.Add(asField, row.ItemArray[j].ToString());
                    }
                    else
                    {
                        fields.Add(row.Table.Columns[j].ColumnName, row.ItemArray[j].ToString());
                    }                    
                }
            }
            return fields;
        }
        public static Dictionary<string, string> ToDictionary(DataRow row)
        {
            var fields = new Dictionary<string, string>();
            for (int j = 0; j < row.ItemArray.Count(); j++)
            {
                if (!fields.ContainsKey(row.Table.Columns[j].ColumnName))
                {
                    fields.Add(row.Table.Columns[j].ColumnName, row.ItemArray[j].ToString());
                }
            }
            return fields;
        }
    }
}
