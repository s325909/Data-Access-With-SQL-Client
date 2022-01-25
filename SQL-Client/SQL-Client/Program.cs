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

           // Customer customer = customerRepo.GetCustomer(2);

          
            Console.WriteLine("\n" + customerRepo.GetCustomer("Mark"));

            Customer customer = customerRepo.GetCustomer(60);

            customer.FirstName = "Steinar";

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
