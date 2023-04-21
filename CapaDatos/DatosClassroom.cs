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
    public class DatosClassroom
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public DatosClassroom()
        {
            CadCon = ConfigurationManager.ConnectionStrings["centroEscolar"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public bool updateClassroom(Classroom classroom)
        {

            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_updatClassroom";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = classroom.idSalon;
                Comando.Parameters.Add(new SqlParameter("@clave", SqlDbType.VarChar, 30));
                Comando.Parameters["@clave"].Value = classroom.clave;
                Comando.Parameters.Add(new SqlParameter("@cupo", SqlDbType.Int));
                Comando.Parameters["@cupo"].Value = classroom.cupo;
                Comando.Parameters.Add(new SqlParameter("@fkEdificio", SqlDbType.Int));
                Comando.Parameters["@fkEdificio"].Value = classroom.fkEdificio;
                Comando.Parameters.Add(new SqlParameter("@fkTipoSalon", SqlDbType.Int));
                Comando.Parameters["@fkTipoSalon"].Value = classroom.fkTipoSalon;
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
        public bool add(Classroom classroom)
        {

            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_addClassroom";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@clave", SqlDbType.VarChar, 30));
                Comando.Parameters["@clave"].Value = classroom.clave;
                Comando.Parameters.Add(new SqlParameter("@cupo", SqlDbType.Int));
                Comando.Parameters["@cupo"].Value = classroom.cupo;
                Comando.Parameters.Add(new SqlParameter("@fkEdificio", SqlDbType.Int));
                Comando.Parameters["@fkEdificio"].Value = classroom.fkEdificio;
                Comando.Parameters.Add(new SqlParameter("@fkTipoSalon", SqlDbType.Int));
                Comando.Parameters["@fkTipoSalon"].Value = classroom.fkTipoSalon;
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
        public List<Classroom> listarClassrooms()
        {
            List<Classroom> classrooms = new List<Classroom>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listClassroom";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    classrooms.Add(new Classroom(renglon));
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
            return classrooms;
        }
        public List<Classroom> listarClassroomsXFkEdificio(int id)
        {
            List<Classroom> classrooms = new List<Classroom>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_classroomByfkEdificio";
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = id;
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    classrooms.Add(new Classroom(renglon));
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
            return classrooms;
        }
        public List<Classroom> listarClassroomsXFkTipoSalon(int id)
        {
            List<Classroom> classrooms = new List<Classroom>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_classroomByfkTipoSalon";
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = id;
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    classrooms.Add(new Classroom(renglon));
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
            return classrooms;
        }
        public Classroom recoverData(int id)
        {
            SqlDataReader renglon;
            Classroom classroom = null;
            try
            {

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_classroomByClassroom";
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = id;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                if (renglon.Read())
                {
                    classroom = new Classroom(renglon);
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
            return classroom;
        }
        public bool eliminarClassrooms(string strIds)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_deleteClassrooms";
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
        public DataTable tableClassroomsByMatchingCharacterss(string characters)
        {
            DataTable classrooms = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_innerSalonesByCharacters";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@characters", SqlDbType.Text));
                Comando.Parameters["@characters"].Value = characters;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                classrooms.Load(renglon);
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
            return classrooms;
        }
        public DataTable tableClassrooms()
        {
            DataTable classrooms = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_innerSalones";
            try
            {              
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                classrooms.Load(renglon);
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
            return classrooms;
        }
        public DataTable tableClassroomsByEdif(int fkEdif)
        {
            DataTable classrooms = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_innerSalonesByFkEdif";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = fkEdif;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                classrooms.Load(renglon);
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
            return classrooms;
        }
        public DataTable tableClassroomsByCarrers(int fkCarrer)
        {
            DataTable classrooms = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_innerSalonesByFkCarrer";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = fkCarrer;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                classrooms.Load(renglon);
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
            return classrooms;
        }
        public DataTable tableClassroomsByTypeClassroom(int fkTypeClassroom)
        {
            DataTable classrooms = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_innerSalonesByFkTypeClassroom";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = fkTypeClassroom;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                classrooms.Load(renglon);
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
            return classrooms;
        }
    }
}
