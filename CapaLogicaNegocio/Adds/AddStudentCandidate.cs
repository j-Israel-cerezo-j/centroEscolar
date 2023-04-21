using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;

namespace CapaLogicaNegocio.Adds
{
    public class AddStudentCandidate
    {
        private DatosStudentCandidate datos = new DatosStudentCandidate();
        public bool add(StudentCandidate studentCandidate)
        {
            return datos.add(studentCandidate);
        }
    }
}
