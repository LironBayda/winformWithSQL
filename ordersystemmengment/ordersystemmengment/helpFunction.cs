using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordersystemmengment
{
    class helpFunction
    {
        static string connectionString= "Initial Catalog=winfromHW;"
        + "Integrated Security=true;";

        public static void CreateCommandNonQuery(string queryString)
        {
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();

            }
        }

        public static void ReadOrderData( string queryString)
        {

            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["x_value"]} {reader["operator_type"]} {reader["y_value"]} " +
                            $"= {reader["results"]}");
                    }

                }
            }
        }


        public static bool IsSqlDataReaderNotEmpty(string queryString)
        {
            bool SqlDataReaderNotEmpty;

            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    SqlDataReaderNotEmpty = reader.HasRows;
                }
                connection.Close();

                return SqlDataReaderNotEmpty;
            }
        }



    }
}
