using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.updates
{
    internal class UpdateDivision
    {
        private DatosDivisions datos = new DatosDivisions();
        public bool update(Division division)
        {
            return datos.updateDivision(division);
        }
    }
}
