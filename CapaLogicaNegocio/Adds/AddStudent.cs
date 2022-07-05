using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;

namespace CapaLogicaNegocio.Adds
{
    public class AddStudent
    {
        private DatosStudent datosStudent = new DatosStudent();
        public bool add(Student student)
        {
            return datosStudent.add(student);
        }
    }
}
