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

            // var customers = customerRepo.GetAllCustomers(5, 2);

            var customers = customerRepo.GetAllCustomers();



            foreach (var customer1 in customers)
            {
                Console.WriteLine(customer1.ToString()); 
            }

            var customer = customerRepo.GetCustomer(60);

            // var customer = customerRepo.GetCustomer("Hansen");
            Console.WriteLine("\n" + customer.ToString());


            customer.FirstName = "Ole Dole";

            customerRepo.UpdateCustomer(customer);

            Console.WriteLine("\n" + customerRepo.GetCustomer(60).ToString());


            // var newCustomer =
            //

            /**
            Customer newCustomer = new()
            {
                FirstName = "Svein",
                LastName = "Pettersen",
                Country = "Norge",
                PostalCode = "3000",
                PhoneNumber = "0309940224",
                Email = "AJdks@djsfp.ado"
            };
            **/


            // customerRepo.AddNewCustomer(newCustomer);

            // newCustomer.FirstName = "Svein";

            // customerRepo.UpdateCustomer(newCustomer);
        }
    }
}
