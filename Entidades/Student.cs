using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.util;

namespace Entidades
{
    public class Student : User
    {
        public int idAlumno { get; set; }      
        public int fkIdDivision { get; set; }
        public int fkIdGrupo { get; set; }        
        public Student()
        {

        }
        public Student(SqlDataReader renglon) : base(renglon)
        {            
            this.idAlumno = (int)(Validation.getValue(renglon, "idAlumno") ?? 0);          
            this.fkIdDivision = (int)(Validation.getValue(renglon, "fkIdDivision") ?? 0);
            this.fkIdGrupo = (int)(Validation.getValue(renglon, "fkIdGrupo") ?? 0);
        }
        override
        public string ToString()
        {
            return
                "id:'" + idAlumno + "', " +
                "matricula: '" + matricula + "', " +
                "nombres: '" + nombres + "', " +
                "apellidoP: '" + apellidoP + "', " +
                "apellidoM: '" + apellidoM + "', " +
                "curp: '" + curp + "', " +
                "pass: '" + pass + "', " +
                "correoP: '" + correoP + "', " +
                "correoIns: '" + correoIns + "', " +
                "fechaNac: '" + fechaNac.ToString("yyyy-MM-dd") + "', " +
                "fkIdGrupo: '" + fkIdGrupo.ToString() + "', " +
                "fkIdDivision: '" + fkIdDivision.ToString() + "', " +
                "telefono: '" + telefono + "'";
        }
        public string toString()
        {
            return
                idAlumno + "," +
                matricula + "," +
                nombres + "," +
                apellidoP + "," +
                apellidoM + "," +
                curp + "," +
                pass + "," +
                correoP + "," +
                correoIns + "," +
                fechaNac.ToString("yyyy-MM-dd") + "," +
                fkIdDivision + "," +
                fkIdGrupo + "," +
                telefono + "'";

        }
    }
}
