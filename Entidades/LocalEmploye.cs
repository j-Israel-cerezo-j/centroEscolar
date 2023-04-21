using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.util;

namespace Entidades
{
    public class LocalEmploye : User
    {        
        public LocalEmploye()
        {

        }
        public LocalEmploye(SqlDataReader renglon) : base(renglon)
        {
            
        }
        override
        public string ToString()
        {
            return
                "id:'" + id + "', " +
                "matricula: '" + matricula + "', " +
                "nombres: '" + nombres + "', " +
                "apellidoP: '" + apellidoP + "', " +
                "apellidoM: '" + apellidoM + "', " +
                "curp: '" + curp + "', " +
                "pass: '" + pass + "', " +
                "correoP: '" + correoP + "', " +
                "correoIns: '" + correoIns + "', " +
                "fkDomicilio: '" + fkAddress + "', " +
                "fechaNac: '" + fechaNac.ToString("yyyy-MM-dd") + "', " +
                "telefono: '" + telefono + "'";
        }
        public string toString()
        {
            return
                id + "," +
                matricula + "," +
                nombres + "," +
                apellidoP + "," +
                apellidoM + "," +
                curp + "," +
                pass + "," +
                correoP + "," +
                correoIns + "," +
                fkAddress + "," +
                fechaNac.ToString("yyyy-MM-dd") + "," +
                telefono + "'";

        }
    }
}
