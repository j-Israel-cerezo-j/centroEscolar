using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
using System.Data;
using System.Data.SqlClient;
namespace CapaLogicaNegocio.Lists
{
    public class ListCadidates
    {
        private DatosStudentCandidate datosStudent = new DatosStudentCandidate();
        public DataTable tableCandidates()
        {
            return datosStudent.tableCandidatesStudents();
        }
    }
}
