using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;

namespace CapaLogicaNegocio.updates
{
    public class UpdateStudent
    {
        private DatosStudent datos = new DatosStudent();
        public bool update(Student student)
        {
            return datos.updateStudent(student);
        }
    }
}
