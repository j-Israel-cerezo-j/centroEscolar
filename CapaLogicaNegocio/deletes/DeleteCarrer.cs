using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.deletes
{
    public class DeleteCarrer
    {
        private DatosCarrer datos = new DatosCarrer();
        public bool delete(string strIds)
        {
            return datos.eliminarCarreras(strIds);
        }
    }
}
