using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.util;
namespace Entidades
{
    public class Classroom
    {
        public int idSalon { get; set; }
        public string clave { get; set; }
        public int cupo { get; set; }
        public int fkTipoSalon { get; set; }
        public int fkEdificio { get; set; }
        public Classroom()
        {

        }
        public Classroom(SqlDataReader renglon)
        {
            this.idSalon = (int)(Validation.getValue(renglon, "idSalon") ?? 0);
            this.clave = (string)Validation.getValue(renglon, "clave");
            this.cupo = (int)(Validation.getValue(renglon, "cupo") ?? 0);
            this.fkEdificio = (int)(Validation.getValue(renglon, "fkEdificio") ?? 0);
            this.fkTipoSalon = (int)(Validation.getValue(renglon, "fkTipoSalon") ?? 0);
        }

        override
        public string ToString()
        {
            return
                "id:'" + idSalon + "', " +
                "clave:'" + clave + "', " +
                "cupo:'" + cupo + "', " +
                "fkEdificio:'" + fkEdificio + "', " +
                "fkTipoSalon:'" + fkTipoSalon + "'";
        }
    }
}
