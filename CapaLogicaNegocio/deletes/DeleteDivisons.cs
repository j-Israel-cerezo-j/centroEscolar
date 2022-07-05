using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.deletes
{
    public class DeleteDivisons
    {
        private DatosDivisions datos = new DatosDivisions();
        public bool delete(string strIds)
        {
            return datos.eliminarDivisions(strIds);
        }
    }
}
