using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.deletes
{
    public class DeleteRol
    {
        private DatosRoles datos = new DatosRoles();
        public bool delete(string strIds)
        {
            return datos.eliminarRoles(strIds);
        }
    }
}
