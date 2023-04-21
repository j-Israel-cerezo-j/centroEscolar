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
    public class UniversityDatos
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public UniversityDatos()
        {
            CadCon = ConfigurationManager.ConnectionStrings["pollster"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public bool add(University university)
        {

            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_addUniversity";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@universidad_nombre", SqlDbType.VarChar, 100));
                Comando.Parameters["@universidad_nombre"].Value = university.universidad_nombre;
                Comando.Parameters.Add(new SqlParameter("@universidad_fecha_fundacion", SqlDbType.VarChar, 100));
                Comando.Parameters["@universidad_fecha_fundacion"].Value = university.universidad_fecha_fundacion;
                Comando.Parameters.Add(new SqlParameter("@universidad_adscripcion", SqlDbType.VarChar, 100));
                Comando.Parameters["@universidad_adscripcion"].Value = university.universidad_adscripcion;
                Comando.Parameters.Add(new SqlParameter("@universidad_calle_numero", SqlDbType.VarChar, 100));
                Comando.Parameters["@universidad_calle_numero"].Value = university.universidad_calle_numero;
                Comando.Parameters.Add(new SqlParameter("@universidad_colonia", SqlDbType.VarChar, 100));
                Comando.Parameters["@universidad_colonia"].Value = university.universidad_colonia;
                Comando.Parameters.Add(new SqlParameter("@universidad_cp", SqlDbType.VarChar, 100));
                Comando.Parameters["@universidad_cp"].Value = university.universidad_cp;
                Comando.Parameters.Add(new SqlParameter("@universidad_telefono1", SqlDbType.VarChar, 100));
                Comando.Parameters["@universidad_telefono1"].Value = university.universidad_telefono1;
                Comando.Parameters.Add(new SqlParameter("@pagina_web", SqlDbType.VarChar, 100));
                Comando.Parameters["@pagina_web"].Value = university.pagina_web;
                Comando.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 100));
                Comando.Parameters["@email"].Value = university.email;
                Comando.Parameters.Add(new SqlParameter("@gmaps_latitud", SqlDbType.VarChar, 100));
                Comando.Parameters["@gmaps_latitud"].Value = university.gmaps_latitud;
                Comando.Parameters.Add(new SqlParameter("@gmaps_longitud", SqlDbType.VarChar, 100));
                Comando.Parameters["@gmaps_longitud"].Value = university.gmaps_longitud;
                Comando.Parameters.Add(new SqlParameter("@nom_ent", SqlDbType.VarChar, 100));
                Comando.Parameters["@nom_ent"].Value = university.nom_ent;
                Comando.Parameters.Add(new SqlParameter("@nom_mun", SqlDbType.VarChar, 100));
                Comando.Parameters["@nom_mun"].Value = university.nom_mun;
                Comando.Parameters.Add(new SqlParameter("@nom_loc", SqlDbType.VarChar, 100));
                Comando.Parameters["@nom_loc"].Value = university.nom_loc;
                Comando.Parameters.Add(new SqlParameter("@link_sic", SqlDbType.VarChar, 100));
                Comando.Parameters["@link_sic"].Value = university.link_sic;
                Comando.Parameters.Add(new SqlParameter("@fecha_mod", SqlDbType.VarChar, 100));
                Comando.Parameters["@fecha_mod"].Value = university.fecha_mod;
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
        public DataTable tableUniversitysByMatchingCharacterss(string characters)
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_UniversitysByMatchingCharacterss";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@characters", SqlDbType.Text));
                Comando.Parameters["@characters"].Value = characters;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                candidates.Load(renglon);
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
            return candidates;
        }
        public int countResponseByUniversity(int idUniversity)
        {

            int countResponseByCategory = 0;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_countResponseByUniversity";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@idUniversity", SqlDbType.Int));
                Comando.Parameters["@idUniversity"].Value = idUniversity;
                Conexion.Open();
                countResponseByCategory = (int)Comando.ExecuteScalar();
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
            return countResponseByCategory;
        }
        public List<University> listUniversitys()
        {
            List<University> universitys = new List<University>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listUniversitys";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    universitys.Add(new University(renglon));
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
            return universitys;
        }

        public DataTable universitysVotate()
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_universitysVotate";
            try
            {               
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                candidates.Load(renglon);
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
            return candidates;
        }


        public DataTable listIdsUniversitysVotate()
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_listIdsUniversitysVotate";
            try
            {
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                candidates.Load(renglon);
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
            return candidates;
        }
    }
}
