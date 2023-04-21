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
using CapaDatos.Querys;

namespace CapaDatos
{
    public class DatosUser
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public DatosUser()
        {
            CadCon = ConfigurationManager.ConnectionStrings["centroEscolar"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public User login(string email)
        {
            SqlDataReader renglon;
            User user = null;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_login";
                Comando.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50));
                Comando.Parameters["@email"].Value = email;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                if (renglon.Read())
                {
                    user = new User(renglon);
                }
            }
            catch (SqlException e)
            {
                throw new DaoException("Campo erroneo");
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
                Comando.Parameters.Clear();
            }
            return user;
        }
        public User findStatusUser(int idUser)
        {
            SqlDataReader renglon;
            User user = null;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_findStatusUser";
                Comando.Parameters.Add(new SqlParameter("@idUser", SqlDbType.Int));
                Comando.Parameters["@idUser"].Value = idUser;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                if (renglon.Read())
                {
                    user = new User(renglon);
                }
            }
            catch (SqlException e)
            {
                throw new DaoException("Campo erroneo");
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
                Comando.Parameters.Clear();
            }
            return user;
        }
        public List<object> listarFileNamesUserWhereIds(string field, string table, string fieldWhere, string valueFieldWhere)
        {
            List<object> fileNamesUsers = new List<object>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandText = Query.selectFieldWhereUnion(field, table, fieldWhere, valueFieldWhere);
                Comando.CommandType = CommandType.Text;
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    fileNamesUsers.Add((object)(DBNull.Value == renglon["fileName"] ? "" : renglon["fileName"]));
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
            return fileNamesUsers;
        }
        public string rolLoggedIn(int idEmploye)
        {

            string strRolLoggedIn = "";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_rolEmployeLoggedIn";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@idEmploye", SqlDbType.Int));
                Comando.Parameters["@idEmploye"].Value = idEmploye;               
                Conexion.Open();
                strRolLoggedIn = (string)Comando.ExecuteScalar();
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
            return strRolLoggedIn;
        }
    }
}
