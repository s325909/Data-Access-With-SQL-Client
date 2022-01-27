using System.Collections.Generic;
using SQL_Client.Models;
using SQL_Client.SqlHelpers;

namespace SQL_Client.Repositories
{
    public class CustomerCountryRepo : ICustomerCountryRepo
    {
        /// <summary>
        /// connects to the database and uses SQL Select query and returns the number of customers from each country
        /// </summary>
        /// <returns>a list of CustomerCountry</returns>
        public List<CustomerCountry> GetCustomerCountries()
        {
            string sql = "SELECT Country, COUNT(CustomerId) AS Quantity FROM CUSTOMER " +
                "GROUP BY Country ORDER BY Country DESC";
            return ConnectExecutionHelper.GetCustomerCountry(sql);
        }
    }
}
