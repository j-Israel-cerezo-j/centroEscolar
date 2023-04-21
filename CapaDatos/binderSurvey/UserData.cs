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
    public class UserData
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public UserData()
        {
            CadCon = ConfigurationManager.ConnectionStrings["pollster"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public int addUser(UserSurvey user)
        {

            int idRecuperado = 0;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_addUser";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@nombres", SqlDbType.VarChar,100));
                Comando.Parameters["@nombres"].Value = user.nombres;
                Comando.Parameters.Add(new SqlParameter("@apellidoP", SqlDbType.VarChar, 100));
                Comando.Parameters["@apellidoP"].Value = user.apellidoP;
                Comando.Parameters.Add(new SqlParameter("@apellidoM", SqlDbType.VarChar, 100));
                Comando.Parameters["@apellidoM"].Value = user.apellidoM;
                Comando.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 100));
                Comando.Parameters["@email"].Value = user.email;
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
