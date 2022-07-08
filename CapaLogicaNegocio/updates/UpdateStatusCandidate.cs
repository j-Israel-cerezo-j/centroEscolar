using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.updates
{
    public class UpdateStatusCandidate
    {
        private DatosStatusCandidate datos = new DatosStatusCandidate();
        public StudentCandidate update(StudentCandidate candidate)
        {
            return datos.updateStatusCandidate(candidate);
        }
    }
}
