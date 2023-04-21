using CapaLogicaNegocio;
using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace centroEscolar.gentelella_master.production.Handlers.binderSurvey
{
    public partial class OnkeyupSearchUniversityHandler : System.Web.UI.Page
    {
        private UniversityService universityService = new UniversityService();
        public static string getJsonResponse { get; private set; } = "{\"k\":1}";
        protected void Page_Load(object sender, EventArgs e)
        {
            onkeyupSearch();
        }
        private void onkeyupSearch()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            string caracteresDeBusqueda = Request.Form["onkeyupSerchUniversity"];
            try
            {
                var coincidencias = universityService.onkeyupSearch(caracteresDeBusqueda);
                if (coincidencias.Count > 0)
                {
                    response.success = true;
                    data.Add("coincidencias", coincidencias);
                }
                else
                {
                    data.Add("accion", "sinCoincidencias");
                    response.success = true;
                }
            }
            catch (Exception e)
            {
                response.error = "Error";
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
    }
}