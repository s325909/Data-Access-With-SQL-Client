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
        public List<Customer> GetAllCustomers()
        {
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            return ConnectExecutionHelper.GetAllCustomers(sql);
        }

        public List<Customer> GetAllCustomers(int limit, int offset)
        {
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                "FROM Customer ORDER BY CustomerId OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY";
            return ConnectExecutionHelper.GetSelectedCustomers(sql, limit, offset);
        }

        public Customer GetCustomer(int id)
        {
            string sql = $"SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                "FROM Customer WHERE CustomerId = @CustomerId";
            return ConnectExecutionHelper.GetCustomerById(sql, id);
        }

        public Customer GetCustomer(string name)
        {
            string sql = $"SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                "FROM Customer WHERE FirstName LIKE @FirstName OR LastName LIKE @LastName";
            return ConnectExecutionHelper.GetCustomerByName(sql, name);
        }

        public bool CreateCustomer(Customer customer)
        {
            string sql = "INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email)";
            sql += " Values (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";
            return ConnectExecutionHelper.CRUDCustomer(customer, sql);
        }

        public bool UpdateCustomer(Customer customer)
        {
            string sql = "Update Customer ";
            sql += "SET FirstName = @FirstName, LastName = @LastName, Country = @Country, PostalCode = @PostalCode, Phone = @Phone, Email = @Email ";
            sql += "WHERE CustomerId = @CustomerId";
            return ConnectExecutionHelper.CRUDCustomer(customer, sql);
        }

        public bool DeleteCustomer(Customer customer)
        {
            string sql = "DELETE FROM Customer WHERE CustomerId = @CustomerId";
            return ConnectExecutionHelper.CRUDCustomer(customer, sql);
        }




        // MOVE TO SEPERATE CUSTOMERCOUNTRY CLASS MODEL

        public void GetCustomerCountry()
        {
            string sql = "SELECT Country, COUNT(CustomerId) AS Antall FROM CUSTOMER " +
                "GROUP BY Country ORDER BY Country DESC";

                //"SELECT Country, COUNT(CustomerID), Country FROM CUSTOMER"; // +
                //"GROUP BY Country ORDER BY COUNT(CustomerID) DESC";

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
                                Console.WriteLine(reader.GetString(0) + ": " + reader.GetInt32(1));
                            }
                        };
                    };
                };
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
