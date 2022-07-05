using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.util;

namespace Entidades
{
    public class Level
    {
        public int idCuatrimestre { get; set; }
        public string nombre { get; set; }
        public Level()
        {

        }
        public Level(SqlDataReader renglon)
        {
            this.idCuatrimestre = (int)(Validation.getValue(renglon, "idCuatrimestre") ?? 0);
            this.nombre = (string)Validation.getValue(renglon, "nombre");
        }
        override
        public string ToString()
        {
            return
                "id:'" + idCuatrimestre + "', " +
                "nombre:'" + nombre + "'";
        }
    }
}
