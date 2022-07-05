using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.updates
{
    public class UpdateHour
    {
        private DatosHour datos = new DatosHour();
        public bool update(Hour hour)
        {
            return datos.updateHour(hour);
        }
    }
}
