using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.deletes
{
    public class DeleteGroup
    {
        private DatosGroup datos = new DatosGroup();
        public bool delete(string strIds)
        {
            return datos.eliminarGroups(strIds);
        }
    }
}
