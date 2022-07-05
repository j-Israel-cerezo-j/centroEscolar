using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.recoverDates
{
    public  class RecoverDataGroups
    {
        private DatosGroup datos = new DatosGroup();

        public Group recoverData(int id)
        {
            return datos.recoverData(id);
        }
    }
}
