using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Lists
{
    public class ListCarrers
    {
        private DatosCarrer datos = new DatosCarrer();
        public List<Carrer> listarCarres()
        {
            return datos.listarCarrers();
        }
    }
}
