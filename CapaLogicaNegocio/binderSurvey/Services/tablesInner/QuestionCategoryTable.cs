using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.binderSurvey.Services.tablesInner
{
    public class QuestionCategoryTable
    {
        QuestionsCategoryData QuestionsCategoryData=new QuestionsCategoryData();
        public DataTable tableQuestionCategoryByIdCategory(int idCategory)
        {
            return QuestionsCategoryData.tableQuestionsCategoryByidCategory(idCategory);
        }
    }
}
