using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using CapaLogicaNegocio.utils;
using CapaDatos;
using System.Data;
using Validaciones.util;
using CapaLogicaNegocio.retrieveAtributesValues;

namespace CapaLogicaNegocio
{
    public class UniversityService
    {
        private UniversityDatos universityDatos= new UniversityDatos();
        public bool add(Dictionary<string, string> request)
        {
            University university = new University();
            university.universidad_nombre = RetrieveAtributes.values(request, "universidad_nombre");
            university.universidad_fecha_fundacion = RetrieveAtributes.values(request, "universidad_fecha_fundacion");
            university.universidad_adscripcion = RetrieveAtributes.values(request, "universidad_adscripcion");
            university.universidad_calle_numero = RetrieveAtributes.values(request, "universidad_calle_numero");
            university.universidad_colonia = RetrieveAtributes.values(request, "universidad_colonia");
            university.universidad_cp = RetrieveAtributes.values(request, "universidad_cp");
            university.universidad_telefono1 = RetrieveAtributes.values(request, "universidad_telefono1");
            university.pagina_web = RetrieveAtributes.values(request, "pagina_web");
            university.email = RetrieveAtributes.values(request, "email");
            university.gmaps_latitud = RetrieveAtributes.values(request, "gmaps_latitud");
            university.gmaps_longitud = RetrieveAtributes.values(request, "gmaps_longitud");
            university.nom_ent = RetrieveAtributes.values(request, "nom_ent");
            university.nom_mun = RetrieveAtributes.values(request, "nom_mun");
            university.nom_loc = RetrieveAtributes.values(request, "nom_loc");
            university.link_sic = RetrieveAtributes.values(request, "link_sic");
            university.fecha_mod = RetrieveAtributes.values(request, "fecha_mod");
            return universityDatos.add(university);
        }
        public List<string> onkeyupSearch(string caracteres)
        {
            caracteres = "%" + caracteres + "%";
            var table = universityDatos.tableUniversitysByMatchingCharacterss(caracteres);
            return ToList(table);

        }
        private List<string> ToList(DataTable table)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    if (!list.Contains(table.Rows[i][j].ToString()))
                    {
                        list.Add(table.Rows[i][j].ToString());
                    }
                }
            }
            return list;
        }
    }
}
