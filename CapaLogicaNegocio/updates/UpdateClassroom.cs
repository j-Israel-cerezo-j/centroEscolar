using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.updates
{
    public class UpdateClassroom
    {
        private DatosClassroom datos = new DatosClassroom();
        public bool update(Classroom classroom)
        {
            return datos.updateClassroom(classroom);
        }
    }
}
