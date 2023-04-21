using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.updates
{
    public class UpdateTypeClassroom
    {
        private DatosTypeClassrooms datos = new DatosTypeClassrooms();
        public bool update(TypeClassroom typeClassroom)
        {
            return datos.updateTypeClassroom(typeClassroom);
        }
    }
}
