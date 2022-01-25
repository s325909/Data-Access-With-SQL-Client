using Microsoft.Data.SqlClient;
using SQL_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SQL_Client.SqlHelpers; 

namespace SQL_Client.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        public bool AddNewCustomer(Customer customer)
        {
            string sql = "INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email)";
            sql += " Values (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";

            // SqlCommand sqlCommand = new(sql, ConnectionHelper.GetConnectionString())

            try
            {
                // Connect
                using (SqlConnection connection = new(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand cmd = new(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);

                        cmd.ExecuteNonQuery();

                        return true;
                    };
                };
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return false;
        }

        public bool DeleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(Customer customer)
        {
            // string sql = "UPDATE Customer SET FirstName = @"

            String sql = "Update Customer SET " +
                "FirstName = @FirstName, LastName = @LastName, " +
                "Country = @Country, PostalCode = @PostalCode, " +
                "Phone = @Phone, Email = @Email " +
                "WHERE CustomerID = @CustomerID";

            try
            {
                // Connect
                using (SqlConnection connection = new(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand cmd = new(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);

                        cmd.ExecuteNonQuery();

                        return true;
                    };
                };
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return false;
        }

        public List<Customer> GetAllCustomers()
        {
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";

            var customersList = new List<Customer>();

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
                                Customer tmpCustomer = GetReaderCustomer(reader);

                                customersList.Add(tmpCustomer);
                            }
                        };
                    };
                };
            } catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return customersList;
        }

        public List<Customer> GetAllCustomers(int limit, int offset)
        {
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                "FROM Customer ORDER BY CustomerId OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY";

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


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer tmpCustomer = GetReaderCustomer(reader);

                                customersList.Add(tmpCustomer);
                            }
                        };
                    };
                };
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return customersList;
        }

        public Customer GetCustomer(int id)
        {
            string sql = $"SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                "FROM Customer WHERE CustomerId = @CustomerId";

            try
            {
                // Connect
                using (SqlConnection connection = new(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand cmd = new(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer tmpCustomer = GetReaderCustomer(reader);

                                return tmpCustomer;
                            }
                        };
                    };
                };
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        public Customer GetCustomer(string name)
        {
            string sql = $"SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                //$"FROM Customer WHERE FirstName LIKE '{name}' OR LastName LIKE '{name}'";
                "FROM Customer WHERE FirstName LIKE @FirstName OR LastName LIKE @LastName";

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

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer tmpCustomer = GetReaderCustomer(reader);

                                return tmpCustomer;
                            }
                        };
                    };
                };
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }


        private Customer GetReaderCustomer(SqlDataReader reader)
        {
            Customer customer = new();
            customer.CustomerID = reader.GetInt32(0);

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
