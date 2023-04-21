using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.utils;
using Entidades;
using Validaciones.util;
using CapaLogicaNegocio.binderSurvey.Services.Insert;
using CapaLogicaNegocio.binderSurvey.Services.Selects;
using CapaLogicaNegocio.retrieveAtributesValues;
using CapaLogicaNegocio.MessageErrors;
using CapaLogicaNegocio.binderSurvey.Services.deletes;
using CapaDatos.Exceptions;
using CapaLogicaNegocio.tablesInner;
using CapaLogicaNegocio.binderSurvey.Services.tables;
using CapaLogicaNegocio.binderSurvey.Services.updates;

namespace CapaLogicaNegocio.Services
{    
    public class QuestionsService
    {
        private QuestionAnswerData answerData = new QuestionAnswerData();
        private QuestionsCategoryData categoryData = new QuestionsCategoryData();
        private QuestionsData questionsData=new QuestionsData();
        private Delete delete=new Delete();
        private QuestionsTables questionsTables = new QuestionsTables();
        private UpdateQuestion updateQuestion = new UpdateQuestion();
        public bool addQuestion(Dictionary<string, string> submit)
        {
            int idRecuperado = 0;
            bool insertSucces = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                try
                {
                    validateRequestCategorys(submit);
                    validateChecksResponses(submit);
                    Question question = new Question();
                    question.questions = RetrieveAtributes.values(submit, "question");
                    question.fkCategoryQuestion = Convert.ToInt32(RetrieveAtributes.values(submit, "categorys"));
                    idRecuperado = questionsData.addQuestion(question);
                    if (idRecuperado != 0)
                    {
                        string strPrivileges = RetrieveAtributes.values(submit, "checksResponses");
                        var listPrivileges = Converter.ToList(strPrivileges);
                        var campos = new Dictionary<List<object>, object>();
                        campos.Add(listPrivileges, idRecuperado);
                        insertSucces = Inserts.Many(campos, "questionsResponses");
                        if (!insertSucces)
                        {
                            rollbackQuestion(idRecuperado);
                        }
                    }
                }
                catch (DaoException e)
                {
                    rollbackQuestion(idRecuperado);
                    throw new ServiceException(e.getMessage());
                }
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
            return insertSucces;
        }       
        private void rollbackQuestion(int idQuestion)
        {
            delete.deleteWhere("questions", "idQuestion", idQuestion.ToString());

        }
        public string jsonRecoverData(string strId)
        {
            string jsonRecoerDtes = "";
            if (strId != "")
            {
                jsonRecoerDtes = Converter.ToJson(questionsTables.tableQuestionByIdQuestion(Convert.ToInt32(strId))).ToString();
            }
            return jsonRecoerDtes;
        }
        private void validateIFquestionsExistInSurveredAnswered(string strQuestions)
        {
            var listPrivileges = Converter.ToList(strQuestions);
            var camposWhere = new Dictionary<string, string>();
            foreach (var item in listPrivileges)
            {
                camposWhere.Add("fkQuestion", item.ToString());                
                var fields = Select.findFromAll("answeredSurvey", camposWhere);
                if (fields.Rows.Count >= 1)
                {
                    throw new ServiceException("Esta pregunta ha sido respondida en una encuesta, por lo tanto no se puede eliminar");
                }
                camposWhere.Clear();
            }
        }
        public bool deleteQuestions(string ids)
        {
            bool privilegesRoles = false;
            try
            {
                if (ids != "")
                {
                    validateIFquestionsExistInSurveredAnswered(ids);                    
                    privilegesRoles = delete.whereIn("questionsResponses", "fkQuestion", ids);
                    if (privilegesRoles)
                    {
                        privilegesRoles = delete.whereIn("questions", "idQuestion", ids);
                    }

                }
                else
                {
                    throw new ServiceException(MessageError.questionsNotSelected);
                }
            }
            catch (DaoException e)
            {
                throw new ServiceException(e.getMessage());
            }           
            return privilegesRoles;
        }
        public bool update(Dictionary<string, string> request, string strId)
        {
            var insertCampos = new Dictionary<object, object>();
            bool insertSucces = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(request);
            if (camposEmptysOrNull.Count == 0)
            {
                try
                {
                    validateRequestCategorys(request);
                    validateChecksResponses(request);
                    Question question = new Question();
                    question.idQuestion = Convert.ToInt32(strId);
                    question.questions = RetrieveAtributes.values(request, "question");
                    question.fkCategoryQuestion = Convert.ToInt32(RetrieveAtributes.values(request, "categorys"));
                    insertSucces = updateQuestion.updateQuestionn(question);
                    if (insertSucces)
                    {
                        var camposWhere = new Dictionary<string, string>();
                        string strResponsesCurrent = RetrieveAtributes.values(request, "checksResponses");
                        var listResponsesCurrent = Converter.ToList(strResponsesCurrent);
                        var responsesAnt = Select.findFieldsWhereIn("fkResponse", "questionsResponses", "fkQuestion", question.idQuestion.ToString());

                        var listLargetOfRecords = listResponsesCurrent.Count > responsesAnt.Count ? listResponsesCurrent.ToList() : responsesAnt.ToList();
                        var listCountains= listResponsesCurrent.Count < responsesAnt.Count ? listResponsesCurrent.ToList() : responsesAnt.ToList();
                        foreach (var respAct in listLargetOfRecords)
                        {
                            if (!listCountains.Contains(respAct))
                            {
                                camposWhere.Add("fkQuestion", question.idQuestion.ToString());
                                camposWhere.Add("fkResponse", respAct.ToString());


                                var listResponsesQuestions = Converter.ToList(Select.findFromAll("questionsResponses", camposWhere, "fkResponse"));
                                if (listResponsesQuestions.Count > 0)
                                {
                                    var listResponses = Converter.ToList(Select.findFromAll("answeredSurvey", camposWhere, "fkResponse"));
                                    if (listResponses.Count > 0)
                                    {
                                        var descriptionResponse = Select.findFieldWhere("descripcion", "responses", "idResponse", respAct.ToString());
                                        throw new ServiceException("No puedes quitar la respuesta " + descriptionResponse + " a la pregunta a modificar, " +
                                            "ya que esta respuesta ya ha sido contestada a esta pregunta en alguna encuesta");
                                    }
                                    else
                                    {
                                        delete.whereInAnd(camposWhere, "questionsResponses");
                                    }
                                }
                                else
                                {                                    
                                    insertCampos.Add(question.idQuestion.ToString(), respAct);
                                    insertSucces = Inserts.Many(insertCampos, "questionsResponses");
                                    insertCampos.Clear();
                                }
                                camposWhere.Clear();
                            }
                        }
                    }
                }
                catch (DaoException e)
                {                    
                    throw new ServiceException(e.getMessage());
                }
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
            return insertSucces;
        }
        private void validateRequestCategorys(Dictionary<string, string> request)
        {
            string strIdRol = RetrieveAtributes.values(request, "categorys");
            if (!Validation.Select(strIdRol))
            {
                throw new ServiceException(MessageError.invalidSelectorIn("categoria"));
            }
        }
        public string questionsByCategorys(string strId)
        {
            int id = Convert.ToInt32(strId);
            string jsonQuestions = "";
            if (id == -2)
            {
                jsonQuestions= Converter.ToJson(questionsData.tableQuestionsCategorysResponses(), "idQuestion").ToString();

            }
            else
            {
                jsonQuestions =Converter.ToJson( questionsTables.tableQuestionByIdQuestionByIdCategory(id), "idQuestion").ToString();
            }
            return jsonQuestions;

        }
        private void validateChecksResponses(Dictionary<string, string> request)
        {
            string strDivisions = RetrieveAtributes.values(request, "checksResponses");
            if (strDivisions == "" || strDivisions == null)
            {
                throw new ServiceException(MessageError.responsesNotSelected);
            }
        }
        public List<CategoryQuestion> questionsCategoruyList()
        {
            return categoryData.listarQuestionsCategory();            
        }
        public List<QuestionAnswer> questionsAnswerList()
        {
            return answerData.listarQuestionsAnser();            
        }
        public string jsonQuestions()
        {
            return Converter.ToJson(questionsData.tableQuestionsCategorysResponses(), "idQuestion").ToString();
        }
        public StringBuilder onkeyupSearchTable(string caracteres)
        {            
            return Converter.ToJson(questionsTables.tableQuestionsByCharacterss(caracteres), "idQuestion");

        }
        public List<string> onkeyupSearch(string caracteres)
        {
            caracteres = "%" + caracteres + "%";
            var table = questionsTables.tableQuestionsByCharacterss(caracteres);
            return Converter.ToList(table);

        }
    }
}
