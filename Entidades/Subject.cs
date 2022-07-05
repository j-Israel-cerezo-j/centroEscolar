using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.util;

namespace Entidades
{
    public  class Subject
    {
        public int idMateria { get; set; }
        public string nombre { get; set; }
        public Subject()
        {

        }
        public Subject(SqlDataReader renglon)
        {
            this.idMateria = (int)(Validation.getValue(renglon, "idMateria") ?? 0);
            this.nombre = (string)Validation.getValue(renglon, "nombre");
        }
        override
        public string ToString()
        {
            return
                "id:'" + idMateria + "', " +
                "nombre:'" + nombre + "'";
        }
    }
}
