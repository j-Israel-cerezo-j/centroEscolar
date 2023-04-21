using CapaLogicaNegocio.Services;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.binderSurvey
{
    public class FacadeOnkeyupCatalogues
    {
        private QuestionsService questionsService = new QuestionsService();
        private ResponsesService responsesService = new ResponsesService();
        private QuestionCategoryService questionCategoryService = new QuestionCategoryService();
        private SurveysService surveysService = new SurveysService();
        public string onkeypCatalogosFacadeTables(string catalogo, string caracteres, Dictionary<string, string> request)
        {
            char[] charsToTrim = { ' ' };
            string result = caracteres.Trim(charsToTrim);
            result = "%" + result + "%";
            string jsonTable = "";
            switch (catalogo)
            {
                
                case "questions":
                    jsonTable = questionsService.onkeyupSearchTable(result).ToString();
                    break;
                case "questionsCategory":
                    jsonTable = questionCategoryService.onkeyupSearchTable(result).ToString();
                    break;
                case "questionsAnswer":
                    jsonTable = responsesService.onkeyupSearchTable(result).ToString();
                    break;
            }
            return jsonTable;
        }
        public List<string> onkeypCatalogosFacade(string catalogo, string caracteres)
        {
            char[] charsToTrim = { ' ' };
            string result = caracteres.Trim(charsToTrim);
            List<string> coincidencias = new List<string>();
            switch (catalogo)
            {
                case "questions":
                    coincidencias = questionsService.onkeyupSearch(result);
                    break;
                case "questionsCategory":
                    coincidencias = questionCategoryService.onkeyupSearch(result);
                    break;
                case "questionsAnswer":
                    coincidencias = responsesService.onkeyupSearch(result);
                    break;
            }
            return coincidencias;
        }
    }
}
