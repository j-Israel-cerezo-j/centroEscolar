using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.recoverDates
{
    public class RecoverDataTypeClassroom
    {
        private DatosTypeClassrooms datos = new DatosTypeClassrooms();

        public TypeClassroom recoverData(int id)
        {
            return datos.recoverData(id);
        }
    }
}
