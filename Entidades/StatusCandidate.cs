using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.util;
namespace Entidades
{
    public class StatusCandidate
    {
        public string statusPk { get; set; }
        public string descripcion { get; set; }        
        public StatusCandidate()
        {

        }
        public StatusCandidate(SqlDataReader renglon)
        {
            this.statusPk = (string)Validation.getValue(renglon, "statusPk");
            this.descripcion = (string)Validation.getValue(renglon, "descripcion");
        }
        override
        public string ToString()
        {
            return
             "id:'" + statusPk + "', " +
             "descripcion: '" + descripcion + "' ";             
        }
    }
}
