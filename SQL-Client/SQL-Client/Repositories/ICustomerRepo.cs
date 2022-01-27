using System.Collections.Generic;
using SQL_Client.Models;

namespace SQL_Client.Repositories
{
    public interface ICustomerRepo
    {
        public List<Customer> GetAllCustomers();

        public List<Customer> GetAllCustomers(int limit, int offset);

        public Customer GetCustomer(int id);

        public Customer GetCustomer(string name);

        public bool CreateCustomer(Customer customer);

        public bool UpdateCustomer(Customer customer);

        public bool DeleteCustomer(Customer customer);
    }
}
