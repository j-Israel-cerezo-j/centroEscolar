using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Lists
{
    public class ListStatusCandiadate
    {
        private DatosStatusCandidate datos = new DatosStatusCandidate();

        public List<StatusCandidate> listarStatusCandidate()
        {
            return datos.listarStatus();
        }
    }
}
