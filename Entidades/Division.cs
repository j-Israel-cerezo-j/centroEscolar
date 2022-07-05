using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.util;
namespace Entidades
{
    public class Division
    {
        public int idDivision { get; set; }
        public string nombre { get; set; }
        public int fkIdCarrera { get; set; }
        public Division()
        {

        }
        public Division(SqlDataReader renglon)
        {
            this.idDivision = (int)(Validation.getValue(renglon, "idDivision") ?? 0);
            this.nombre = (string)Validation.getValue(renglon, "nombre");
            this.fkIdCarrera= (int)(Validation.getValue(renglon, "fkIdCarrera") ?? 0);
        }

        override
        public string ToString()
        {
            return
                "id:'" + idDivision + "', " +
                "nombre:'" + nombre + "', " +
                "fkCarrera:'" + fkIdCarrera + "'";
        }
    }
}
