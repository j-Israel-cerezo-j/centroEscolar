using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.deletes
{
    public class DeleteTypeWorker
    {
        private DatosTypeWorker datos = new DatosTypeWorker();
        public bool delete(string strIds)
        {
            return datos.eliminarTypeWorkers(strIds);
        }
    }
}
