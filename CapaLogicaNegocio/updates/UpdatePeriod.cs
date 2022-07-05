using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.updates
{
    public class UpdatePeriod
    {
        private DatosPeriod datos = new DatosPeriod();
        public bool update(Period period)
        {
            return datos.updatePeriod(period);
        }
    }
}
