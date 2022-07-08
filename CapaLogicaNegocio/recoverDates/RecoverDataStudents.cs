using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.recoverDates
{
    public class RecoverDataStudents
    {
        private DatosStudent datos = new DatosStudent();

        public Student recoverData(int id)
        {
            return datos.recoverData(id);
        }
        public Student recoverDataByMatricula(string matricula)
        {
            return datos.recoverDataByMatricula(matricula);
        }
    }
}
