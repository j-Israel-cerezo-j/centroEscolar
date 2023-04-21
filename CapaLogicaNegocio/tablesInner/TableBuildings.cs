using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaLogicaNegocio.tablesInner
{
    public class TableBuildings
    {
        private DatosBuilding datos = new DatosBuilding();
        public DataTable tableBuildingsBymatchingCharacters(string characters)
        {
            return datos.tableBuildingsByMatchingCharacterss(characters);
        }
    }
}
