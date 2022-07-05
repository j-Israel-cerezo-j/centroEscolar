using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Lists
{
    public class ListPeriod
    {
        private DatosPeriod datos = new DatosPeriod();

        public List<Period> listar()
        {
            return datos.listarPeriods();
        }
    }
}
