using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.recoverDates
{
    public class RecoverDataPeriod
    {
        private DatosPeriod datos = new DatosPeriod();

        public Period recoverData(int id)
        {
            return datos.recoverData(id);
        }
    }
}
