using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.updates
{
    public class UpdateLevel
    {
        private DatosLevel datos = new DatosLevel();
        public bool update(Level level)
        {
            return datos.updateLevel(level);
        }
    }
}
