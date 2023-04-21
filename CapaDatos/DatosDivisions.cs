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
    public class DatosDivisions
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public DatosDivisions()
        {
            CadCon = ConfigurationManager.ConnectionStrings["centroEscolar"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public bool updateDivision(Division division)
        {

            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_updateDivision";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = division.idDivision;
                Comando.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 60));
                Comando.Parameters["@nombre"].Value = division.nombre;
                Comando.Parameters.Add(new SqlParameter("@FkCarrer", SqlDbType.Int));
                Comando.Parameters["@FkCarrer"].Value = division.fkIdCarrera;
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
        public bool add(Division division)
        {

            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_addDivision";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 60));
                Comando.Parameters["@nombre"].Value = division.nombre;
                Comando.Parameters.Add(new SqlParameter("@FkCarrer", SqlDbType.Int));
                Comando.Parameters["@FkCarrer"].Value = division.fkIdCarrera;
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
        public List<Division> listarDivision()
        {
            List<Division> divisions = new List<Division>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listarDivisions";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    divisions.Add(new Division(renglon));
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
            return divisions;
        }
        public List<Division> listarDivisionesXidCarrer(int id)
        {
            List<Division> divisions = new List<Division>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_divisionsXidCarrer";
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = id;
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    divisions.Add(new Division(renglon));
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
            return divisions;
        }
        public Division recoverData(int id)
        {
            SqlDataReader renglon;
            Division division = null;
            try
            {

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_divisionsXidDivision";
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = id;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                if (renglon.Read())
                {
                    division = new Division(renglon);
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
            return division;
        }
        public bool eliminarDivisions(string strIds)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "por_deleteDivisions";
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
        public DataTable tableDivisionsByMatchingCharacterss(string characters)
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_innerDivisionsByCharacters";
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
