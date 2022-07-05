using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.deletes
{
    public class DeleteLevel
    {
        private DatosLevel datos = new DatosLevel();
        public bool delete(string strIds)
        {
            return datos.eliminarCuatrimestres(strIds);
        }
    }
}
