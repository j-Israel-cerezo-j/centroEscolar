using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones.util;

namespace Entidades
{
    public class UserSurvey
    {
        public int id { get; set; }    
        public string nombres { get; set; }
        public string apellidoP { get; set; }
        public string apellidoM { get; set; }       
        public string email { get; set; }
        public UserSurvey()
        {

        }
        public UserSurvey(SqlDataReader renglon)
        {
            this.id = (int)(Validation.getValue(renglon, "id") ?? 0);            
            this.nombres = (string)(Validation.getValue(renglon, "nombres")) ?? "";
            this.apellidoP = (string)(Validation.getValue(renglon, "apellidoP")) ?? "";
            this.apellidoM = (string)(Validation.getValue(renglon, "apellidoM")) ?? "";            
            this.email = (string)(Validation.getValue(renglon, "email")) ?? "";
           
        }
        override
        public string ToString()
        {
            return
                "id:'" + id + "', " +
                "nombres: '" + nombres + "', " +
                "apellidoP: '" + apellidoP + "', " +
                "apellidoM: '" + apellidoM + "', " +
                "email: '" + email + "'";
        }
    }
}
