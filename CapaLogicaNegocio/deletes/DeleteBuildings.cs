using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.deletes
{
    public class DeleteBuildings
    {
        private DatosBuilding datos = new DatosBuilding();
        public bool delete(string strIds)
        {
            return datos.eliminarEdificios(strIds);
        }
    }
}
