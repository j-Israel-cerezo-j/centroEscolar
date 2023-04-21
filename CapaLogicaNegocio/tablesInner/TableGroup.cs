using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CapaLogicaNegocio.tablesInner
{
    public class TableGroup
    {
        private DatosGroup datos = new DatosGroup();
        public DataTable tableGroupss()
        {
            return datos.tableGroups();
        }
    }
}
