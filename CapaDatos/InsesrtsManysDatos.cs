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
    public class InsesrtsManysDatos
    {        
        private SqlConnection Conexion;
        private SqlCommand Comando;
        private string CadCon;
        public InsesrtsManysDatos(string setConectionStrName)
        {
            CadCon = ConfigurationManager.ConnectionStrings[setConectionStrName].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public bool insertMany(string strFieldsUnios, string table)
        {

            bool ban;
            Comando.CommandText = Query.InsertMany(strFieldsUnios, table);
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
        public bool insertMany(Dictionary<object, object> campos, string table)
        {

            bool ban;
            Comando.CommandText = Query.InsertMany(campos, table);
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
        public bool insertMany(Dictionary<object, List<object>> campos, string table, List<object> extraFields = null)
        {

            bool ban;
            Comando.CommandText = Query.InsertMany(campos, table,extraFields);
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
                throw new DaoException("Error DaoExceptions: ");
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
        public bool insertMany(Dictionary<List<object>, object> campos, string table, List<object> extraFields = null)
        {          
            bool ban;
            Comando.CommandText = Query.InsertMany(campos, table, extraFields);
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
                throw new DaoException("Error DaoExceptions: ");
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
