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

namespace CapaDatos
{
    public class DatosDomicilio
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public DatosDomicilio()
        {
            CadCon = ConfigurationManager.ConnectionStrings["centroEscolar"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public bool add(Domicilie domicilie)
        {

            bool ban = false;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_addDomicilio";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@calle", SqlDbType.VarChar, 50));
                Comando.Parameters["@calle"].Value = domicilie.calle;
                Comando.Parameters.Add(new SqlParameter("@noInterior", SqlDbType.VarChar, 6));
                Comando.Parameters["@noInterior"].Value = domicilie.noInterior;
                Comando.Parameters.Add(new SqlParameter("@noExterior", SqlDbType.VarChar, 6));
                Comando.Parameters["@noExterior"].Value = domicilie.noExterior;
                Comando.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar, 50));
                Comando.Parameters["@estado"].Value = domicilie.estado;
                Comando.Parameters.Add(new SqlParameter("@municipio", SqlDbType.VarChar, 50));
                Comando.Parameters["@municipio"].Value = domicilie.municipio;
                Comando.Parameters.Add(new SqlParameter("@cp", SqlDbType.VarChar, 10));
                Comando.Parameters["@cp"].Value = domicilie.cp;
                Comando.Parameters.Add(new SqlParameter("@colonia", SqlDbType.VarChar, 50));
                Comando.Parameters["@colonia"].Value = domicilie.colonia;
                Comando.Parameters.Add(new SqlParameter("@fkAlumno", SqlDbType.Int));
                Comando.Parameters["@fkAlumno"].Value = domicilie.fkAlumno;
                Conexion.Open();
                Comando.ExecuteNonQuery();
                ban =true;
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
        public bool updateAddress(Domicilie domicilie)
        {

            bool ban = false;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_updateAddres";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@idDomicilie", SqlDbType.Int));
                Comando.Parameters["@idDomicilie"].Value = domicilie.idDomicilio;
                Comando.Parameters.Add(new SqlParameter("@calle", SqlDbType.VarChar, 50));
                Comando.Parameters["@calle"].Value = domicilie.calle;
                Comando.Parameters.Add(new SqlParameter("@noInterior", SqlDbType.VarChar, 6));
                Comando.Parameters["@noInterior"].Value = domicilie.noInterior;
                Comando.Parameters.Add(new SqlParameter("@noExterior", SqlDbType.VarChar, 6));
                Comando.Parameters["@noExterior"].Value = domicilie.noExterior;
                Comando.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar, 50));
                Comando.Parameters["@estado"].Value = domicilie.estado;
                Comando.Parameters.Add(new SqlParameter("@municipio", SqlDbType.VarChar, 50));
                Comando.Parameters["@municipio"].Value = domicilie.municipio;
                Comando.Parameters.Add(new SqlParameter("@cp", SqlDbType.VarChar, 10));
                Comando.Parameters["@cp"].Value = domicilie.cp;
                Comando.Parameters.Add(new SqlParameter("@colonia", SqlDbType.VarChar, 50));
                Comando.Parameters["@colonia"].Value = domicilie.colonia;
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
        public Domicilie recoverData(int id)
        {
            SqlDataReader renglon;
            Domicilie domicilie = null;
            try
            {

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_recoverDataDomicilieByCandidate";
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = id;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                if (renglon.Read())
                {
                    domicilie = new Domicilie(renglon);
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
            return domicilie;
        }
        public int addAddress(Domicilie domicilie)
        {

            int idRecuperado = 0;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_addAddres";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@calle", SqlDbType.VarChar, 50));
                Comando.Parameters["@calle"].Value = domicilie.calle;
                Comando.Parameters.Add(new SqlParameter("@noInterior", SqlDbType.VarChar, 6));
                Comando.Parameters["@noInterior"].Value = domicilie.noInterior;
                Comando.Parameters.Add(new SqlParameter("@noExterior", SqlDbType.VarChar, 6));
                Comando.Parameters["@noExterior"].Value = domicilie.noExterior;
                Comando.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar, 50));
                Comando.Parameters["@estado"].Value = domicilie.estado;
                Comando.Parameters.Add(new SqlParameter("@municipio", SqlDbType.VarChar, 50));
                Comando.Parameters["@municipio"].Value = domicilie.municipio;
                Comando.Parameters.Add(new SqlParameter("@cp", SqlDbType.VarChar, 10));
                Comando.Parameters["@cp"].Value = domicilie.cp;
                Comando.Parameters.Add(new SqlParameter("@colonia", SqlDbType.VarChar, 50));
                Comando.Parameters["@colonia"].Value = domicilie.colonia;
                Conexion.Open();
                idRecuperado = (int)Comando.ExecuteScalar();
            }
            catch (SqlException e)
            {
                if (e.Message.Contains("duplicate key"))
                {
                    throw new DaoException("Campo duplicado");
                }
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
        public bool eliminarDimicilie(int idDomicilie)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_deleteDomicilie";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@idDomicilie", SqlDbType.Int));
                Comando.Parameters["@idDomicilie"].Value = idDomicilie;
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
        public Domicilie recoverDataAddress(int id)
        {
            SqlDataReader renglon;
            Domicilie domicilie = null;
            try
            {

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_recoverDataAddress";
                Comando.Parameters.Add(new SqlParameter("@idAddress", SqlDbType.Int));
                Comando.Parameters["@idAddress"].Value = id;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                if (renglon.Read())
                {
                    domicilie = new Domicilie(renglon);
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
            return domicilie;
        }
    }
}
