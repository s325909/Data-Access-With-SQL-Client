using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using SQL_Client.Models;

namespace SQL_Client.SqlHelpers
{
    public class ConnectExecutionHelper
    {
        /// <summary>
        /// connects to the database and performs CRUD opperations towards the customer table
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="sql"></param>
        /// <returns>true or false if successful</returns>
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

        /// <summary>
        /// connects to the database and returns a specific customer from the customerId
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="id"></param>
        /// <returns>a Customer with the provided customerId</returns>
        public static Customer GetCustomerById(string sql, int id)
        {
            try
            {
                // Connect
                using (SqlConnection connection = new(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand cmd = new(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", id);
                        return DataReadHelper.GetCustomer(cmd);
                    };
                };
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.ToString());
            }

            return new Customer();
        }

        /// <summary>
        /// connects to the database and returns a specific customer with a matching fistname or lastname
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="name"></param>
        /// <returns>a Customer with the name provided</returns>
        public static Customer GetCustomerByName(string sql, string name)
        {
            try
            {
                // Connect
                using (SqlConnection connection = new(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand cmd = new(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", name);
                        cmd.Parameters.AddWithValue("@LastName", name);

                        return DataReadHelper.GetCustomer(cmd);
                    };
                };
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return new Customer();
        }

        /// <summary>
        /// connects to the database and returns every customer from the customer table
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>a list of Customer</returns>
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

        /// <summary>
        /// connects to the database and returns a page of customer from the database based on the limit and offset
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns>a list of Customer</returns>
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

        /// <summary>
        /// connects to the database and returns the number of customers from each country
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>list of CustomerCountries</returns>
        public static List<CustomerCountry> GetCustomerCountry(string sql)
        {
            List<CustomerCountry> customerCountries = new();
              
            try
            {
                // Connect
                using (SqlConnection connection = new(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand cmd = new(sql, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerCountry customerCountry = new();
                                customerCountry.CountryName = reader.GetString(0);
                                customerCountry.CustomerCount = reader.GetInt32(1);
                                customerCountries.Add(customerCountry);
                            }
                        };
                    };
                };
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return customerCountries;
        }

        /// <summary>
        /// connects to the database and returns the highest (customer) spenders
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>a list of CustomerSpender</returns>
        public static List<CustomerSpender> GetCustomerSpenders(string sql)
        {
            List<CustomerSpender> customerSpenders = new(); 

            try
            {
                // Connect
                using (SqlConnection connection = new(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand cmd = new(sql, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerSpender spender = new();
                                spender.SpenderTotalAmount = reader.GetDecimal(0);
                                spender.SpenderFirstName = reader.GetString(1);
                                spender.SpenderLastName = reader.GetString(2);
                                customerSpenders.Add(spender);
                            }
                        };
                    };
                };
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return customerSpenders;
        }

        /// <summary>
        /// connects to the database and returns the most popular genre of a customer 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="customerId"></param>
        /// <returns>a list of CustomerGenre</returns>
        public static List<CustomerGenre> GetCustomerMostPopularGenre(string sql, int customerId) 
        {
            List<CustomerGenre> customerGenres = new(); 
            try
            {
                // connect to the database
                using (SqlConnection connection = new(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand cmd = new(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerGenre customerGenre = new();
                                customerGenre.GenreName = reader.GetString(0);
                                customerGenre.CustomerFirstName = reader.GetString(1);
                                customerGenre.CustomerLastName = reader.GetString(2);
                                customerGenre.GenreCount = reader.GetInt32(3);
                                customerGenres.Add(customerGenre);
                            }
                        };
                    };
                };
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return customerGenres;
        }
    }
}
