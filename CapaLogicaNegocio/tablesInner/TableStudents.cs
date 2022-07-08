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
    public  class TableStudents
    {
        private DatosStudent datosStudent = new DatosStudent();
        public DataTable tableStudents()
        {
            return datosStudent.tableStudents();
        }
        public DataTable tablStudentsByIDdivision(int id)
        {
            return datosStudent.tableStudentsByIdDivision(id);
        }
        public DataTable datasStudent(int idStudent)
        {
            return datosStudent.datasStudentt(idStudent);
        }
    }
}
