using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.updates
{
    public class UpdateBuilding
    {
        private DatosBuilding datos = new DatosBuilding();
        public bool update(Building building)
        {
            return datos.updateBuilding(building);
        }
    }
}
