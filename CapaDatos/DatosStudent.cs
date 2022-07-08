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
    public class DatosStudent
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public DatosStudent()
        {
            CadCon = ConfigurationManager.ConnectionStrings["centroEscolar"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public bool updateStudent(Student student)
        {

            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_updateStudent";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = student.idAlumno;
                Comando.Parameters.Add(new SqlParameter("@nombres", SqlDbType.VarChar, 40));
                Comando.Parameters["@nombres"].Value = student.nombres;
                Comando.Parameters.Add(new SqlParameter("@apellidoP", SqlDbType.VarChar, 20));
                Comando.Parameters["@apellidoP"].Value = student.apellidoP;
                Comando.Parameters.Add(new SqlParameter("@apellidoM", SqlDbType.VarChar, 20));
                Comando.Parameters["@apellidoM"].Value = student.apellidoM;
                Comando.Parameters.Add(new SqlParameter("@correoP", SqlDbType.VarChar, 50));
                Comando.Parameters["@correoP"].Value = student.correoP;
                Comando.Parameters.Add(new SqlParameter("@telefono", SqlDbType.VarChar, 30));
                Comando.Parameters["@telefono"].Value = student.telefono;
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
        public bool add(Student student)
        {

            bool ban=false;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_addStudent";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@matricula", SqlDbType.VarChar, 30));
                Comando.Parameters["@matricula"].Value = student.matricula;
                Comando.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 40));
                Comando.Parameters["@nombre"].Value = student.nombres;
                Comando.Parameters.Add(new SqlParameter("@apellidoP", SqlDbType.VarChar, 20));
                Comando.Parameters["@apellidoP"].Value = student.apellidoP;
                Comando.Parameters.Add(new SqlParameter("@apellidoM", SqlDbType.VarChar, 20));
                Comando.Parameters["@apellidoM"].Value = student.apellidoM;
                Comando.Parameters.Add(new SqlParameter("@curp", SqlDbType.VarChar, 100));
                Comando.Parameters["@curp"].Value = student.curp;
                Comando.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar, 100));
                Comando.Parameters["@pass"].Value = student.pass;
                Comando.Parameters.Add(new SqlParameter("@correoP", SqlDbType.VarChar, 50));
                Comando.Parameters["@correoP"].Value = student.correoP;
                Comando.Parameters.Add(new SqlParameter("@telefono", SqlDbType.VarChar, 30));
                Comando.Parameters["@telefono"].Value = student.telefono;
                Comando.Parameters.Add(new SqlParameter("@fkIdDivision", SqlDbType.Int));
                Comando.Parameters["@fkIdDivision"].Value = student.fkIdDivision;
                Comando.Parameters.Add(new SqlParameter("@correoIns", SqlDbType.VarChar, 50));
                Comando.Parameters["@correoIns"].Value = student.correoIns;
                Comando.Parameters.Add(new SqlParameter("@fechaNac", SqlDbType.DateTime));
                Comando.Parameters["@fechaNac"].Value = student.fechaNac;
                Comando.Parameters.Add(new SqlParameter("@fkDomicilie", SqlDbType.Int));
                Comando.Parameters["@fkDomicilie"].Value = student.fkDomicilio;
                Conexion.Open();
                Comando.ExecuteNonQuery();
                ban = true;
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
            return ban;
        }
        public List<Student> listarStudents()
        {
            List<Student> students = new List<Student>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listStudents";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    students.Add(new Student(renglon));
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
            return students;
        }
        public Student recoverData(int id)
        {
            SqlDataReader renglon;
            Student student = null;
            try
            {

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_studentXidStudent";
                Comando.Parameters.Add(new SqlParameter("@idStudent", SqlDbType.Int));
                Comando.Parameters["@idStudent"].Value = id;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                if (renglon.Read())
                {
                    student = new Student(renglon);
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
            return student;
        }
        public Student recoverDataByMatricula(string matricula)
        {
            SqlDataReader renglon;
            Student student = null;
            try
            {

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_recoverDataStudentByMatricula";
                Comando.Parameters.Add(new SqlParameter("@matricula", SqlDbType.VarChar,30));
                Comando.Parameters["@matricula"].Value = matricula;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                if (renglon.Read())
                {
                    student = new Student(renglon);
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
            return student;
        }
        public bool eliminarStudent(string strIds)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "por_deleteStudent";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@idAlumnos", SqlDbType.VarChar));
                Comando.Parameters["@idAlumnos"].Value = strIds;
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
        public bool eliminarStudentByMatricula(string matricula)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_deleteStudentByMatricula";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@matricula", SqlDbType.VarChar,30));
                Comando.Parameters["@matricula"].Value = matricula;
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
        public DataTable tableStudents()
        {
            DataTable students = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_innerStudent";
            try
            {
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                students.Load(renglon);
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
            return students;
        }
        public DataTable tableStudentsByIdDivision(int id)
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_innerStudentByIdDivision";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@idDivision", SqlDbType.Int));
                Comando.Parameters["@idDivision"].Value = id;
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
        public DataTable datasStudentt(int id)
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_innerDatasStudent";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@idStudent", SqlDbType.Int));
                Comando.Parameters["@idStudent"].Value = id;
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
