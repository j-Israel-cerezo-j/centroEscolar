using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;

namespace CapaLogicaNegocio.updates
{
    public class UpdateRol
    {
        private DatosRoles datos = new DatosRoles();
        public bool update(Rol rol)
        {
            return datos.updateRol(rol);
        }
    }
}
