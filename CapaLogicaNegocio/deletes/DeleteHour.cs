using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.deletes
{
    public class DeleteHour
    {
        private DatosHour datos = new DatosHour();
        public bool delete(string strIds)
        {
            return datos.eliminarHours(strIds);
        }
    }
}
