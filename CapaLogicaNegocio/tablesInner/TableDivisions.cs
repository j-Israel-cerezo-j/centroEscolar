using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaLogicaNegocio.tablesInner
{
    public class TableDivisions
    {
        private DatosDivisions datos = new DatosDivisions();
        public DataTable tableDivisionsBymatchingCharacters(string characters)
        {
            return datos.tableDivisionsByMatchingCharacterss(characters);
        }
    }
}
