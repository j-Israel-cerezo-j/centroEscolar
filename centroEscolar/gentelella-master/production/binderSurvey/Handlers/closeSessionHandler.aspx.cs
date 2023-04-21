using CapaLogicaNegocio;
using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace centroEscolar.gentelella_master.production.binderSurvey.Handlers
{
    public partial class closeSessionHandler : System.Web.UI.Page
    {
        public static string getJsonResponse { get; private set; } = "{\"k\":1}";
        protected void Page_Load(object sender, EventArgs e)
        {
            sessionClose();
        }
        private void sessionClose()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();            
            try
            {
                response.success = true;

                Session.Clear();
                Session.Abandon();
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