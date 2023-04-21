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
    public class FindFrom
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public FindFrom(string setConectionStrName)
        {
            CadCon = ConfigurationManager.ConnectionStrings[setConectionStrName].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public DataTable findFromLike(Dictionary<string, string> campos, string table)
        {
            DataTable dt = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandText = Query.FindFromLike(campos, table);
            Comando.CommandType = CommandType.Text;
            try
            {
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                dt.Load(renglon);
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
            return dt;
        }
        public DataTable findAllFromLike(Dictionary<string, string> campos, string table)
        {
            DataTable dt = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandText = Query.FindAllFromLike(campos, table);
            Comando.CommandType = CommandType.Text;
            try
            {
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                dt.Load(renglon);
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
            return dt;
        }
        public DataTable findFromAll(Dictionary<string, string> camposWhere, string table,string field="*")
        {
            DataTable dt = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandText = Query.FindAllFrom(camposWhere, table, field);
            Comando.CommandType = CommandType.Text;
            try
            {
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                dt.Load(renglon);
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
            return dt;
        }
        public List<object> findFieldsFrom(string field, string table, string fieldWhere, string valueFieldWhere)
        {
            List<object> fieldsFounds = new List<object>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandText = Query.selectFieldWhereUnion(field, table, fieldWhere, valueFieldWhere);
                Comando.CommandType = CommandType.Text;
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    fieldsFounds.Add((object)(DBNull.Value == renglon[0] ? "" : renglon[0]));
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
            return fieldsFounds;
        }
        public object findFieldFrom(string field, string table, string fieldWhere, string valueFieldWhere)
        {
            object fieldObj = null;

            try
            {

                Conexion.Open();
                Comando.CommandText = Query.selectFieldWhere(field, table, fieldWhere, valueFieldWhere);
                Comando.CommandType = CommandType.Text;
                fieldObj = (object)Comando.ExecuteScalar();
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
            return fieldObj;
        }
        public DataTable findFromAll(string table)
        {
            DataTable dt = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandText = Query.FindAllFrom(table);
            Comando.CommandType = CommandType.Text;
            try
            {
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                dt.Load(renglon);
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
            return dt;
        }
    }
}
