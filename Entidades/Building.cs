using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.util;
namespace Entidades
{
    public class Building
    {
        public int idEdificio { get; set; }
        public string nombre { get; set; }
        public int fkIdCarrera { get; set; }
        public Building()
        {

        }
        public Building(SqlDataReader renglon)
        {
            this.idEdificio = (int)(Validation.getValue(renglon, "idEdificio") ?? 0);
            this.nombre = (string)Validation.getValue(renglon, "nombre");
            this.fkIdCarrera = (int)(Validation.getValue(renglon, "fkIdCarrera") ?? 0);
        }

        override
        public string ToString()
        {
            return
                "id:'" + idEdificio + "', " +
                "nombre:'" + nombre + "', " +
                "fkCarrera:'" + fkIdCarrera + "'";
        }
    }
}
