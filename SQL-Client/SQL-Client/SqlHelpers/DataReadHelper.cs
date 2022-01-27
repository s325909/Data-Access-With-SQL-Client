using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using SQL_Client.Models;

namespace SQL_Client.SqlHelpers
{
    public class DataReadHelper
    {
        /// <summary>
        /// functions takes in a SqlCommand and uses SqlDataReader to get customers from the database
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>list of customers</returns>
        public static List<Customer> GetCustomers(SqlCommand cmd)
        {
            var customersList = new List<Customer>();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Customer tmpCustomer = GetReaderCustomer(reader);

                    customersList.Add(tmpCustomer);
                }
            };

            return customersList;
        }

        /// <summary>
        /// functions takes in a SqlCommand and uses SqlDataReader to get a customer from the database
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>returns a customer</returns>
        public static Customer GetCustomer(SqlCommand cmd)
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    return GetReaderCustomer(reader); ;
                }
            };

            return new Customer();
        }

        /// <summary>
        /// function that helps read customer data from customer table while also checking for null values
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>retunds customer object with corresponding data read from table</returns>
        private static Customer GetReaderCustomer(SqlDataReader reader)
        {
            Customer customer = new();
            customer.CustomerId = reader.GetInt32(0);

            if (!reader.IsDBNull(1))
                customer.FirstName = reader.GetString(1);

            if (!reader.IsDBNull(2))
                customer.LastName = reader.GetString(2);

            if (!reader.IsDBNull(3))
                customer.Country = reader.GetString(3);

            if (!reader.IsDBNull(4))
                customer.PostalCode = reader.GetString(4);

            if (!reader.IsDBNull(5))
                customer.PhoneNumber = reader.GetString(5);

            if (!reader.IsDBNull(6))
                customer.Email = reader.GetString(6);

            return customer;
        }
    }
}
