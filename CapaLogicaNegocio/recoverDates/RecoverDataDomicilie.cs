using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.recoverDates
{
    public class RecoverDataDomicilie
    {
        private DatosDomicilio datos = new DatosDomicilio();

        public Domicilie recoverData(int id)
        {
            return datos.recoverData(id);
        }
        public Domicilie recoverDataAddress(int id)
        {
            return datos.recoverDataAddress(id);
        }
    }
}
