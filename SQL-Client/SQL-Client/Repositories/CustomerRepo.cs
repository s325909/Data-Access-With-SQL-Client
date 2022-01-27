using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using SQL_Client.Models;
using SQL_Client.SqlHelpers; 

namespace SQL_Client.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        /// <summary>
        /// this function connects to the database and executes a SQL query and returns all customers from customer table
        /// </summary>
        /// <returns>list of all customers</returns>
        public List<Customer> GetAllCustomers()
        {
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            return ConnectExecutionHelper.GetAllCustomers(sql);
        }

        /// <summary>
        /// this function connects to the database and executes a SQL query and returns a page of customers from customer table
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns>returns a list of selected customers based on the provided limit and offset</returns>
        public List<Customer> GetAllCustomers(int limit, int offset)
        {
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                "FROM Customer ORDER BY CustomerId OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY";
            return ConnectExecutionHelper.GetSelectedCustomers(sql, limit, offset);
        }

        /// <summary>
        /// this function connects to the database and executes a SQL query and returns a customer from id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns a customer by id</returns>
        public Customer GetCustomer(int id)
        {
            string sql = $"SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                "FROM Customer WHERE CustomerId = @CustomerId";
            return ConnectExecutionHelper.GetCustomerById(sql, id);
        }

        /// <summary>
        /// this function connects to the database and executes a SQL query and returns a customer from name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>returns a customer by name (firstname or lastname)</returns>
        public Customer GetCustomer(string name)
        {
            string sql = $"SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                "FROM Customer WHERE FirstName LIKE @FirstName OR LastName LIKE @LastName";
            return ConnectExecutionHelper.GetCustomerByName(sql, name);
        }

        /// <summary>
        /// this function connects to the database and executes a SQL query to add a new customer to customer table
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>true or false if the customer has been added to the database</returns>
        public bool CreateCustomer(Customer customer)
        {
            string sql = "INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email)";
            sql += " Values (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";
            return ConnectExecutionHelper.CRUDCustomer(customer, sql);
        }

        /// <summary>
        /// this function connects to the database and executes a SQL query to update an existing customer from customer table
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>returns true or false if customer updated in the database </returns>
        public bool UpdateCustomer(Customer customer)
        {
            string sql = "Update Customer ";
            sql += "SET FirstName = @FirstName, LastName = @LastName, Country = @Country, PostalCode = @PostalCode, Phone = @Phone, Email = @Email ";
            sql += "WHERE CustomerId = @CustomerId";
            return ConnectExecutionHelper.CRUDCustomer(customer, sql);
        }

        /// <summary>
        /// this function connects to the database and executes a SQL query to delete a customer from customer table
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>true or false if customer deleted from the database</returns>
        public bool DeleteCustomer(Customer customer)
        {
            string sql = "DELETE FROM Customer WHERE CustomerId = @CustomerId";
            return ConnectExecutionHelper.CRUDCustomer(customer, sql);
        }
    }
}
