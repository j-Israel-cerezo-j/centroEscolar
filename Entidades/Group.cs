using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.util;

namespace Entidades
{
    public class Group
    {
        public int idGrupo { get; set; }
        public string nombre { get; set; }
        public Group()
        {

        }
        public Group(SqlDataReader renglon)
        {
            this.idGrupo = (int)(Validation.getValue(renglon, "idGrupo") ?? 0);
            this.nombre = (string)Validation.getValue(renglon, "nombre");
        }
        override
        public string ToString()
        {
            return
                "id:'" + idGrupo + "', " +
                "nombre:'" + nombre + "'";
        }
    }
}
