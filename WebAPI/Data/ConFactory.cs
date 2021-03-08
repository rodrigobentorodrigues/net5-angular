using System.Configuration;
using System.Data.SqlClient;

namespace WebAPI.Data
{
    public class ConFactory
    {

        private static SqlConnection connection;

        public static SqlConnection getConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString);
            }

            return connection;
        }

    }
}