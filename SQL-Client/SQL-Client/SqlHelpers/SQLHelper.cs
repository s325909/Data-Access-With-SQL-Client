using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Client.SqlHelpers
{
    public class SQLHelper
    {

        public static string ConnectionString() 
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
