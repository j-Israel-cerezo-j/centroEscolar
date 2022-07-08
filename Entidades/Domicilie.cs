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
        public string estado { get; set; }
        public string municipio { get; set; }
        public string cp { get; set; }
        public string colonia { get; set; }
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
            this.estado = (string)Validation.getValue(renglon, "estado");
            this.municipio = (string)Validation.getValue(renglon, "municipio");
            this.cp = (string)Validation.getValue(renglon, "cp");
            this.colonia = (string)Validation.getValue(renglon, "colonia");
        }
        override
       public string ToString()
        {
            return
                "id:'" + idDomicilio + "', " +
                "calle: '" + calle + "', " +
                "noInterior: '" + noInterior + "', " +
                "estado: '" + estado + "', " +
                "municipio: '" + municipio + "', " +
                "cp: '" + cp + "', " +
                "colonia: '" + colonia + "', " +
                "noExterior: '" + noExterior + "', " +
                "fkAlumno: '" + fkAlumno + "' ";               
        }

    }
}
