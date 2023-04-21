using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogicaNegocio.utils;
using System.Xml.Linq;
using Entidades;
using Validaciones.util;
using CapaDatos;
using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.retrieveAtributesValues;
using CapaLogicaNegocio.binderSurvey.Services.Selects;
using CapaLogicaNegocio.binderSurvey.Services.update;
using CapaLogicaNegocio.binderSurvey.Services.Onkeyups;
using CapaLogicaNegocio.binderSurvey.Services.tablesInner;

namespace CapaLogicaNegocio.Services
{
    public class ResponsesService
    {
        private ResponsesTable responsesTable=new ResponsesTable(); 
        private ResponseUpdate responseUpdate = new ResponseUpdate();
        private QuestionAnswerData answerData = new QuestionAnswerData();
        public bool addResponse(Dictionary<string, string> submit)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                QuestionAnswer questionAnswer = new QuestionAnswer();
                questionAnswer.descripcion = RetrieveAtributes.values(submit, "descripcion");
                return answerData.add(questionAnswer);
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
        public bool updateResponse(Dictionary<string, string> submit, string strId)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                QuestionAnswer response = new QuestionAnswer();
                response.idResponse = Convert.ToInt32(strId);
                response.descripcion = RetrieveAtributes.values(submit, "descripcion");
                return responseUpdate.updateResponse(response);
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
        public bool deleteQuestionsResponse(string strIds)
        {
            bool ban = false;
            var idsListToDelete = Converter.ToList(strIds);
            foreach (var item in idsListToDelete)
            {
                var fiellExist = Select.findFieldsWhereIn("fkResponse", "questionsResponses", "fkResponse", item.ToString());
                if (fiellExist.Count > 0)
                {
                    var descriptionCategory = Select.findFieldWhere("descripcion", "responses", "idResponse", item.ToString());
                    throw new ServiceException("No puedes eliminar la respuesta " + descriptionCategory + " por que ya pertenece" +
                        "a una pregunta existente,deselecciona ese registro.");
                }
            }
            if (!ban)
            {
                ban = answerData.deleteQuestionsAnswer(strIds);
            }
            return ban;
        }
        public StringBuilder onkeyupSearchTable(string caracteres)
        {
            var fields = new Dictionary<string, string>();
            fields.Add("idResponse", caracteres);
            fields.Add("descripcion", caracteres);

            var table = Onkeyup.onkeyubSearchhTable(fields, "responses");
            return Converter.ToJson(table, "idResponse", "id");

        }
        public List<string> onkeyupSearch(string caracteres)
        {
            var fields = new Dictionary<string, string>();
            fields.Add("descripcion", caracteres);

            var table = Onkeyup.onkeyubSearchh(fields, "responses");
            return Converter.ToList(table);

        }
        public string jsonQuestionsAnswer()
        {
            List<QuestionAnswer> questionsAnswer = answerData.listarQuestionsAnser();
            return Converter.ToJson(questionsAnswer);
        }
        public string jsonRecoverData(string strId)
        {
            string jsonRecoerDtes = "";
            if (strId != "")
            {
                jsonRecoerDtes = Converter.ToJson(responsesTable.tableResponseByIdResponse(Convert.ToInt32(strId))).ToString();
            }
            return jsonRecoerDtes;
        }

    }
}
