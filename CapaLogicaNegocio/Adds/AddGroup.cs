using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Adds
{
    public class AddGroup
    {
        private DatosGroup datos = new DatosGroup();
        public bool add(Group group)
        {
            return datos.add(group);
        }
    }
}
