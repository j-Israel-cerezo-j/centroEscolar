using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.binderSurvey.Services.update
{
    public class ResponseUpdate
    {
        private QuestionAnswerData questionAnswerData = new QuestionAnswerData();
        public bool updateResponse(QuestionAnswer response)
        {
            return questionAnswerData.update(response);
        }
    }
}
