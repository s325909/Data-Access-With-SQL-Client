using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQL_Client.Models;

namespace SQL_Client.Repositories
{
    public interface ICustomerRepo
    {
        public Customer GetCustomer(int id);

        public Customer GetCustomer(string name);

        public string GetCustomerCountry();

        public List<Customer> GetAllCustomers();

        public List<Customer> GetAllCustomers(int limit, int offset);

        public bool AddNewCustomer(Customer customer);

        public bool UpdateCustomer(Customer customer);

        public bool DeleteCustomer(Customer customer);
    }
}
