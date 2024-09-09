using Microsoft.Data.SqlClient;
using System.Data;

namespace proyecto_Practica01_.Utils
{
    public class DataHelper
    {
        private static DataHelper instance;
        private SqlConnection connection;

        private DataHelper()
        {
            connection = new SqlConnection("Data Source=DESKTOP-D9HIG3PSQLEXPRESS1;Initial Catalog=FacturacionTPI;Integrated Security=True");
        }

        public static DataHelper GetInstance()
        {
            if (instance == null)
                instance = new DataHelper();
            return instance;
        }


        public DataTable ExecuteSPQuery(string sp, List<ParameterSQL>? parameters)
        {
            DataTable t = new DataTable();
            SqlCommand cmd = null;

            try
            {
                connection.Open();
                cmd = new SqlCommand(sp, connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach (var param in parameters)
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                }

                t.Load(cmd.ExecuteReader());
            }
            catch (SqlException)
            { t = null; }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    {
                    connection.Close();
                }
            }
            return t;
        }

        public int ExecuteSPIF(string sp, List<ParameterSQL>? parametros)
        {
            int rows;
            try
            {
                connection.Open();
                var cmd = new SqlCommand(sp, connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (var param in parametros)
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                }

                rows = cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException)
            {
                rows = 0;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection?.Close();
                }
            }
            return rows;
        }








    }


}
