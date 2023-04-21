using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaLogicaNegocio.binderSurvey.Services.tables
{
    
    public class QuestionsTables
    {
        private QuestionsData QuestionsData = new QuestionsData();
        public DataTable tableQuestionByIdQuestion(int idQuestion)
        {
            return QuestionsData.tableQuestionsByidQuestion(idQuestion);
        }
        public DataTable tableQuestionByIdQuestionByIdCategory(int idCategory)
        {
            return QuestionsData.tableQuestionsByIdCategory(idCategory);
        }

        public DataTable tableQuestionsByCharacterss(string characters)
        {
            return QuestionsData.tableQuestionsByCharacters(characters);
        }

    }
}
