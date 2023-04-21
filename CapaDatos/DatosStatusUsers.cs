using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Entidades;
using CapaDatos.Querys;
namespace CapaDatos
{
    public  class DatosStatusUsers
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public DatosStatusUsers()
        {
            CadCon = ConfigurationManager.ConnectionStrings["centroEscolar"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public List<StatusUser> listarStatus()
        {
            List<StatusUser> status = new List<StatusUser>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listStatusUser";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    status.Add(new StatusUser(renglon));
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
      
        public bool updateStatusUser(string table, string fieldWhere, string strValueFieldSet, string fielSet, string fieldValueWhere)
        {
            bool ban;
            Comando.CommandText = Query.updateWhere(table,fieldWhere,strValueFieldSet, fielSet,fieldValueWhere);
            Comando.CommandType = CommandType.Text;
            try
            {
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
      
    }
}
