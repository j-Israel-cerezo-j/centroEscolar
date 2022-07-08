using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.deletes
{
    public class DeleteStudent
    {
        private DatosStudent datos = new DatosStudent();
        public bool delete(string strIds)
        {
            return datos.eliminarStudent(strIds);
        }
        public bool deleteByMatricula(string matricula)
        {
            return datos.eliminarStudentByMatricula(matricula);
        }
    }
}
