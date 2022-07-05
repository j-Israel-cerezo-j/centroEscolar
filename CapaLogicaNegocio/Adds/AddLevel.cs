using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Adds
{
    public class AddLevel
    {
        private DatosLevel datos = new DatosLevel();
        public bool add(Level level)
        {
            return datos.add(level);
        }
    }
}
