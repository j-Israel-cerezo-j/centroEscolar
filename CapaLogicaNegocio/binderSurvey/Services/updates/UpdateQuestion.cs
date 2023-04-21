using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;

namespace CapaLogicaNegocio.binderSurvey.Services.updates
{
    public class UpdateQuestion
    {
        private QuestionsData QuestionsData = new QuestionsData();
        public bool updateQuestionn(Question question)
        {
            return QuestionsData.updateQuestion(question);
        }
    }
}
