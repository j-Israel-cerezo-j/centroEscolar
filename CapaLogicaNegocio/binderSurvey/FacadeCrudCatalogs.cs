using CapaLogicaNegocio.Services;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CapaLogicaNegocio
{
    public class FacadeCrudCatalogs
    {
        private QuestionsService questionsService=new QuestionsService();
        private ResponsesService responsesService=new ResponsesService();
        private QuestionCategoryService questionCategoryService=new QuestionCategoryService();
        private SurveysService surveysService=new SurveysService();
        public bool ajaxRequestCatalogosAdd(string catalogo, Dictionary<string, string> submit)
        {

            bool ban = false;
            switch (catalogo)
            {
                case "questionsAnswer":
                    ban = responsesService.addResponse(submit);
                    break;
                case "questionsCategory":
                    ban = questionCategoryService.addCategory(submit);
                    break;
                case "questions":
                    ban = questionsService.addQuestion(submit);
                    break;
                case "encuesta":
                    ban = surveysService.addSurvey(submit);
                    break;

                    
            }
            return ban;
        }
        public bool ajaxRequestUpdate(string catalogo, Dictionary<string, string> submit, string strId)
        {
            bool ban = false;
            switch (catalogo)
            {
                case "questionsAnswer":
                    ban = responsesService.updateResponse(submit,strId);
                    break;
                case "questionsCategory":
                    ban = questionCategoryService.updateCategory(submit, strId);
                    break;
                case "questions":
                    ban = questionsService.update(submit,strId);
                    break;
                case "encuesta":
                    ban = surveysService.addSurvey(submit);
                    break;            
            }
            return ban;
        }
        public bool ajaxRequestDelete(string catalogo, string strIds)
        {
            bool ban = false;
            switch (catalogo)
            {
                case "questionsAnswer":
                    ban = responsesService.deleteQuestionsResponse(strIds);
                    break;
                case "questionsCategory":
                    ban = questionCategoryService.deleteQuestionsCategoruy(strIds);
                    break;
                case "questions":
                    ban = questionsService.deleteQuestions(strIds);
                    break;
            }
            return ban;
        }
        public string ajaxRequestCatalogosTable(string catalogue)
        {
            string jsonTable = "";
            switch (catalogue)
            {
                case "questionsAnswer":
                    jsonTable = responsesService.jsonQuestionsAnswer();
                    break;
                case "questionsCategory":
                    jsonTable = questionCategoryService.jsonQuestionsCategoruy();
                    break;
                case "questions":
                    jsonTable = questionsService.jsonQuestions();
                    break;

            }
            return jsonTable;
        }
        public string recoverData(string catalogo, string strId)
        {
          
            string json = "";
            switch (catalogo)
            {
                case "questionsAnswer":
                    json = responsesService.jsonRecoverData(strId);
                    break;
                case "questionsCategory":
                    json = questionCategoryService.jsonRecoverData(strId);
                    break;
                case "questions":
                    json = questionsService.jsonRecoverData(strId);
                    break;

            }
            return json;

        }
    }
}
