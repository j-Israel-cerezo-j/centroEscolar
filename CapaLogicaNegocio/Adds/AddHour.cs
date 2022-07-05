using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Adds
{
    public class AddHour
    {
        private DatosHour datos = new DatosHour();
        public bool add(Hour hour)
        {
            return datos.add(hour);
        }
    }
}
