using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.recoverDates
{
    public class RecoverDataBuilding
    {
        private DatosBuilding datos = new DatosBuilding();

        public Building recoverData(int id)
        {
            return datos.recoverData(id);
        }
    }
}
