using CapaLogicaNegocio.Services;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace centroEscolar.gentelella_master.production.binderSurvey
{
    public partial class Encuesta : System.Web.UI.Page
    {
        private SurveysService surveysService = new SurveysService();
        public List<Question> getQuestionsList { get; set; }
        public List<University> getUniversitysList { get; set; }
        public string getJsonQuestions { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Encuestado"] != null|| Session["Administradorr"] != null)
            {
                questionsList();
                jsonQuestions();
                listUniversityss();
            }
            else
            {
                Response.Redirect("../index.aspx");
            }
           
        }
        private void questionsList()
        {
            getQuestionsList = surveysService.questionsList();
        }
        private void jsonQuestions()
        {
            getJsonQuestions = surveysService.jsonQuestions();
        }
        private void listUniversityss()
        {
            getUniversitysList = surveysService.listUniversityss();
        }
    }
}