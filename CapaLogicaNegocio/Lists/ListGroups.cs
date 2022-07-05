using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Lists
{
    public  class ListGroups
    {
        private DatosGroup datos = new DatosGroup();
        public List<Group> listarGrups()
        {
            return datos.listarGroups();
        }
    }
}
