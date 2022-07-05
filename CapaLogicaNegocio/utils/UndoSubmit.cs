using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.undoSubmit
{
    public class UndoSubmit
    {
        public static List<string> undoSubmit(string submit)
        {
            string atribute = "";
            List<string> atributes = new List<string>();
            submit += ",";
            for (int i = 0; i < submit.Length; i++)
            {
                if (submit[i] == ',')
                {
                    atributes.Add(atribute);
                    atribute = "";
                }
                else
                {
                    atribute += submit[i];
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
