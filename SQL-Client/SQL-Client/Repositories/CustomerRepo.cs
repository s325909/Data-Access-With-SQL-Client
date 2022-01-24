using Microsoft.Data.SqlClient;
using SQL_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQL_Client.SqlHelpers;

namespace SQL_Client.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {


        public bool AddNewCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
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
                                Customer tmpCustomer = new();
                                tmpCustomer.CustomerID = reader.GetInt32(0);

                                if (!reader.IsDBNull(1))
                                    tmpCustomer.FirstName = reader.GetString(1);

                                if (!reader.IsDBNull(2))
                                    tmpCustomer.LastName = reader.GetString(2);

                                if (!reader.IsDBNull(3))
                                    tmpCustomer.Country = reader.GetString(3);

                                if (!reader.IsDBNull(4))
                                    tmpCustomer.PostalCode = reader.GetString(4);

                                if (!reader.IsDBNull(5))
                                    tmpCustomer.PhoneNumber = reader.GetString(5);

                                if (!reader.IsDBNull(6))
                                    tmpCustomer.Email = reader.GetString(6);

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

        public Customer GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
