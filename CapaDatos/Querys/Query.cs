using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Querys
{
    public class Query
    {
        public static string getCounts(Dictionary<string, string> campos, string table)
        {
            string fieldTblUnions = "";
            foreach (var item in campos)
            {
                fieldTblUnions += " union (select '" + item.Key + "' as 'field', COUNT(*) as 'count' from " + table + " where " + item.Key + " = '" + item.Value + "') as table" + item.Key;
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
                fieldTblUnions += " and " + item.Key + " = '" + item.Value + "'";
            }
            fieldTblUnions = fieldTblUnions.Remove(0, 5);
            string query = "select * from " + table + " where " + fieldTblUnions;
            return query;
        }
        public static string FindFromLike(Dictionary<string, string> campos, string table)
        {
            string fields = "";
            string valuesUnions = "";
            foreach (var item in campos)
            {
                fields += item.Key + ",";
            }
            if (fields != "")
            {
                fields= fields.Substring(0, fields.Length - 1);
            }
            foreach (var item in campos)
            {
                valuesUnions += " or " + item.Key + " like '%" + item.Value + "%'";
            }
            valuesUnions = valuesUnions.Remove(0, 3);
            string query = "select "+ fields + " from " + table + " where " + valuesUnions;
            return query;
        }

        public static string FindAllFromLike(Dictionary<string, string> campos, string table)
        {          
            string valuesUnions = "";           
            foreach (var item in campos)
            {
                valuesUnions += " or " + item.Key + " like '%" + item.Value + "%'";
            }
            valuesUnions = valuesUnions.Remove(0, 3);
            string query = "select * from " + table + " where " + valuesUnions;
            return query;
        }
        public static string FindAllFrom(Dictionary<string, string> camposWhere, string table,string field="*")
        {
            string valuesUnions = "";
            foreach (var item in camposWhere)
            {
                valuesUnions += " and " + item.Key + "='" + item.Value + "'";
            }
            valuesUnions = valuesUnions.Remove(0, 4);
            string query = "select "+ field + " from " + table + " where " + valuesUnions;
            return query;
        }

        public static string FindAllFrom(string table)
        {
            return "select * from " + table;
        }
        public static string InsertMany(string strFieldsUnios, string table)
        {

            string query = "insert into " + table + " values " + strFieldsUnios;
            return query;
        }
        public static string InsertMany(Dictionary<object, object> campos, string table)
        {
            string valuesUnions = "";
            foreach (var item in campos)
            {
                valuesUnions += " , (" + item.Key + "," + item.Value + ")";
            }
            valuesUnions = valuesUnions.Remove(0, 2);
            string query = "insert into " + table + " values " + valuesUnions;
            return query;
        }
        public static string InsertMany(Dictionary<object, List<object>> campos, string table,List<object> extraFields=null)
        {
            string valuesUnions = "";
            foreach (var item in campos)
            {
                foreach (var it in item.Value)
                {
                    valuesUnions += " ,(" + it + "," + item.Key;
                    if (extraFields != null)
                    {
                        foreach (var itemList in extraFields)
                        {
                            valuesUnions += "," + itemList;
                        }
                    }
                    valuesUnions += ")";
                }                
            }
            valuesUnions = valuesUnions.Remove(0, 2);
            string query = "insert into " + table + " values " + valuesUnions;
            return query;
        }
        public static string InsertMany(Dictionary<List<object>,object> campos, string table,List<object> extraFields = null)
        {
            string valuesUnions = "";
            foreach (var item in campos)
            {
                foreach (var it in item.Key)
                {
                    valuesUnions += " , (" + item.Value + "," + it;
                    if (extraFields != null)
                    {
                        foreach (var itemList in extraFields)
                        {
                            valuesUnions += "," + itemList;
                        }
                    }
                    valuesUnions += ")";
                }
            }
            valuesUnions = valuesUnions.Remove(0, 2);
            string query = "insert into " + table + " values " + valuesUnions;
            return query;
        }
        public static string deleteWhere(string table,string fieldWhere,string valueField)
        {
            return "delete from " + table + " where " + fieldWhere + "=" + valueField;
        }
        public static string deleteWhereIn(string table, string fieldWhere, List<string> valuesField)
        {
            string strValuesField = "";
            foreach (var item in valuesField)
            {
                strValuesField += " ," + item;
            }
            strValuesField = strValuesField.Remove(0, 2);
            return "delete from " + table + " where " + fieldWhere + " in (" + strValuesField + ")";
        }
        public static string deleteWhereIn(string table, string fieldWhere, string strValuesField)
        {           
            return "delete from " + table + " where " + fieldWhere + " in (" + strValuesField + ")";
        }
        public static string deleteWhereAnd(Dictionary<string, string> campos, string table)
        {
            string fieldTblUnions = "";
            foreach (var item in campos)
            {
                fieldTblUnions += " and " + item.Key + " = '" + item.Value + "'";
            }
            fieldTblUnions = fieldTblUnions.Remove(0, 5);
            string query = "delete from " + table + " where " + fieldTblUnions;
            return query;
        }
        public static string updateWhere(string table, string fieldWhere, string strValueFieldSet,string fielSet,string fieldValueWhere)
        {
            return "update " + table + " set "+ fielSet + "='"+ strValueFieldSet + "' where " + fieldWhere + "=" + fieldValueWhere;
        }
        public static string selectFieldWhere(string selectFiel,string table,string fielWhere,string strFieldWhereValue)
        {
            return "select " + selectFiel + " from " + table + " where " + fielWhere + "='" + strFieldWhereValue + "'";
        }
        public static string selectFieldWhereUnion(string field,string table,string fieldWhere,string valueFieldWhere)
        {
            return "select "+ field +" from " + table + " where " + fieldWhere + " in (" + valueFieldWhere + ")";
        }
    }
}
