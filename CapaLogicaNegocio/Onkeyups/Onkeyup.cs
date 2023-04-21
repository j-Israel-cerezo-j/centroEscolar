using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaLogicaNegocio.Onkeyups
{
    public class Onkeyup
    {        
        public static DataTable onkeyubSearchh(Dictionary<string, string> campos, string table)
        {
            FindFrom findBy = new FindFrom("centroEscolar");
            return findBy.findFromLike(campos, table);
        }

        public static DataTable onkeyubSearchhTable(Dictionary<string, string> campos, string table)
        {
            FindFrom findBy = new FindFrom("centroEscolar");
            return findBy.findAllFromLike(campos, table);
        }
    }
}
