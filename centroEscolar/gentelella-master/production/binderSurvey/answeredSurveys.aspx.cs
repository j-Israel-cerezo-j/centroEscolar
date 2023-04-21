using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
using CapaLogicaNegocio.Services;

namespace centroEscolar.gentelella_master.production.binderSurvey
{
    public partial class answeredSurveys : System.Web.UI.Page
    {
        private SurveysService surveysService = new SurveysService();
        public string getJsonTableAnsweredSurveys { get; set; }
        public int getCountAnsweredSurveys { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Encuestador"] != null || Session["Administradorr"] != null)
            {
                countAnsweredServeys();
                buildTableAnsweredSurveys();
            }
            else
            {
                Response.Redirect("../index.aspx");
            }

        }
        private void buildTableAnsweredSurveys()
        {
            getJsonTableAnsweredSurveys = surveysService.jsonTableAnsweredSurveys();
        }
        private void countAnsweredServeys()
        {
            getCountAnsweredSurveys = surveysService.countAnsweredServeyss();
        }
    }
}