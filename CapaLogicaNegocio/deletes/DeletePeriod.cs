using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.deletes
{
    public class DeletePeriod
    {
        private DatosPeriod datos = new DatosPeriod();
        public bool delete(string strIds)
        {
            return datos.eliminarPeriods(strIds);
        }
    }
}
