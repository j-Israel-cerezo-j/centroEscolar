using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.recoverDates
{
    public class RecoverDataCarrer
    {
        private DatosCarrer datos = new DatosCarrer();

        public Carrer recoverData(int id)
        {
            return datos.recoverData(id);
        }
    }
}
