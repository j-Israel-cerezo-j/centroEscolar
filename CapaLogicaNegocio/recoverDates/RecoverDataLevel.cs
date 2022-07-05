using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.recoverDates
{
    public class RecoverDataLevel
    {
        private DatosLevel datos = new DatosLevel();

        public Level recoverData(int id)
        {
            return datos.recoverData(id);
        }
    }
}
