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
    public class DatosRoles
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public DatosRoles()
        {
            CadCon = ConfigurationManager.ConnectionStrings["centroEscolar"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public bool updateRol(Rol rol)
        {

            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_updateRol";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@idRol", SqlDbType.Int));
                Comando.Parameters["@idRol"].Value = rol.idRol;
                Comando.Parameters.Add(new SqlParameter("@rol", SqlDbType.VarChar, 30));
                Comando.Parameters["@rol"].Value = rol.rol;
                Comando.Parameters.Add(new SqlParameter("@fkTypeWorker", SqlDbType.VarChar,60));
                Comando.Parameters["@fkTypeWorker"].Value = rol.fkTypeWorker;
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
        public bool addRol(Rol rol)
        {

            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_addRol";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@rol", SqlDbType.VarChar, 30));
                Comando.Parameters["@rol"].Value = rol.rol;
                Comando.Parameters.Add(new SqlParameter("@fkTypeWorker", SqlDbType.VarChar,60));
                Comando.Parameters["@fkTypeWorker"].Value = rol.fkTypeWorker;
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
        public List<Rol> listarRoles()
        {
            List<Rol> roles = new List<Rol>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listarRoles";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    roles.Add(new Rol(renglon));
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
            return roles;
        }
        public Rol recoverData(int id)
        {
            SqlDataReader renglon;
            Rol rol = null;
            try
            {

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_rolXidRol";
                Comando.Parameters.Add(new SqlParameter("@idRol", SqlDbType.Int));
                Comando.Parameters["@idRol"].Value = id;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                if (renglon.Read())
                {
                    rol = new Rol(renglon);
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
            return rol;
        }
        public bool eliminarRoles(string strIds)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "por_deleteRoles";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@idRoles", SqlDbType.VarChar));
                Comando.Parameters["@idRoles"].Value = strIds;
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
        public DataTable tableRoles()
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_innerRoles";
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
        public DataTable tableRolesByMatchingCharacterss(string characters)
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_innerRolesByCharacters";
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
