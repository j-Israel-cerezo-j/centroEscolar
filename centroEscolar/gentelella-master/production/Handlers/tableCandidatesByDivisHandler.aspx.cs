using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
using Entidades;
using Newtonsoft.Json;
using CapaLogicaNegocio.Exceptions;
namespace centroEscolar.gentelella_master.production.Handlers
{
    public partial class tableCandidatesByDivisHandler : System.Web.UI.Page
    {
        private StudentCandidateService studentCandidateService = new StudentCandidateService();
        public string getJsonResponse { get; private set; } = "{\"k\":1}";
        protected void Page_Load(object sender, EventArgs e)
        {
            recoverData();
        }
        private void recoverData()
        {
            Response response = new Response();
            string strId = Request.QueryString["id"];
            if (strId != "")
            {
                try
                {
                    var json = studentCandidateService.jsonCandidatesByIDdiv(strId);
                    if (json != "")
                    {
                        response.success = true;
                        var data = new Dictionary<string, Object>();
                        data.Add("recoverDates", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(json));
                        response.data = data;
                    }                   
                }
                catch (Exception e)
                {
                    response.error = "¡Error inesperado en el servidor!";
                }
            }
            else
            {
                response.error = "Campos vacios";
                response.success = false;
            }
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
    }
}