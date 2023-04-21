using CapaDatos.Querys;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CapaDatos.binderSurvey
{
    public class InsertManyDatosSurvey
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public InsertManyDatosSurvey()
        {
            CadCon = ConfigurationManager.ConnectionStrings["pollster"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public bool insertMany(string strFieldsUnios, string table)
        {

            bool ban;
            Comando.CommandText = Query.InsertMany(strFieldsUnios, table);
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
    }
}
