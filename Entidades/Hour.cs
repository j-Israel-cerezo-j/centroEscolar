using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.util;
namespace Entidades
{
    public class Hour
    {
        public int idHorario { get; set; }        
        public DateTime horaInicio { get; set; }
        public DateTime horaFinal { get; set; }
        public Hour()
        {

        }
        public Hour(SqlDataReader renglon)
        {
            this.idHorario = (int)(Validation.getValue(renglon, "idHorario") ?? 0);            
            this.horaInicio = (DateTime)Validation.getValue(renglon, "horaInicio");
            this.horaFinal = (DateTime)Validation.getValue(renglon, "horaFinal");
        }

        override
        public string ToString()
        {
            return
                "id:'" + idHorario + "', " +                
                "horaInicio:'" + horaInicio.ToString("HH:MM") + "', " +
                "horaTermino:'" + horaFinal.ToString("HH:MM") + "'";
        }
    }
}
