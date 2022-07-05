using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.util;

namespace Entidades
{
    public class Carrer
    {
        public int idCarrera { get; set; }
        public string nombre { get; set; }
        public Carrer()
        {

        }
        public Carrer(SqlDataReader renglon)
        {
            this.idCarrera = (int)(Validation.getValue(renglon, "idCarrera") ?? 0);
            this.nombre = (string)Validation.getValue(renglon, "nombre");
        }
        override
        public string ToString()
        {
            return
                "id:'" + idCarrera + "', " +
                "nombre:'" + nombre + "'";
        }
    }
}
