using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Entidades;

namespace CapaDatos
{
    public class SurveysData
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public SurveysData()
        {
            CadCon = ConfigurationManager.ConnectionStrings["pollster"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }

        public DataTable tableEmployesLocales()
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_questionsWithAnswers";
            try
            {
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                candidates.Load(renglon);
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
            return candidates;
        }
        public List<Question> listQuestions()
        {
            List<Question> questios = new List<Question>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listarQuestions";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    questios.Add(new Question(renglon));
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
            return questios;
        }
        public DataTable questionsAnswer(int idQuestion)
        {
            DataTable responses = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_questionsAnswer";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@idQuestion", SqlDbType.Int));
                Comando.Parameters["@idQuestion"].Value = idQuestion;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                responses.Load(renglon);
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
            return responses;
        }
        public List<University> listUniversitys()
        {
            List<University> universitys = new List<University>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listUniversitys";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    universitys.Add(new University(renglon));
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
            return universitys;
        }
        public int addSurvey(Survey survery)
        {

            int idRecuperado = 0;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_addSurvey";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@fkUniversity", SqlDbType.Int));
                Comando.Parameters["@fkUniversity"].Value = survery.fkUniversity;
                Comando.Parameters.Add(new SqlParameter("@fkUser", SqlDbType.Int));
                Comando.Parameters["@fkUser"].Value = survery.fkUser;
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
        public DataTable tableAnsweredServeys()
        {
            DataTable table = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_tableAnsweredServeys";
            try
            {
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                table.Load(renglon);
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
            return table;
        }
        public int countAnsweredServeys()
        {

            int idRecuperado = 0;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_countAnsweredServeys";
            try
            {               
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
    }
}
