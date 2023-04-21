using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.util;
namespace Entidades
{
    public class TypeWorker
    {
        public string typeWorker { get; set; }
        public string descripcion { get; set; }
        public TypeWorker()
        {

        }
        public TypeWorker(SqlDataReader renglon)
        {
            this.typeWorker = (string)Validation.getValue(renglon, "typeWorker");
            this.descripcion = (string)Validation.getValue(renglon, "descripcion");
        }
        override
        public string ToString()
        {
            return
                "typeWorker:'" + typeWorker + "', " +
                "descripcion:'" + descripcion + "'";
        }
    }
}
