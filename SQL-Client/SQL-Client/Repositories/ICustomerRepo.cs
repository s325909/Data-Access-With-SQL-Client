﻿using System;
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

        public List<Customer> GetAllCustomers();

        public bool AddNewCustomer(Customer customer);

        public bool UpdateCustomer(Customer customer);

        public bool DeleteCustomer(Customer customer);
    }
}
