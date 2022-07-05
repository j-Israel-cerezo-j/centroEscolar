using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.util;

namespace Entidades
{
    public class Period
    {
        public int idPeriodo { get; set; }
        public string nombre { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaTermino { get; set; }
        public Period()
        {

        }
        public Period(SqlDataReader renglon)
        {
            this.idPeriodo = (int)(Validation.getValue(renglon, "idPeriodo") ?? 0);
            this.nombre = (string)Validation.getValue(renglon, "nombre");
            this.fechaInicio = (DateTime)Validation.getValue(renglon, "fechaInicio");
            this.fechaTermino = (DateTime)Validation.getValue(renglon, "fechaTermino");
        }

        override
        public string ToString()
        {
            return
                "id:'" + idPeriodo + "', " +
                "nombre:'" + nombre + "',"+
                "fechaInicio:'" + fechaInicio.ToString("yyyy-MM-dd") + "', " +
                "fechaTermino:'" + fechaTermino.ToString("yyyy-MM-dd") + "'";
        }
    }
}
