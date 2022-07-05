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
    }
}
