using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaDatos.binderSurvey;
using Entidades;

namespace CapaLogicaNegocio.binderSurvey.Services.update
{
    public class QuestionsCategoruUpdate
    {
        private QuestionsCategoryData questionsCategoryData= new QuestionsCategoryData();
        public bool updateCategory(CategoryQuestion categoryQuestion)
        {
            return questionsCategoryData.update(categoryQuestion);
        }
    }
}
