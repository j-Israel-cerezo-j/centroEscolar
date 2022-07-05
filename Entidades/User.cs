using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.util;

namespace Entidades
{
    public  class User
    {
        public string matricula { get; set; }
        public string nombre { get; set; }
        public string apellidoP { get; set; }
        public string apellidoM { get; set; }
        public string curp { get; set; }
        public string pass { get; set; }
        public string correoIns { get; set; }
        public string correoP { get; set; }
        public string telefono { get; set; }
        public DateTime fechaNac { get; set; }
        public User()
        {

        }
        public User(SqlDataReader renglon)
        {            
            this.matricula = (string)Validation.getValue(renglon, "matricula");
            this.nombre = (string)Validation.getValue(renglon, "nombres");
            this.apellidoP = (string)Validation.getValue(renglon, "apellidoP");
            this.apellidoM = (string)Validation.getValue(renglon, "apellidoM");
            this.curp = (string)Validation.getValue(renglon, "curp");
            this.pass = (string)Validation.getValue(renglon, "pass");
            this.correoP = (string)Validation.getValue(renglon, "correoP");
            this.correoIns = (string)Validation.getValue(renglon, "correoIns");
            this.telefono = (string)Validation.getValue(renglon, "telefono");
            this.fechaNac = (DateTime)Validation.getValue(renglon, "fechaNac");
        }
    }
}
