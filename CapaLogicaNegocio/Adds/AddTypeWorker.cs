using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Adds
{
    public class AddTypeWorker
    {
        private DatosTypeWorker datos = new DatosTypeWorker();
        public bool add(TypeWorker typeWorker)
        {
            return datos.add(typeWorker);
        }
    }
}
