using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.recoverDates
{
    public  class RecoverDataStudenCandidate
    {
        private DatosStatusCandidate datos = new DatosStatusCandidate();

        public StudentCandidate recoverDataS(int id)
        {
            return datos.recoverData(id);
        }
    }
}
