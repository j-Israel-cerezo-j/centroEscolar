using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Lists
{
    public class ListPrivileges
    {
        private DatosRolePrivileges datos = new DatosRolePrivileges();
        public List<Privilege> listarPrivilege()
        {
            return datos.listPrivileges();
        }
    }
}
