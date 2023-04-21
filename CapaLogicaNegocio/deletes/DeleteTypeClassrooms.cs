using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.deletes
{
    public class DeleteTypeClassrooms
    {
        private DatosTypeClassrooms datos = new DatosTypeClassrooms();
        public bool delete(string strIds)
        {
            return datos.eliminarTypeClassrooms(strIds);
        }
    }
}
