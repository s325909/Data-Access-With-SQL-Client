using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQL_Client.Models;

namespace SQL_Client.SqlHelpers
{
    public class ConnectExecutionHelper
    {
        public static bool CRUDCustomer(Customer customer, string sql)
        {
            bool success = false;
            
            try
            {
                // connects to the database
                using (SqlConnection connection = new(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand cmd = new(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);

                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    };
                };
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return success;
        }

        public static List<Customer> GetAllCustomers(string sql)
        {
            try
            {
                // connect to the database
                using (SqlConnection connection = new(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand cmd = new(sql, connection))
                    {
                        // returns list of customers from the database
                        return DataReadHelper.GetCustomers(cmd);
                    };
                };
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return new List<Customer>();
        }

        public static List<Customer> GetSelectedCustomers(string sql, int limit, int offset)
        {
            var customersList = new List<Customer>();

            try
            {
                // Connect
                using (SqlConnection connection = new(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand cmd = new(sql, connection))
                    {
                        // cmd.Parameters.AddWithValue("@LastName", )
                        cmd.Parameters.AddWithValue("@Limit", limit);
                        cmd.Parameters.AddWithValue("@Offset", offset);

                        return DataReadHelper.GetCustomers(cmd);
                    };
                };
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return customersList;
        }
    }
}
