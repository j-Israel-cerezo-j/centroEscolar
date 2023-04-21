using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Adds
{
    public class AddBuilding
    {
        private DatosBuilding datos = new DatosBuilding();
        public bool add(Building building)
        {
            return datos.add(building);
        }
    }
}
