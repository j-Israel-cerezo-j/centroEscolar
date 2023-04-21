using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;

namespace CapaLogicaNegocio.Lists
{
    public class ListEmployes
    {
        private DatosEmploye datos = new DatosEmploye();
        public List<GeneralEmploye> lisstEmployesGenerales()
        {
            return datos.listEmployesGenerales();
        }
        public List<LocalEmploye> lisstEmployesLocals()
        {
            return datos.listEmployesDivisions();
        }
    }
}
