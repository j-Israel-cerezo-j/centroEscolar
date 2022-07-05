using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Lists
{
    public class ListarAlumnos
    {
        private DatosStudent datosStudent = new DatosStudent();
        public List<Student> listarAlumnos()
        {
           return datosStudent.listarStudents();
        }
    }
}
