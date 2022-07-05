using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Adds
{
    public class AddRol
    {
        private DatosRoles datos = new DatosRoles();
        public bool add(Rol rol)
        {
            
            return datos.addRol(rol);

        }
    }
}
