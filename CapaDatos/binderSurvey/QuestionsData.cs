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
    public class QuestionsData
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public QuestionsData()
        {
            CadCon = ConfigurationManager.ConnectionStrings["pollster"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public int addQuestion(Question question)
        {

            int idRecuperado = 0;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_addQuestion";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@question", SqlDbType.Text));
                Comando.Parameters["@question"].Value = question.questions;
                Comando.Parameters.Add(new SqlParameter("@fkCategoryQuestion", SqlDbType.Int));
                Comando.Parameters["@fkCategoryQuestion"].Value = question.fkCategoryQuestion;               
                Conexion.Open();
                idRecuperado = (int)Comando.ExecuteScalar();
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
            return idRecuperado;
        }
        public bool updateQuestion(Question question)
        {

            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_updateQuestion";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = question.idQuestion;
                Comando.Parameters.Add(new SqlParameter("@question", SqlDbType.Text));
                Comando.Parameters["@question"].Value = question.questions;
                Comando.Parameters.Add(new SqlParameter("@fkCategoryQuestion", SqlDbType.Int));
                Comando.Parameters["@fkCategoryQuestion"].Value = question.fkCategoryQuestion;
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
        public DataTable tableQuestionsCategorysResponses()
        {
            DataTable classrooms = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_tableQuestionsCategorysResponses";
            try
            {
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                classrooms.Load(renglon);
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
            return classrooms;
        }
        public DataTable tableQuestionsByidQuestion(int idQuestion)
        {
            DataTable questions = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_tableQuestionsByidQuestion";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = idQuestion;
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
        public DataTable tableQuestionsByCharacters(string characters)
        {
            DataTable questions = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_tableQuestionsCategorysResponsesByCharacters";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@characters", SqlDbType.Text));
                Comando.Parameters["@characters"].Value = characters;
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
        public DataTable tableQuestionsByIdCategory(int idCategory)
        {
            DataTable questions = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_tableQuestionsCategorysResponsesByIdCategory";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@idCategory", SqlDbType.Int));
                Comando.Parameters["@idCategory"].Value = idCategory;
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
