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
    public class DatosRolePrivileges
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public DatosRolePrivileges()
        {
            CadCon = ConfigurationManager.ConnectionStrings["centroEscolar"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public List<Privilege> listPrivileges()
        {
            List<Privilege> privileges = new List<Privilege>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listPrivileges";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    privileges.Add(new Privilege(renglon));
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
            return privileges;
        }
        public DataTable tablePrivilegesTheRoles()
        {
            DataTable privileges = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_privilegesTheRoles";
            try
            {                
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                privileges.Load(renglon);
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
            return privileges;
        }
        public DataTable tablePrivilegesByIdRol(int id)
        {
            DataTable privileges = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_privilegesRolesByFkRol";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@idRol", SqlDbType.Int));
                Comando.Parameters["@idRol"].Value = id;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                privileges.Load(renglon);
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
            return privileges;
        }
        public DataTable tablePrivilegesRolessByCharacters(string characters)
        {
            DataTable privileges = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_privilegesByCharacters";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@characters", SqlDbType.Text));
                Comando.Parameters["@characters"].Value = characters;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                privileges.Load(renglon);
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
            return privileges;
        }
    }
}
