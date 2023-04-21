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
    public class RecoverDataEmploye
    {
        private DatosEmploye datos = new DatosEmploye();

        public LocalEmploye recoverData(int id)
        {
            return datos.recoverData(id);
        }
        public DataTable finFromAllWhere(Dictionary<string, string> camposWhere, string table)
        {
            FindFrom findBy = new FindFrom("centroEscolar");
            return findBy.findFromAll(camposWhere, table);
        }
    }
}
