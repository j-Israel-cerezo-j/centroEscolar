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
    public partial class addUniversityHandler : System.Web.UI.Page
    {
        private UniversityService universityService = new UniversityService();
        public static string getJsonResponse { get; private set; } = "{\"k\":1}";
        protected void Page_Load(object sender, EventArgs e)
        {
            requestAdd();
        }

        private void requestAdd()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            string[] submit = Request.Form.AllKeys;
            var valuesSubmit = getFormAsDictionary(submit);
            try
            {
                var success = universityService.add(valuesSubmit);
                if (success)
                {
                    response.success = success;

                }
                else
                {
                    response.error = "¡Error inesperado en el servidor!.";
                }
            }
            catch (Exception ex)
            {
                response.error = "Error";
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
        private Dictionary<string, string> getFormAsDictionary(string[] submitKeys)
        {
            var values = new Dictionary<string, string>();
            for (int i = 0; i < submitKeys.Length; i++)
            {
                string value = Request.Form[submitKeys[i]];
                values.Add(submitKeys[i], value);
            }
            return values;
        }
    }
}