using CapaLogicaNegocio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace centroEscolar.gentelella_master.production.binderSurvey
{
    public partial class manageCatalogOfQuestionCategories : System.Web.UI.Page
    {
        private QuestionCategoryService questionCategoryService = new QuestionCategoryService();
        public string getJsonQuestionsCategory { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administradorr"] != null)
            {
                jsonQuestionsCategoruy();
            }
            else
            {
                Response.Redirect("../index.aspx");
            }
           
        }
        private void jsonQuestionsCategoruy()
        {
            getJsonQuestionsCategory = questionCategoryService.jsonQuestionsCategoruy();
        }
    }
}