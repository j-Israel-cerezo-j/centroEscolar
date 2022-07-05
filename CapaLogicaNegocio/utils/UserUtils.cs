using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.utils
{
    public class UserUtils
    {
        public static string GenerateMatricula(string curp)
        {
            string matricula = "utp";
            if (curp.Length > 9)
            {
                matricula+=curp.Substring(0,10);
            }
            return matricula;
        }
        public static string GenerateInstitutionalEmail(string matricula)
        {
            string domain = "@alumno.utpuebla.edu.mx";
            return matricula + domain;
        }
        public static string GeneratePasswordUser(DateTime birthDate)
        {            
            int day = birthDate.Day;
            int month = birthDate.Month;
            int year = birthDate.Year;
            return year.ToString() + month.ToString() + day.ToString();
        }
    }
}
