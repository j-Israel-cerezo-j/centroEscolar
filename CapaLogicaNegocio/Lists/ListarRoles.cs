using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Lists
{
    public class ListarRoles
    {
        private DatosRoles datos = new DatosRoles();

        public List<Rol> listarRoles()
        {
            return datos.listarRoles();
        }
    }
}
