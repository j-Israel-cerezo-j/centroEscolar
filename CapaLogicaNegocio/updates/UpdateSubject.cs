using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.updates
{
    public class UpdateSubject
    {
        private DatosSubjects datos = new DatosSubjects();
        public bool update(Subject subject)
        {
            return datos.updateSubject(subject);
        }
    }
}
