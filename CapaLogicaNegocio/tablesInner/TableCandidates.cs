using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
using System.Data;
using System.Data.SqlClient;
namespace CapaLogicaNegocio.tablesInner
{
    public class TableCandidates
    {
        private DatosStudentCandidate datosStudent = new DatosStudentCandidate();
        public DataTable tableCandidates()
        {
            return datosStudent.tableCandidatesStudents();
        }
        public DataTable tableCandidatesByIDdivision(int id)
        {
            return datosStudent.tableCandidatesStudentsByIdDivision(id);
        }
        public DataTable tableCandidatesBymatchingCharacters(string characters)
        {
            return datosStudent.tableCandidatesStudentsByMatchingCharacterss(characters);
        }
    }
}
