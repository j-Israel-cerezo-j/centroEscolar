using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.util;

namespace Entidades
{
    public class Rol
    {
        public int idRol { get; set; }
        public string rol { get; set; }
        public Rol()
        {

        }
        public Rol(SqlDataReader renglon)
        {            
            this.idRol = (int)(Validation.getValue(renglon, "idRol") ?? 0);
            this.rol = (string)Validation.getValue(renglon, "rol");
        }
        override
        public string ToString()
        {
            return 
                "idRol:'" + idRol + "', " +
                "rol:'" + rol+"'";
        }
    }
}
