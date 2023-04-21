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
    public class DatosGroup
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public DatosGroup()
        {
            CadCon = ConfigurationManager.ConnectionStrings["centroEscolar"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public bool updateGroup(Group gorup)
        {

            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_updateGroup";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = gorup.idGrupo;
                Comando.Parameters.Add(new SqlParameter("@group", SqlDbType.VarChar, 30));
                Comando.Parameters["@group"].Value = gorup.nombre;
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
        public int add(Group group)
        {

            int idGrupoRecuperado=0;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_addGroup";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@group", SqlDbType.VarChar, 20));
                Comando.Parameters["@group"].Value = group.nombre;
                Conexion.Open();
                idGrupoRecuperado = (int)Comando.ExecuteScalar();                               
            }
            catch (Exception e)
            {                
                throw new DaoException(e.Message);
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
                Comando.Parameters.Clear();
            }
            return idGrupoRecuperado;
        }
        public List<Group> listarGroups()
        {
            List<Group> groups = new List<Group>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listarGroups";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    groups.Add(new Group(renglon));
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
            return groups;
        }
        public Group recoverData(int id)
        {
            SqlDataReader renglon;
            Group group = null;
            try
            {

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_groupXgroup";
                Comando.Parameters.Add(new SqlParameter("@idGrupo", SqlDbType.Int));
                Comando.Parameters["@idGrupo"].Value = id;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                if (renglon.Read())
                {
                    group = new Group(renglon);
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
            return group;
        }
        public bool eliminarGroups(string strIds)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "por_deleteGroups";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@idGroups", SqlDbType.VarChar));
                Comando.Parameters["@idGroups"].Value = strIds;
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
        public DataTable tableGroups()
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_innerGroups";
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
