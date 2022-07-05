using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.deletes
{
    public class DeleteSubject
    {
        private DatosSubjects datos = new DatosSubjects();
        public bool delete(string strIds)
        {
            return datos.eliminarSubjects(strIds);
        }
    }
}
