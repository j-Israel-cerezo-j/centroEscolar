using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Entidades;
namespace CapaDatos
{
    public class DatosStatusCandidate
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public DatosStatusCandidate()
        {
            CadCon = ConfigurationManager.ConnectionStrings["centroEscolar"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public List<StatusCandidate> listarStatus()
        {
            List<StatusCandidate> status = new List<StatusCandidate>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listStatusCandidate";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    status.Add(new StatusCandidate(renglon));
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
            return status;
        }
        public bool updateStatusCandidate(StudentCandidate studentCandidate)
        {            
            bool ban = false;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_updateStatusCandidate";
                Comando.Parameters.Add(new SqlParameter("@idCandidato", SqlDbType.Int));
                Comando.Parameters["@idCandidato"].Value = studentCandidate.id;
                Comando.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 10));
                Comando.Parameters["@status"].Value = studentCandidate.fkIdStatus;
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
        public StudentCandidate recoverData(int id)
        {
            SqlDataReader renglon;
            StudentCandidate studentCandidate = null;
            try
            {

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_recoverDataStudenCandidate";
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = id;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                if (renglon.Read())
                {
                    studentCandidate = new StudentCandidate(renglon);
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
            return studentCandidate;
        }
    }
}
