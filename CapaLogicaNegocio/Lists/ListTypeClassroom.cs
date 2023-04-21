using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Lists
{
    public class ListTypeClassroom
    {
        private DatosTypeClassrooms datos = new DatosTypeClassrooms();
        public List<TypeClassroom> listarTypeClassroom()
        {
            return datos.listarTypeClassroom();
        }
    }
}
