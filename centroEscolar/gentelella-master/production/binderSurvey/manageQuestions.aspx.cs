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
    public partial class manageQuestions : System.Web.UI.Page
    {
        private QuestionsService questionsService = new QuestionsService();
        public List<CategoryQuestion> getQuestiosCategoryList { get; set; }
        public List<QuestionAnswer> getQuestionsAnswerList { get; set; }
        public string getJsonQuestionsTable { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if ( Session["Administradorr"] != null)
            {
                questiosCategory();
                listQuestionsAnswer();
                questionsTable();
            }
            else
            {
                Response.Redirect("../index.aspx");
            }

        }
        private void questiosCategory()
        {
            getQuestiosCategoryList = questionsService.questionsCategoruyList();
        }
        private void listQuestionsAnswer()
        {
            getQuestionsAnswerList = questionsService.questionsAnswerList();
        }
        public void questionsTable()
        {
            getJsonQuestionsTable = questionsService.jsonQuestions();
        }
    }
}