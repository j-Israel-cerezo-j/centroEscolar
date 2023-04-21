using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.binderSurvey.Services.Onkeyups
{
    public class Onkeyup
    {
        public static DataTable onkeyubSearchh(Dictionary<string, string> campos, string table)
        {
            FindFrom findBy = new FindFrom("pollster");
            return findBy.findFromLike(campos, table);
        }

        public static DataTable onkeyubSearchhTable(Dictionary<string, string> campos, string table)
        {
            FindFrom findBy = new FindFrom("pollster");
            return findBy.findAllFromLike(campos, table);
        }
    }
}
