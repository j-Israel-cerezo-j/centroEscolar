using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.util;
namespace Entidades
{
    public class Domicilie
    {
        public int idDomicilio { get; set; }
        public string calle { get; set; }
        public string noInterior { get; set; }
        public string noExterior { get; set; }
        public int fkAlumno { get; set; }
        public Domicilie()
        {

        }
        public Domicilie(SqlDataReader renglon)
        {
            this.idDomicilio = (int)(Validation.getValue(renglon, "idDomicilio") ?? 0);
            this.calle = (string)Validation.getValue(renglon, "calle");
            this.noInterior = (string)Validation.getValue(renglon, "noInterior");
            this.noExterior = (string)Validation.getValue(renglon, "noExterior");
            this.fkAlumno = (int)(Validation.getValue(renglon, "fkAlumno") ?? 0);
        }
        override
       public string ToString()
        {
            return
               "id:'" + idDomicilio + "', " +
               "calle: '" + calle + "', " +
               "noInterior: '" + noInterior + "', " +
               "noInterior: '" + noInterior + "', " +
               "fkAlumno: '" + fkAlumno + "' ";               
        }

    }
}
