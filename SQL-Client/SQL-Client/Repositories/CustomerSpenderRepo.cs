using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQL_Client.Models;
using SQL_Client.Repositories;
using SQL_Client.SqlHelpers;

namespace SQL_Client.Repositories
{
    public class CustomerSpenderRepo : ICustomerSpenderRepo
    {
        public List<CustomerSpender> GetCustomerSpenders()
        {
            string sql = "SELECT SUM(Total) AS SUM, Customer.FirstName, Customer.LastName FROM Invoice ";
            sql += "INNER JOIN Customer ON Customer.CustomerId = Invoice.CustomerId ";
            sql += "GROUP BY Customer.FirstName, Customer.LastName ";
            sql += "ORDER BY SUM DESC";
            return ConnectExecutionHelper.GetCustomerSpenders(sql);
        }
    }
}
