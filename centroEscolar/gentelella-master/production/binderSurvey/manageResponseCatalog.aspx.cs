using CapaLogicaNegocio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace centroEscolar.gentelella_master.production.binderSurvey
{
    public partial class manageResponseCatalog : System.Web.UI.Page
    {
        private ResponsesService responsesService = new ResponsesService();
        public string getJsonQuestionsAnswer { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administradorr"] != null)
            {
                jsonQuestionsAnswer();
            }
            else
            {
                Response.Redirect("../index.aspx");

            }

        }
        private void jsonQuestionsAnswer()
        {
            getJsonQuestionsAnswer = responsesService.jsonQuestionsAnswer();
        }
    }
}