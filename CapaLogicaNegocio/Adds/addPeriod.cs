using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Adds
{
    public class addPeriod
    {
        private DatosPeriod datos = new DatosPeriod();
        public bool add(Period period)
        {
            return datos.add(period);
        }
    }
}
