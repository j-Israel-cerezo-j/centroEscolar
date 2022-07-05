using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.recoverDates
{
    internal class RecoverDataSubject
    {
        private DatosSubjects datos = new DatosSubjects();

        public Subject recoverData(int id)
        {
            return datos.recoverData(id);
        }
    }
}
