using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.recoverDates
{
    public class RecoverDataClassroom
    {
        private DatosClassroom datos = new DatosClassroom();

        public Classroom recoverData(int id)
        {
            return datos.recoverData(id);
        }
    }
}
