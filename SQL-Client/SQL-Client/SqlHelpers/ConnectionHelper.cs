using Microsoft.Data.SqlClient;

namespace SQL_Client.SqlHelpers
{
    public class ConnectionHelper
    {
        /// <summary>
        /// uses SqlConnectionStringBuilder to build and return a connection string to the database
        /// </summary>
        /// <returns>a (connection) string</returns>
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new();
            builder.DataSource = @"ND-5CG0255P6M\SQLEXPRESS";
            builder.InitialCatalog = @"Chinook";
            builder.IntegratedSecurity = true;
            builder.TrustServerCertificate = true;
            return builder.ConnectionString;
        }
    }
}
