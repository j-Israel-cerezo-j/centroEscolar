using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones.util;

namespace Entidades
{
    public class University
    {
        public int universidad_id { get; set; }
        public string universidad_nombre { get; set; }
        public string universidad_fecha_fundacion { get; set; }
        public string universidad_adscripcion { get; set; }
        public string universidad_calle_numero { get; set; }
        public string universidad_colonia { get; set; }
        public string universidad_cp { get; set; }
        public string universidad_telefono1 { get; set; }
        public string pagina_web { get; set; }
        public string email { get; set; }
        public string gmaps_latitud { get; set; }
        public string gmaps_longitud { get; set; }
        public string nom_ent { get; set; }
        public string nom_mun { get; set; }
        public string nom_loc { get; set; }
        public string link_sic { get; set; }
        public string fecha_mod { get; set; }

        public University()
        {
            
        }

        public University(SqlDataReader renglon)
        {
            this.universidad_id = (int)(Validation.getValue(renglon, "universidad_id") ?? 0);
            this.universidad_nombre = (string)Validation.getValue(renglon, "universidad_nombre");
            this.universidad_fecha_fundacion = (string)Validation.getValue(renglon, "universidad_fecha_fundacion");
            this.universidad_adscripcion = (string)Validation.getValue(renglon, "universidad_adscripcion");
            this.universidad_calle_numero = (string)Validation.getValue(renglon, "universidad_calle_numero");
            this.universidad_colonia = (string)Validation.getValue(renglon, "universidad_colonia");
            this.universidad_cp = (string)Validation.getValue(renglon, "universidad_cp");
            this.universidad_telefono1 = (string)Validation.getValue(renglon, "universidad_telefono1");
            this.pagina_web = (string)Validation.getValue(renglon, "pagina_web");
            this.email = (string)Validation.getValue(renglon, "email");
            this.gmaps_latitud = (string)Validation.getValue(renglon, "gmaps_latitud");
            this.gmaps_longitud = (string)Validation.getValue(renglon, "gmaps_longitud");
            this.nom_ent = (string)Validation.getValue(renglon, "nom_ent");
            this.nom_mun = (string)Validation.getValue(renglon, "nom_mun");
            this.nom_loc = (string)Validation.getValue(renglon, "nom_loc");
            this.link_sic = (string)Validation.getValue(renglon, "link_sic");
        }
    }
}
