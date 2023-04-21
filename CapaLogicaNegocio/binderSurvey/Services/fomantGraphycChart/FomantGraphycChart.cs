using CapaDatos;
using CapaLogicaNegocio.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.binderSurvey.Services.fomantGraphycChart
{
    public class FomantGraphycChart
    {
        private Random rnd = new Random();
        private QuestionsCategoryData questionsCategoryData = new QuestionsCategoryData();
        private QuestionAnswerData questionsAnswerData = new QuestionAnswerData();
        private UniversityDatos universityDatos = new UniversityDatos();
        private string graphycChart(string graphTitle, string strUnionsDescriptionBy,string strUnionsCountBy,string chartType,string strUnionBackgroundColor)
        {                                    
            var html =
           "type: '"+ chartType + "'," +
           "data: " +
           "{" +
                "labels: ["+
                        strUnionsDescriptionBy +
                    "]," +
                "datasets: [" +
                                "{" +
                                    "label: '"+ graphTitle + "'," +
                                    "backgroundColor:[" +
                                                        strUnionBackgroundColor+
                                                    "]," +
                                    "data:["+
                                            strUnionsCountBy+
                                        "]" +
                                "}" +
                        "]" +
            "}";
            return html;
        }
        
        public string ByCategorys()
        {            
            string strUnionsCategorysDescription = "";
            string strUnionsCountResponseByCategory = "";
            string strUnionBackgroundColor = "";


            var listQuestionsCategorys = questionsCategoryData.listarQuestionsCategory();
            foreach (var item in listQuestionsCategorys)
            {
                strUnionsCategorysDescription += " ,'" + item.descripcion + "'";
                strUnionBackgroundColor += " ,'rgb("+ rnd.Next(255) + ","+ rnd.Next(255) + ","+ rnd.Next(255) + ")'";
                var countResponseByCategory = questionsAnswerData.countResponseByCategorys(item.idCategory);
                strUnionsCountResponseByCategory += " ," + countResponseByCategory;
            }                            
            if (listQuestionsCategorys.Count > 0)
            {
                strUnionBackgroundColor = strUnionBackgroundColor.Remove(0, 2);
                strUnionsCategorysDescription = strUnionsCategorysDescription.Remove(0, 2);
                strUnionsCountResponseByCategory = strUnionsCountResponseByCategory.Remove(0, 2);
            }            

            return graphycChart("Categorias",strUnionsCategorysDescription, strUnionsCountResponseByCategory, "bar", strUnionBackgroundColor);
        }

        public string ByUniversity()
        {            
            string strUnionsUniversityDescription = "";
            string strUnionsCountResponseByUniversity = "";
            string strUnionBackgroundColor = "";
            

            var univesitysVotates = Converter.ToDictionary(universityDatos.universitysVotate(),false);
            foreach (var item in univesitysVotates)
            {
                strUnionsUniversityDescription += " ,'" + item.Value + "'";
                strUnionBackgroundColor += " ,'rgb(" + rnd.Next(255) + "," + rnd.Next(255) + "," +  +rnd.Next(255)+  ")'";
                var countResponseByCategory = universityDatos.countResponseByUniversity(Convert.ToInt32(item.Key));
                strUnionsCountResponseByUniversity += " ," + countResponseByCategory;
            }          
            if (univesitysVotates.Count > 0)
            {
                strUnionBackgroundColor = strUnionBackgroundColor.Remove(0, 2);
                strUnionsUniversityDescription = strUnionsUniversityDescription.Remove(0, 2);
                strUnionsCountResponseByUniversity = strUnionsCountResponseByUniversity.Remove(0, 2);
            }            

            return graphycChart("Universidades",strUnionsUniversityDescription, strUnionsCountResponseByUniversity, "doughnut", strUnionBackgroundColor);
        }


    }
}
