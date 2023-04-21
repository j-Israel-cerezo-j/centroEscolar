using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Validaciones.util
{
    public class Validation
    {
        public static Object getValue(SqlDataReader renglon, string columna)
        {
            Object value;
            try
            {
                value = renglon[columna];

                if (DBNull.Value == value)
                {
                    value = null;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                value = null;
            }
            return value;
        }
        public static Dictionary<string, bool> isNullOrEmptys(Dictionary<string, string> attributes)
        {
            char[] charsToTrim = { ' ' };
            var result = new Dictionary<string, bool>();
            foreach (var item in attributes)
            {              
                string valueWithoutSpaces = item.Value.Trim(charsToTrim);
                if (String.IsNullOrEmpty(valueWithoutSpaces))
                {
                    result.Add(item.Key, true);
                    break;
                }
            }
            return result;
        }
        public static bool isNullOrEmpty(Dictionary<string, string> request,string field)
        {
            char[] charsToTrim = { ' ' };
            var result = false;
            foreach (var item in request)
            {
                string valueWithoutSpaces = item.Value.Trim(charsToTrim);
                if (valueWithoutSpaces==field)
                {
                    if (String.IsNullOrEmpty(valueWithoutSpaces))
                    {
                        result = true;
                        break;
                    }
                }                
            }
            return result;
        }
        public static bool IsEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public static bool numericalFormat(string strNumerico)
        {
            return strNumerico.All(char.IsDigit);
        }
        public static bool LongMin(string str,int longi)
        {
            bool logitudCorrecta = (str.Length >= longi);
            return logitudCorrecta;
        }
        public static bool LongMax(string str, int longi)
        {
            bool logitudCorrecta = (str.Length <= longi);
            return logitudCorrecta;
        }
        public static bool Long(string longitud,int longMin,int longMax)
        {
            bool logitudCorrecta = (longitud.Length >= longMin && longitud.Length <= longMax);
            return logitudCorrecta;
        }
        public static bool FormantDate(string strDate)
        {            
            DateTime dateFecha;
            return DateTime.TryParseExact(strDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out dateFecha);
        }
        public static bool FormantDateTime(string strDate)
        {
            DateTime dateFecha;
            return DateTime.TryParseExact(strDate, "yyyy-MM-ddTHH:mm", null, System.Globalization.DateTimeStyles.None, out dateFecha);
        }
        public static bool FormantTime(string strTime)
        {
            DateTime time;            
            return DateTime.TryParseExact(strTime, "HH:mm", null, System.Globalization.DateTimeStyles.None, out time);
        }
        public static bool Select(string select)
        {
            bool formatoCorrectoSelect = !(select == "-1" || select == null || select == "" || select=="-2");
            return formatoCorrectoSelect;
        }
        public static bool FormantCheck(string strCheck)
        {
            return !(strCheck == "" || strCheck == null);
        }
    }
}
