using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Adds
{
    public class AddTypeClassroom
    {
        private DatosTypeClassrooms datos = new DatosTypeClassrooms();
        public bool add(TypeClassroom typeClassroom)
        {
            return datos.add(typeClassroom);
        }
    }
}
