using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.Insert;
using CapaLogicaNegocio.retrieveAtributesValues;
using CapaLogicaNegocio.utils;
using Entidades;
using Validaciones.util;

namespace CapaLogicaNegocio.Services
{
    public class SurveysService
    {
        private UserData userData = new UserData();
        private SurveysData surveysData = new SurveysData();
        public List<Question> questionsList()
        {
            return surveysData.listQuestions();
        }
        public string jsonQuestionsAnswer(string strIdQuestion)
        {
            int idQuestion = Convert.ToInt32(strIdQuestion);
            return Converter.ToJson(surveysData.questionsAnswer(idQuestion)).ToString();
        }
        public string jsonQuestions()
        {
            return Converter.ToJson(surveysData.listQuestions());
        }
     
        public bool addSurvey(Dictionary<string, string> submit)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                UserSurvey user = new UserSurvey();
                user.nombres = RetrieveAtributes.values(submit, "nombres");
                user.apellidoP = RetrieveAtributes.values(submit, "apellidoP");
                user.apellidoM = RetrieveAtributes.values(submit, "apellidoM");
                user.email = RetrieveAtributes.values(submit, "email");
                if (!Validation.Select(RetrieveAtributes.values(submit, "slcUnivesitys")))
                {
                    throw new ServiceException("Selecciona una universidad por favor.");
                }
                var answeredSurvey = matchAnswerToQuestion(submit);
                int idUserRetrive = userData.addUser(user);
                if (idUserRetrive != 0)
                {
                    Survey survey = new Survey();
                    survey.fkUniversity = Convert.ToInt32(RetrieveAtributes.values(submit, "slcUnivesitys"));
                    survey.fkUser = idUserRetrive;
                    int idSurveyRetrive = surveysData.addSurvey(survey);
                    if (idSurveyRetrive != 0)
                    {                       
                        if (answeredSurvey.Count > 0)
                        {
                            var strFieldsValuesUnions = "";
                            foreach (var item in answeredSurvey)
                            {
                                strFieldsValuesUnions += " ,(" + item.Key + "," + item.Value + "," + idSurveyRetrive + ")";
                            }
                            strFieldsValuesUnions = strFieldsValuesUnions.Remove(0, 2);
                            return Inserts.ManyS(strFieldsValuesUnions, "answeredSurvey");
                        }
                        else
                        {
                            throw new ServiceException("Preguntas no contestadas");
                        }
                    }
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
            return ban;
        }
        private Dictionary<object, object> matchAnswerToQuestion(Dictionary<string, string> submit)
        {
            Dictionary<object, object> questionAnswer = new Dictionary<object, object>();          
            var listQuestion = surveysData.listQuestions();
            foreach (var item in listQuestion)
            {
                var strQuestionId = RetrieveAtributes.values(submit, "hiddenQuestion" + item.idQuestion);
                var strResponseAnswer = RetrieveAtributes.values(submit, "hiddenResponseAnswer" + item.idQuestion);
                if (strQuestionId != "" && strResponseAnswer != "")
                {
                    questionAnswer.Add(strQuestionId, strResponseAnswer);
                }
                else
                {
                    throw new ServiceException("Alguna pregunta falta por responder");
                }

            }
            return questionAnswer;
        }
        public List<University> listUniversityss()
        {
            return surveysData.listUniversitys();
        }
        public string jsonTableAnsweredSurveys()
        {
            return Converter.ToJson(surveysData.tableAnsweredServeys()).ToString();
        }
        public int countAnsweredServeyss()
        {
            return surveysData.countAnsweredServeys();
        }

       
    }    
}
