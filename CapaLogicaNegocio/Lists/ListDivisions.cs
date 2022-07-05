using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Lists
{
    public class ListDivisions
    {
        private DatosDivisions datos = new DatosDivisions();
        public List<Division> listarDivisions()
        {
            return datos.listarDivision();
        }
        public List<Division> listarDivisionsXcarrer(int id)
        {
            return datos.listarDivisionesXidCarrer(id);
        }
    }
}
