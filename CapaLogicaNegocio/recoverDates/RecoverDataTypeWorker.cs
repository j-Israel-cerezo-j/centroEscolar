using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.recoverDates
{
    public class RecoverDataTypeWorker
    {
        private DatosTypeWorker datos = new DatosTypeWorker();
        public TypeWorker recoverData(string strtypeWorker)
        {
            return datos.recoverData(strtypeWorker);
        }      
    }
}
