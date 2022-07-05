using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Adds
{
    public class AddCarrer
    {
        private DatosCarrer datos = new DatosCarrer();
        public bool add(Carrer carrer)
        {
            return datos.add(carrer);
        }
    }
}
