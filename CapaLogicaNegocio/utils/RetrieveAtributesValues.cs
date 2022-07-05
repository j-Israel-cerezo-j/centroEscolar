using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.retrieveAtributesValues
{
    public class RetrieveAtributesValues
    {
        public static string retrieveAtributesValues(Dictionary<string, string> submit,string campo)
        {
            string atrivutteValue = "";
            foreach (var item in submit)
            {
                if (item.Key == campo)
                {                    
                    atrivutteValue = item.Value;
                    break;
                }
            }
            return atrivutteValue;
        }
    }
}
