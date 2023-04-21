using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Entidades;
using CapaDatos.Exceptions;
namespace CapaDatos
{
    public class DatosStudentCandidate
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public DatosStudentCandidate()
        {
            CadCon = ConfigurationManager.ConnectionStrings["centroEscolar"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public bool add(StudentCandidate studentCandidate)
        {

            bool ban = false;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_addStudentCandidate";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@matricula", SqlDbType.VarChar, 30));
                Comando.Parameters["@matricula"].Value = studentCandidate.matricula;
                Comando.Parameters.Add(new SqlParameter("@nombres", SqlDbType.VarChar, 40));
                Comando.Parameters["@nombres"].Value = studentCandidate.nombres;
                Comando.Parameters.Add(new SqlParameter("@apellidoP", SqlDbType.VarChar, 20));
                Comando.Parameters["@apellidoP"].Value = studentCandidate.apellidoP;
                Comando.Parameters.Add(new SqlParameter("@apellidoM", SqlDbType.VarChar, 20));
                Comando.Parameters["@apellidoM"].Value = studentCandidate.apellidoM;
                Comando.Parameters.Add(new SqlParameter("@curp", SqlDbType.VarChar, 100));
                Comando.Parameters["@curp"].Value = studentCandidate.curp;
                Comando.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar, 100));
                Comando.Parameters["@pass"].Value = studentCandidate.pass;
                Comando.Parameters.Add(new SqlParameter("@correoP", SqlDbType.VarChar, 50));
                Comando.Parameters["@correoP"].Value = studentCandidate.correoP;
                Comando.Parameters.Add(new SqlParameter("@correoIns", SqlDbType.VarChar, 50));
                Comando.Parameters["@correoIns"].Value = studentCandidate.correoIns;
                Comando.Parameters.Add(new SqlParameter("@telefono", SqlDbType.VarChar, 30));
                Comando.Parameters["@telefono"].Value = studentCandidate.telefono;
                Comando.Parameters.Add(new SqlParameter("@fechaNac", SqlDbType.DateTime));
                Comando.Parameters["@fechaNac"].Value = studentCandidate.fechaNac;
                Comando.Parameters.Add(new SqlParameter("@fkIdDivision", SqlDbType.Int));
                Comando.Parameters["@fkIdDivision"].Value = studentCandidate.fkIdDivision;
                Comando.Parameters.Add(new SqlParameter("@fkStatus", SqlDbType.VarChar,10));
                Comando.Parameters["@fkStatus"].Value = studentCandidate.fkIdStatus;
                Comando.Parameters.Add(new SqlParameter("@fkAddress", SqlDbType.Int));
                Comando.Parameters["@fkAddress"].Value = studentCandidate.fkAddress;

                Conexion.Open();
                Comando.ExecuteNonQuery();
                ban = true;
            }
            catch (SqlException e)
            {
                ban = false;
                if (e.Message.Contains("duplicate key"))
                {
                    throw new DaoException("Campo duplicado");
                }
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
        public List<StudentCandidate> listarStudents()
        {
            List<StudentCandidate> candidates = new List<StudentCandidate>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listStudents";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    candidates.Add(new StudentCandidate(renglon));
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
            return candidates;
        }
        public DataTable tableCandidatesStudents()
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_innerCandidatesStudent";
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
        public DataTable tableCandidatesStudentsByIdDivision(int id)
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_innerCandidatesStudentByIdDiv";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = id;
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
        public DataTable tableCandidatesStudentsByMatchingCharacterss(string characters)
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_innerCandidatesStudentByCharacters";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@characters", SqlDbType.Text));
                Comando.Parameters["@characters"].Value = characters;
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
    }
}
