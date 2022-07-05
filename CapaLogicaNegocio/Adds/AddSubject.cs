using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;

namespace CapaLogicaNegocio.Adds
{
    public class AddSubject
    {
        private DatosSubjects datos = new DatosSubjects();
        public bool add(Subject subject)
        {
            return datos.add(subject);
        }
    }
}
