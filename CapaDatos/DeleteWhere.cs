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
    public class DeleteWhere
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public DeleteWhere(string setConectionStrName)
        {
            CadCon = ConfigurationManager.ConnectionStrings[setConectionStrName].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public bool where(string table,string field,string valueField)
        {
           bool ban=false;
            Comando.Connection = Conexion;
            Comando.CommandText = Query.deleteWhere(table, field, valueField);
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
        public bool whereIn(string table, string field, List<string> valuesField)
        {
            bool ban = false;
            Comando.Connection = Conexion;
            Comando.CommandText = Query.deleteWhereIn(table, field, valuesField);
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
        public bool whereIn(string table, string field,string strValuesField)
        {
            bool ban = false;
            Comando.Connection = Conexion;
            Comando.CommandText = Query.deleteWhereIn(table, field, strValuesField);
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
                throw new DaoException("Error al eliminar");
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

        public bool whereInAnd(Dictionary<string, string> campos, string table)
        {
            bool ban = false;
            Comando.Connection = Conexion;
            Comando.CommandText = Query.deleteWhereAnd(campos,table);
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
                throw new DaoException("Error al eliminar");
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
