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
    public class DatosEmploye
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public DatosEmploye()
        {
            CadCon = ConfigurationManager.ConnectionStrings["centroEscolar"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public int addEmployLocal(LocalEmploye employe)
        {

            int idRecuperado = 0;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_addTabajadorLocal";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@matricula", SqlDbType.VarChar, 30));
                Comando.Parameters["@matricula"].Value = employe.matricula;
                Comando.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 40));
                Comando.Parameters["@nombre"].Value = employe.nombres;
                Comando.Parameters.Add(new SqlParameter("@apellidoP", SqlDbType.VarChar, 20));
                Comando.Parameters["@apellidoP"].Value = employe.apellidoP;
                Comando.Parameters.Add(new SqlParameter("@apellidoM", SqlDbType.VarChar, 20));
                Comando.Parameters["@apellidoM"].Value = employe.apellidoM;
                Comando.Parameters.Add(new SqlParameter("@curp", SqlDbType.VarChar, 100));
                Comando.Parameters["@curp"].Value = employe.curp;
                Comando.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar, 100));
                Comando.Parameters["@pass"].Value = employe.pass;
                Comando.Parameters.Add(new SqlParameter("@correoP", SqlDbType.VarChar, 50));
                Comando.Parameters["@correoP"].Value = employe.correoP;
                Comando.Parameters.Add(new SqlParameter("@correoIns", SqlDbType.VarChar, 50));
                Comando.Parameters["@correoIns"].Value = employe.correoIns;
                Comando.Parameters.Add(new SqlParameter("@telefono", SqlDbType.VarChar, 30));
                Comando.Parameters["@telefono"].Value = employe.telefono;
                Comando.Parameters.Add(new SqlParameter("@fechaNac", SqlDbType.DateTime));
                Comando.Parameters["@fechaNac"].Value = employe.fechaNac;
                Comando.Parameters.Add(new SqlParameter("@image", SqlDbType.Text));
                Comando.Parameters["@image"].Value = employe.image;
                Comando.Parameters.Add(new SqlParameter("@fkAddress", SqlDbType.Int));
                Comando.Parameters["@fkAddress"].Value = employe.fkAddress;
                Comando.Parameters.Add(new SqlParameter("@fkStatusUser", SqlDbType.VarChar,50));
                Comando.Parameters["@fkStatusUser"].Value = employe.fkStatusUser;
                Comando.Parameters.Add(new SqlParameter("@fileName", SqlDbType.VarChar, 50));
                Comando.Parameters["@fileName"].Value = employe.fileName;
                Conexion.Open();
                idRecuperado = (int)Comando.ExecuteScalar();
            }
            catch (SqlException e)
            {                
                
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
        public bool updateEmployLocal(LocalEmploye employe)
        {

            bool ban=false;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_updateEmployeLocal";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = employe.id;
                Comando.Parameters.Add(new SqlParameter("@nombres", SqlDbType.VarChar, 40));
                Comando.Parameters["@nombres"].Value = employe.nombres;
                Comando.Parameters.Add(new SqlParameter("@apellidoP", SqlDbType.VarChar, 20));
                Comando.Parameters["@apellidoP"].Value = employe.apellidoP;
                Comando.Parameters.Add(new SqlParameter("@apellidoM", SqlDbType.VarChar, 20));
                Comando.Parameters["@apellidoM"].Value = employe.apellidoM;
                Comando.Parameters.Add(new SqlParameter("@correoP", SqlDbType.VarChar, 50));
                Comando.Parameters["@correoP"].Value = employe.correoP;
                Comando.Parameters.Add(new SqlParameter("@curp", SqlDbType.VarChar, 100));
                Comando.Parameters["@curp"].Value = employe.curp;
                Comando.Parameters.Add(new SqlParameter("@telefono", SqlDbType.VarChar, 30));
                Comando.Parameters["@telefono"].Value = employe.telefono;
                Comando.Parameters.Add(new SqlParameter("@fechaNac", SqlDbType.DateTime));
                Comando.Parameters["@fechaNac"].Value = employe.fechaNac;
                Comando.Parameters.Add(new SqlParameter("@image", SqlDbType.Text));
                Comando.Parameters["@image"].Value = employe.image;
                Comando.Parameters.Add(new SqlParameter("@fileName", SqlDbType.VarChar,50));
                Comando.Parameters["@fileName"].Value = employe.fileName;
                Conexion.Open();
                Comando.ExecuteNonQuery();
                ban = true;
            }
            catch (SqlException e)
            {
                ban = false;
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
        public int addEmployGeneral(GeneralEmploye employe)
        {

            int idRecuperado = 0;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_addTabajadorGeneral";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@matricula", SqlDbType.VarChar, 30));
                Comando.Parameters["@matricula"].Value = employe.matricula;
                Comando.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 40));
                Comando.Parameters["@nombre"].Value = employe.nombres;
                Comando.Parameters.Add(new SqlParameter("@apellidoP", SqlDbType.VarChar, 20));
                Comando.Parameters["@apellidoP"].Value = employe.apellidoP;
                Comando.Parameters.Add(new SqlParameter("@apellidoM", SqlDbType.VarChar, 20));
                Comando.Parameters["@apellidoM"].Value = employe.apellidoM;
                Comando.Parameters.Add(new SqlParameter("@curp", SqlDbType.VarChar, 100));
                Comando.Parameters["@curp"].Value = employe.curp;
                Comando.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar, 100));
                Comando.Parameters["@pass"].Value = employe.pass;
                Comando.Parameters.Add(new SqlParameter("@correoP", SqlDbType.VarChar, 50));
                Comando.Parameters["@correoP"].Value = employe.correoP;
                Comando.Parameters.Add(new SqlParameter("@correoIns", SqlDbType.VarChar, 50));
                Comando.Parameters["@correoIns"].Value = employe.correoIns;
                Comando.Parameters.Add(new SqlParameter("@telefono", SqlDbType.VarChar, 30));
                Comando.Parameters["@telefono"].Value = employe.telefono;
                Comando.Parameters.Add(new SqlParameter("@fechaNac", SqlDbType.DateTime));
                Comando.Parameters["@fechaNac"].Value = employe.fechaNac;
                Comando.Parameters.Add(new SqlParameter("@fkAddress", SqlDbType.Int));
                Comando.Parameters["@fkAddress"].Value = employe.fkAddress;
                Comando.Parameters.Add(new SqlParameter("@image", SqlDbType.Text));
                Comando.Parameters["@image"].Value = employe.image;
                Comando.Parameters.Add(new SqlParameter("@fkStatusUser", SqlDbType.VarChar,50));
                Comando.Parameters["@fkStatusUser"].Value = employe.fkStatusUser;
                Comando.Parameters.Add(new SqlParameter("@fileName", SqlDbType.VarChar, 50));
                Comando.Parameters["@fileName"].Value = employe.fileName;
                Conexion.Open();
                idRecuperado = (int)Comando.ExecuteScalar();
            }
            catch (SqlException e)
            {

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
        public bool updateEmployGeneral(GeneralEmploye employe)
        {

            bool ban = false;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_updateEmployeGeneral";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = employe.id;
                Comando.Parameters.Add(new SqlParameter("@nombres", SqlDbType.VarChar, 40));
                Comando.Parameters["@nombres"].Value = employe.nombres;
                Comando.Parameters.Add(new SqlParameter("@apellidoP", SqlDbType.VarChar, 20));
                Comando.Parameters["@apellidoP"].Value = employe.apellidoP;
                Comando.Parameters.Add(new SqlParameter("@curp", SqlDbType.VarChar, 100));
                Comando.Parameters["@curp"].Value = employe.curp;
                Comando.Parameters.Add(new SqlParameter("@apellidoM", SqlDbType.VarChar, 20));
                Comando.Parameters["@apellidoM"].Value = employe.apellidoM;
                Comando.Parameters.Add(new SqlParameter("@correoP", SqlDbType.VarChar, 50));
                Comando.Parameters["@correoP"].Value = employe.correoP;
                Comando.Parameters.Add(new SqlParameter("@telefono", SqlDbType.VarChar, 30));
                Comando.Parameters["@telefono"].Value = employe.telefono;
                Comando.Parameters.Add(new SqlParameter("@fechaNac", SqlDbType.DateTime));
                Comando.Parameters["@fechaNac"].Value = employe.fechaNac;
                Comando.Parameters.Add(new SqlParameter("@image", SqlDbType.Text));
                Comando.Parameters["@image"].Value = employe.image;
                Comando.Parameters.Add(new SqlParameter("@fileName", SqlDbType.VarChar, 50));
                Comando.Parameters["@fileName"].Value = employe.fileName;
                Conexion.Open();
                Comando.ExecuteNonQuery();
                ban = true;
            }
            catch (SqlException e)
            {
                ban = false;
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
        public DataTable tableEmployesLocales()
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_innerEmployesLocales";
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
        public DataTable tableEmployeLocaleByIDEmploye(int idEmploye)
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_innerEmployesLocalesByidEmploye";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@idEmploye", SqlDbType.Int));
                Comando.Parameters["@idEmploye"].Value = idEmploye;
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
        public DataTable tableEmployeGeneralByIDEmploye(int idEmploye)
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_innerEmployesGeneralesByidEmploye";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@idEmploye", SqlDbType.Int));
                Comando.Parameters["@idEmploye"].Value = idEmploye;
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
        public DataTable tableEmployesGenerales()
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_innerEmployesGenerales";
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
        public LocalEmploye recoverData(int id)
        {
            SqlDataReader renglon;
            LocalEmploye employeLocal = null;
            try
            {

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_employeLocalByIdEmploye";
                Comando.Parameters.Add(new SqlParameter("@idEmploye", SqlDbType.Int));
                Comando.Parameters["@idEmploye"].Value = id;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                if (renglon.Read())
                {
                    employeLocal = new LocalEmploye(renglon);
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
            return employeLocal;
        }
        public List<LocalEmploye> listEmployesDivisions()
        {
            List<LocalEmploye> employesDivisions = new List<LocalEmploye>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listEmployesDivisions";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    employesDivisions.Add(new LocalEmploye(renglon));
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
            return employesDivisions;
        }
        public List<GeneralEmploye> listEmployesGenerales()
        {
            List<GeneralEmploye> employesGeneral = new List<GeneralEmploye>();

            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listEmployesGeneral";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    employesGeneral.Add(new GeneralEmploye(renglon));
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
            return employesGeneral;
        }
        public DataTable tableEmployesLocalesByMatchingCharacterss(string characters)
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_innerEmployesLocalesByCharacters";
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
        public DataTable tableEmployesGeneralesByMatchingCharacterss(string characters)
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_innerEmployesGeneralesByCharacters";
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
        public DataTable tableRolesByEmployeLocalID(int idEmploye)
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_rolesByEmployeLocalID";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = idEmploye;
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
        public DataTable tableRolesByEmployeGenerallID(int idEmploye)
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_rolesByEmployeGeneralID";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = idEmploye;
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

        public DataTable privilegesByEmployeGeneralID(int idEmploye)
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_privilegesByEmployeGeneralID";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = idEmploye;
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
        public DataTable privilegesByEmployeLocalID(int idEmploye)
        {
            DataTable candidates = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_privilegesByEmployeLocalID";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = idEmploye;
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
