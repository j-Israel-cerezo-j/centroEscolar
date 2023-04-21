using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;

namespace CapaLogicaNegocio.recoverDates
{
    public  class RecoverDataRoles
    {
        private DatosRoles datos = new DatosRoles();

        public Rol recoverData(int id)
        {
            return datos.recoverData(id);
        }
        public DataTable roleByTypeWorker(Dictionary<string, string> campos, string table)
        {
            FindFrom findBy = new FindFrom("centroEscolar");
            return findBy.findFromAll(campos, table);
        }
    }
}
