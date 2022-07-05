using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.util;

namespace Entidades
{
    public class StudentCandidate : User
    {
        public int idCandidato { get; set; }            
        public int fkIdDivision { get; set; }
        public StudentCandidate()
        {

        }
        public StudentCandidate(SqlDataReader renglon):base(renglon)
        {
            this.idCandidato = (int)(Validation.getValue(renglon, "idCandidato") ?? 0);            
            this.fkIdDivision = (int)(Validation.getValue(renglon, "fkIdDivision") ?? 0);
        }

        override
        public string ToString()
        {
            return
               "id:'" + idCandidato + "', " +
               "matricula: '" + matricula + "', " +
               "nombres: '" + nombre + "', " +
               "apellidoP: '" + apellidoP + "', " +
               "apellidoM: '" + apellidoM + "', " +
               "curp: '" + curp + "', " +
               "pass: '" + pass + "', " +
               "correoP: '" + correoP + "', " +
               "correoIns: '" + correoIns + "', " +
               "fechaNac: '" + fechaNac.ToString("yyyy-MM-dd") + "', " +               
               "fkIdDivision: '" + fkIdDivision.ToString() + "', " +
               "telefono: '" + telefono + "'";
        }
        public string toString()
        {
            return
                idCandidato + "," +
                matricula + "," +
                nombre + "," +
                apellidoP + "," +
                apellidoM + "," +
                curp + "," +
                pass + "," +
                correoP + "," +
                correoIns + "," +
                fechaNac.ToString("yyyy-MM-dd") + "," +
                fkIdDivision + "," +
                telefono + "'";

        }

    }
}
