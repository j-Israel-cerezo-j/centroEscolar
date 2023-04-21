using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Lists
{
    public class ListTypesWorkers
    {
        private DatosTypeWorker datos = new DatosTypeWorker();
        public List<TypeWorker> listar()
        {
            return datos.listarTypesWorkers();
        }
    }
}
