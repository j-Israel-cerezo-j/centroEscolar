using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.deletes
{
    public class DeleteDomicilie
    {
        private DatosDomicilio datos = new DatosDomicilio();
        public bool delete(int idDomicilie)
        {
            return datos.eliminarDimicilie(idDomicilie);
        }
    }
}
