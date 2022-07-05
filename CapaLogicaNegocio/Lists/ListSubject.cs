using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Lists
{
    public class ListSubject
    {
        private DatosSubjects datos = new DatosSubjects();

        public List<Subject> listar()
        {
            return datos.listarSunjects();
        }
    }
}
