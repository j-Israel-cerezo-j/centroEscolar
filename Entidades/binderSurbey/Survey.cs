using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones.util;

namespace Entidades
{
    public class Survey
    {
        public int id { get; set; }
        public int fkUser { get; set; }
        public int fkUniversity { get; set; }
        public Survey()
        {

        }
        public Survey(SqlDataReader renglon)
        {
            this.id = (int)(Validation.getValue(renglon, "idQuestion") ?? 0);
            this.fkUniversity= (int)(Validation.getValue(renglon, "fkUniversity") ?? 0);
            this.fkUser= (int)(Validation.getValue(renglon, "fkUser") ?? 0);
        }
        override
        public string ToString()
        {
            return
                "id:'" + id + "', " +
                 "fkUser:'" + fkUser + "', " +
                "fkUniversity:'" + fkUniversity + "'";
        }
    }
}
