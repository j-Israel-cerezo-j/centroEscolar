using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.updates
{
    public class UpdateCarrer
    {
        private DatosCarrer datos = new DatosCarrer();
        public bool update(Carrer carrer)
        {
            return datos.updateCarrer(carrer);
        }
    }
}
