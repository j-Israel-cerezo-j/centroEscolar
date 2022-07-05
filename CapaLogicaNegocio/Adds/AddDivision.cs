using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Adds
{
    public class AddDivision
    {
        private DatosDivisions datos = new DatosDivisions();
        public bool add(Division division)
        {
            return datos.add(division);
        }
    }
}
