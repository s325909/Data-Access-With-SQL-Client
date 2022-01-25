using System;
using SQL_Client.Models;
using SQL_Client.Repositories;

namespace SQL_Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ICustomerRepo customerRepo = new CustomerRepo();

            var customers = customerRepo.GetAllCustomers(5, 2);

            // var customers = customerRepo.GetAllCustomers();



            foreach (var customer1 in customers)
            {
                Console.WriteLine(customer1.ToString()); 
            }

            var customer = customerRepo.GetCustomer(2);

            // var customer = customerRepo.GetCustomer("Hansen");
            Console.WriteLine("\n" + customer.ToString());


            // var newCustomer =
            //

            Customer newCustomer = new()
            {
                FirstName = "Bob",
                LastName = "Pettersen",
                Country = "Norge",
                PostalCode = "3000",
                PhoneNumber = "0309940224",
                Email = "AJdks@djsfp.ado"
            };


            // customerRepo.AddNewCustomer(newCustomer);

            
        }
    }
}
