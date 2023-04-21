using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Adds
{
    public class AddClassroom
    {
        private DatosClassroom datos = new DatosClassroom();
        public bool add(Classroom classroom)
        {
            return datos.add(classroom);
        }
    }
}
