using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.updates
{
    public class UpdateGroup
    {
        private DatosGroup datos = new DatosGroup();
        public bool update(Group group)
        {
            return datos.updateGroup(group);
        }
    }
}
