using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.recoverDates
{
    internal class RecoverDateHour
    {

        private DatosHour datos = new DatosHour();

        public Hour recoverData(int id)
        {
            return datos.recoverData(id);
        }
    }
}
