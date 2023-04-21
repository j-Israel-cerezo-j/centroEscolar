using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.util;
namespace Entidades
{
    public class Privilege
    {
        public int id { get; set; }
        public string descripcion { get; set; }

        public Privilege()
        {

        }
        public Privilege(SqlDataReader renglon)
        {
            this.id = (int)(Validation.getValue(renglon, "id") ?? 0);
            this.descripcion = (string)Validation.getValue(renglon, "descripcion");
        }
        override
        public string ToString()
        {
            return
                "id:'" + id + "', " +
                "descripcion:'" + descripcion + "'";
        }
    }
}
