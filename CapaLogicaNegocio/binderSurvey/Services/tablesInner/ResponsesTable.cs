using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.binderSurvey.Services.tablesInner
{
    internal class ResponsesTable
    {
        private QuestionAnswerData answerData = new QuestionAnswerData();
        public DataTable tableResponseByIdResponse(int idResponse)
        {
            return answerData.ableResponsesByIdResponse(idResponse);
        }
    }
}
