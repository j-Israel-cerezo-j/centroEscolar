using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Adds
{
    public class AddDomicilie
    {
        private DatosDomicilio datos = new DatosDomicilio();
        public bool add(Domicilie domicilie)
        {
            return datos.add(domicilie);
        }
        public int addAddres(Domicilie domicilie)
        {
            return datos.addAddress(domicilie);
        }
    }
}
