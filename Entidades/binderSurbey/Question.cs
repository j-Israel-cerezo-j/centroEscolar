using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones.util;

namespace Entidades
{
    public class Question
    {
        public int idQuestion { get; set; }
        public string questions { get; set; }
        public int fkCategoryQuestion { get; set; }
        public Question()
        {

        }
        public Question(SqlDataReader renglon)
        {
            this.idQuestion = (int)(Validation.getValue(renglon, "idQuestion") ?? 0);
            this.questions = (string)Validation.getValue(renglon, "questions");
            this.fkCategoryQuestion = (int)(Validation.getValue(renglon, "fkCategoryQuestion") ?? 0);
        }
        override
        public string ToString()
        {
            return
                "id:'" + idQuestion + "', " +
                 "fkCategoryQuestion:'" + fkCategoryQuestion + "', " +
                "descripcion:'" + questions + "'";
        }
    }
}
