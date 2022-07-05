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
    public  class DatosPeriod
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public DatosPeriod()
        {
            CadCon = ConfigurationManager.ConnectionStrings["centroEscolar"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public bool updatePeriod(Period period)
        {

            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_updatePeriod";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = period.idPeriodo;
                Comando.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 30));
                Comando.Parameters["@nombre"].Value = period.nombre;
                Comando.Parameters.Add(new SqlParameter("@fechaInicio", SqlDbType.DateTime));
                Comando.Parameters["@fechaInicio"].Value = period.fechaInicio;
                Comando.Parameters.Add(new SqlParameter("@fechaTermino", SqlDbType.DateTime));
                Comando.Parameters["@fechaTermino"].Value = period.fechaTermino;
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
        public bool add(Period period)
        {

            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_addPeriod";
            try
            {                
                Comando.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 30));
                Comando.Parameters["@nombre"].Value = period.nombre;
                Comando.Parameters.Add(new SqlParameter("@fehaInicio", SqlDbType.DateTime));
                Comando.Parameters["@fehaInicio"].Value = period.fechaInicio;
                Comando.Parameters.Add(new SqlParameter("@fechaTermino", SqlDbType.DateTime));
                Comando.Parameters["@fechaTermino"].Value = period.fechaTermino;
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
        public List<Period> listarPeriods()
        {
            List<Period> periods = new List<Period>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listarPeriods";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    periods.Add(new Period(renglon));
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
            return periods;
        }
        public Period recoverData(int id)
        {
            SqlDataReader renglon;
            Period period = null;
            try
            {

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_periodXidPeriod";
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = id;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                if (renglon.Read())
                {
                    period = new Period(renglon);
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
            return period;
        }
        public bool eliminarPeriods(string strIds)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "por_deletePeriods";
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
