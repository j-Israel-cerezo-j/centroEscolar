using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Entidades;
using System.Xml.Linq;

namespace CapaDatos
{
    public class QuestionAnswerData
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public QuestionAnswerData()
        {
            CadCon = ConfigurationManager.ConnectionStrings["pollster"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public bool add(QuestionAnswer questionAnswer)
        {

            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_addQuestionAnswer";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar,50));
                Comando.Parameters["@descripcion"].Value = questionAnswer.descripcion;                
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
        public List<QuestionAnswer> listarQuestionsAnser()
        {
            List<QuestionAnswer> questionsAnser = new List<QuestionAnswer>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listasResponse";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    questionsAnser.Add(new QuestionAnswer(renglon));
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
            return questionsAnser;
        }
        public bool deleteQuestionsAnswer(string strIds)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_deleteQuestionsAnswer";
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
        public int countResponseByCategorys(int idCategory)
        {

            int countResponseByCategory = 0;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_countResponseByCategorys";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@idCategory", SqlDbType.Int));
                Comando.Parameters["@idCategory"].Value = idCategory;               
                Conexion.Open();
                countResponseByCategory = (int)Comando.ExecuteScalar();
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
            return countResponseByCategory;
        }
        public bool update(QuestionAnswer response)
        {

            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_updateResponses";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = response.idResponse;
                Comando.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.Text));
                Comando.Parameters["@descripcion"].Value = response.descripcion;
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
        public DataTable ableResponsesByIdResponse(int idResponse)
        {
            DataTable questions = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_tableResponsesByIdResponse";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = idResponse;
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
