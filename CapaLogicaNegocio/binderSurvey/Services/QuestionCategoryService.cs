using CapaDatos;
using CapaLogicaNegocio.binderSurvey.Services.Selects;
using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.retrieveAtributesValues;
using CapaLogicaNegocio.utils;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones.util;
using CapaLogicaNegocio.binderSurvey.Services.update;
using CapaLogicaNegocio.binderSurvey.Services.tables;
using CapaLogicaNegocio.binderSurvey.Services.Onkeyups;
using CapaLogicaNegocio.binderSurvey.Services.tablesInner;
namespace CapaLogicaNegocio.Services
{
    public class QuestionCategoryService
    {
        private QuestionCategoryTable questionCategoryTable = new QuestionCategoryTable();
        private QuestionsCategoryData categoryData = new QuestionsCategoryData();
        private QuestionsCategoruUpdate questionsCategoru=new QuestionsCategoruUpdate();
        public bool addCategory(Dictionary<string, string> submit)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                CategoryQuestion categoryQuestion = new CategoryQuestion();
                categoryQuestion.descripcion = RetrieveAtributes.values(submit, "descripcion");
                return categoryData.add(categoryQuestion);
            }
            else
            {
                foreach (var item in camposEmptysOrNull)
                {
                    if (item.Value)
                    {
                        throw new ServiceException(item.Key + " esta vacío");
                    }
                }
            }
            return ban;
        }
        public bool updateCategory(Dictionary<string, string> submit,string strId)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                CategoryQuestion categoryQuestion = new CategoryQuestion();
                categoryQuestion.idCategory = Convert.ToInt32(strId);
                categoryQuestion.descripcion = RetrieveAtributes.values(submit, "descripcion");
                return questionsCategoru.updateCategory(categoryQuestion);
            }
            else
            {
                foreach (var item in camposEmptysOrNull)
                {
                    if (item.Value)
                    {
                        throw new ServiceException(item.Key + " esta vacío");
                    }
                }
            }
            return ban;
        }
        public string jsonQuestionsCategoruy()
        {
            List<CategoryQuestion> questionsCategorys = categoryData.listarQuestionsCategory();
            return Converter.ToJson(questionsCategorys);
        }
        public bool deleteQuestionsCategoruy(string strIds)
        {
            bool ban = false;
            var idsListToDelete = Converter.ToList(strIds);
            foreach (var item in idsListToDelete)
            {
                var fiellExist=Select.findFieldsWhereIn("fkCategoryQuestion", "questions", "fkCategoryQuestion", item.ToString());
                if (fiellExist.Count>0)
                {                    
                    var descriptionCategory = Select.findFieldWhere("descripcion", "questionCategories", "idCategory", item.ToString());
                    throw new ServiceException("No puedes eliminar la categoria " + descriptionCategory + " por que ya pertenece" +
                        "a una pregunta existente,deselecciona ese registro.");
                }              
            }
            if (!ban)
            {
                ban = categoryData.deleteQuestionsCategory(strIds);
            }
            return ban;
        }
        public StringBuilder onkeyupSearchTable(string caracteres)
        {
            var fields = new Dictionary<string, string>();
            fields.Add("idCategory", caracteres);
            fields.Add("descripcion", caracteres);

            var table = Onkeyup.onkeyubSearchhTable(fields, "questionCategories");
            return Converter.ToJson(table, "idCategory", "id");

        }
        public List<string> onkeyupSearch(string caracteres)
        {
            var fields = new Dictionary<string, string>();
            fields.Add("descripcion", caracteres);

            var table = Onkeyup.onkeyubSearchh(fields, "questionCategories");
            return Converter.ToList(table);

        }
        public string jsonRecoverData(string strId)
        {
            string jsonRecoerDtes = "";
            if (strId != "")
            {
                jsonRecoerDtes = Converter.ToJson(questionCategoryTable.tableQuestionCategoryByIdCategory(Convert.ToInt32(strId))).ToString();
            }
            return jsonRecoerDtes;
        }
    }
}
