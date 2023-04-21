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
    public class DatosTypeWorker
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public DatosTypeWorker()
        {
            CadCon = ConfigurationManager.ConnectionStrings["centroEscolar"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public bool updateTypeWorker(TypeWorker typeWorker)
        {

            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_updateTypeWorker";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@typeWorker", SqlDbType.VarChar,60));
                Comando.Parameters["@typeWorker"].Value = typeWorker.typeWorker;
                Comando.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar, 60));
                Comando.Parameters["@descripcion"].Value = typeWorker.descripcion;
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
        public bool add(TypeWorker typeWorker)
        {

            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_addTypeWorker";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@typeWorker", SqlDbType.VarChar, 60));
                Comando.Parameters["@typeWorker"].Value = typeWorker.typeWorker;
                Comando.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar, 60));
                Comando.Parameters["@descripcion"].Value = typeWorker.descripcion;
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
        public List<TypeWorker> listarTypesWorkers()
        {
            List<TypeWorker> typesWorkers = new List<TypeWorker>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listTypesWorkers";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    typesWorkers.Add(new TypeWorker(renglon));
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
            return typesWorkers;
        }
        public TypeWorker recoverData(string strtypeWorker)
        {
            SqlDataReader renglon;
            TypeWorker typeWorker = null;
            try
            {

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_typeWorkerXidTypeWorker";
                Comando.Parameters.Add(new SqlParameter("@typeWorker", SqlDbType.VarChar,60));
                Comando.Parameters["@typeWorker"].Value = strtypeWorker;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                if (renglon.Read())
                {
                    typeWorker = new TypeWorker(renglon);
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
            return typeWorker;
        }
        public bool eliminarTypeWorkers(string strIds)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_deleteTypesWorkers";
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
    }
}
