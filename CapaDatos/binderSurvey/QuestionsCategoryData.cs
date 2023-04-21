using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class QuestionsCategoryData
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public QuestionsCategoryData()
        {
            CadCon = ConfigurationManager.ConnectionStrings["pollster"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public bool add(CategoryQuestion categoryQuestion)
        {

            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_questionCategories";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.Text));
                Comando.Parameters["@descripcion"].Value = categoryQuestion.descripcion;
                Conexion.Open();
                Comando.ExecuteNonQuery();
                ban = true;
            }
            catch (SqlException e)
            {
                ban = false;
                throw new Exception(e.Message);
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
                Comando.Parameters.Clear();
            }
            return ban;
        }
        public bool update(CategoryQuestion categoryQuestion)
        {

            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_updateCategoryQuestions";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = categoryQuestion.idCategory;
                Comando.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.Text));
                Comando.Parameters["@descripcion"].Value = categoryQuestion.descripcion;
                Conexion.Open();
                Comando.ExecuteNonQuery();
                ban = true;
            }
            catch (SqlException e)
            {
                ban = false;
                throw new Exception(e.Message);
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
                Comando.Parameters.Clear();
            }
            return ban;
        }
        public List<CategoryQuestion> listarQuestionsCategory()
        {
            List<CategoryQuestion> questionsCategorys = new List<CategoryQuestion>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listasQuestionCategories";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    questionsCategorys.Add(new CategoryQuestion(renglon));
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
                Comando.Parameters.Clear();
            }
            return questionsCategorys;
        }
        public bool deleteQuestionsCategory(string strIds)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_deleteQuestionCategories";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@ids", SqlDbType.VarChar));
                Comando.Parameters["@ids"].Value = strIds;
                Conexion.Open();
                Comando.ExecuteNonQuery();
                ban = true;
            }
            catch (SqlException e)
            {
                ban = false;
                throw new Exception(e.Message);
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
                Comando.Parameters.Clear();
            }
            return ban;
        }
        public DataTable tableQuestionsCategoryByidCategory(int idCategory)
        {
            DataTable questions = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_tableQuestionCategoryByIdCategory";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = idCategory;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                questions.Load(renglon);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
                Comando.Parameters.Clear();
            }
            return questions;
        }
    }
}
