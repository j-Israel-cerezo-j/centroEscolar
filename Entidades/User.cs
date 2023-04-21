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
        public int id { get; set; }
        public string matricula { get; set; }
        public string nombres { get; set; }
        public string apellidoP { get; set; }
        public string apellidoM { get; set; }
        public string curp { get; set; }
        public string pass { get; set; }
        public string correoIns { get; set; }
        public string correoP { get; set; }
        public string telefono { get; set; }
        public DateTime fechaNac { get; set; }
        public int fkAddress { get; set; }
        public string typeUser { get; set; }
        public string image { get; set; }
        public string nameCookie { get; set; }
        public string fkStatusUser { get; set; }
        public string fileName { get; set; }
        public User()
        {

        }
        public User(SqlDataReader renglon)
        {
            this.id = (int)(Validation.getValue(renglon, "id") ?? 0);
            this.matricula = (string)(Validation.getValue(renglon, "matricula"))??"";
            this.nombres = (string)(Validation.getValue(renglon, "nombres")) ?? "";
            this.apellidoP = (string)(Validation.getValue(renglon, "apellidoP")) ?? "";
            this.apellidoM = (string)(Validation.getValue(renglon, "apellidoM")) ?? "";
            this.curp = (string)(Validation.getValue(renglon, "curp")) ?? "";
            this.pass = (string)(Validation.getValue(renglon, "pass")) ?? "";
            this.correoP = (string)(Validation.getValue(renglon, "correoP")) ?? "";
            this.correoIns = (string)(Validation.getValue(renglon, "correoIns")) ?? "";
            this.telefono = (string)(Validation.getValue(renglon, "telefono"))??"";
            this.fechaNac = (DateTime)(Validation.getValue(renglon, "fechaNac")?? new DateTime());
            this.fkAddress = (int)(Validation.getValue(renglon, "fkAddress") ?? 0);
            this.image = (string)(Validation.getValue(renglon, "image")) ?? "";
            this.fileName = (string)(Validation.getValue(renglon, "fileName")) ?? "";
            this.fkStatusUser = (string)(Validation.getValue(renglon, "fkStatusUser")) ?? "";
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
                "correoP: '" + correoP + "', " +
                "correoIns: '" + correoIns + "', " +
                "fkDomicilio: '" + fkAddress + "', " +
                "imagen: '" + image + "', " +
                "c: '" + nameCookie+ "', " +
                "statusUser: '" + fkStatusUser + "', " +
                "telefono: '" + telefono + "'";
        }
    }
}
