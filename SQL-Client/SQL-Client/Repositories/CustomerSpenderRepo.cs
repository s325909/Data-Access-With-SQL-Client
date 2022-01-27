using System.Collections.Generic;
using SQL_Client.Models;
using SQL_Client.SqlHelpers;

namespace SQL_Client.Repositories
{
    public class CustomerSpenderRepo : ICustomerSpenderRepo
    {
        /// <summary>
        /// connects to the database and uses SQL Select query to returns the top 10 highest (customer) spenders
        /// </summary>
        /// <returns>a list of CustomerSpender</returns>
        public List<CustomerSpender> GetCustomerSpenders()
        {
            string sql = "SELECT TOP 10 SUM(Total) AS SUM, Customer.FirstName, Customer.LastName FROM Invoice ";
            sql += "INNER JOIN Customer ON Customer.CustomerId = Invoice.CustomerId ";
            sql += "GROUP BY Customer.FirstName, Customer.LastName ";
            sql += "ORDER BY SUM DESC";
            return ConnectExecutionHelper.GetCustomerSpenders(sql);
        }
    }
}
