using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Lists
{
    public class ListBuildings
    {
        private DatosBuilding datos = new DatosBuilding();
        public List<Building> listarBuildings()
        {
            return datos.listarBuildings();
        }
        public List<Building> listarBuildingsXcarrer(int id)
        {
            return datos.listarBuildingsXidCarrer(id);
        }
    }
}
