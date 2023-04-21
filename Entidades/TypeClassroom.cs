using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.util;

namespace Entidades
{
    public class TypeClassroom
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public TypeClassroom()
        {

        }
        public TypeClassroom(SqlDataReader renglon)
        {
            this.id = (int)(Validation.getValue(renglon, "id") ?? 0);
            this.nombre = (string)Validation.getValue(renglon, "nombre");
        }
        override
        public string ToString()
        {
            return
                "id:'" + id + "', " +
                "nombre:'" + nombre + "'";
        }
    }
}
