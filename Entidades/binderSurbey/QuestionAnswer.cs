using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones.util;
namespace Entidades
{
    public class QuestionAnswer
    {
        public int idResponse { get; set; }
        public string descripcion { get; set; }
        public QuestionAnswer()
        {

        }
        public QuestionAnswer(SqlDataReader renglon)
        {
            this.idResponse = (int)(Validation.getValue(renglon, "idResponse") ?? 0);
            this.descripcion = (string)Validation.getValue(renglon, "descripcion");
        }
        override
        public string ToString()
        {
            return
                "id:'" + idResponse + "', " +
                "descripcion:'" + descripcion + "'";
        }
    }
}
