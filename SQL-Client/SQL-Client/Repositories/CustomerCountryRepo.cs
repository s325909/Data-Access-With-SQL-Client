using SQL_Client.Models;
using SQL_Client.SqlHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Client.Repositories
{
    public class CustomerCountryRepo : ICustomerCountryRepo
    {
        List<CustomerCountry> ICustomerCountryRepo.GetCustomerCountries()
        {
            string sql = "SELECT Country, COUNT(CustomerId) AS Quantity FROM CUSTOMER " +
                "GROUP BY Country ORDER BY Country DESC";
            return ConnectExecutionHelper.GetCustomerCountry(sql);
        }
    }
}
