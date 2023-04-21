using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones.util;

namespace Entidades
{
    public  class CategoryQuestion
    {
        public int idCategory { get; set; }
        public string descripcion { get; set; }
        public CategoryQuestion()
        {

        }
        public CategoryQuestion(SqlDataReader renglon)
        {
            this.idCategory = (int)(Validation.getValue(renglon, "idCategory") ?? 0);
            this.descripcion = (string)Validation.getValue(renglon, "descripcion");
        }
        override
        public string ToString()
        {
            return
                "id:'" + idCategory + "', " +
                "descripcion:'" + descripcion + "'";
        }
    }
}
