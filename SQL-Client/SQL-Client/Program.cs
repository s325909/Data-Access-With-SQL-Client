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


            TestGetCustomerById(customerRepo);

            TestGetCustomerByName(customerRepo);

            
            /**
            
            ICustomerRepo customerRepo = new CustomerRepo();

            var customers = customerRepo.GetAllCustomers(2, 5);

            //var customers = customerRepo.GetAllCustomers();



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



            customerRepo.GetCustomerCountry();
           // Console.WriteLine(customerRepo.GetCustomerCountry());

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

        public static void TestGetCustomerById(ICustomerRepo repo)
        {
            Customer customer = repo.GetCustomer(10);
            Console.WriteLine("CustomerId 10: \n" + customer.ToString());
        }

        public static void TestGetCustomerByName(ICustomerRepo repo)
        {
            Customer customer = repo.GetCustomer("Mark");
            Console.WriteLine("Customer(s) by name Mark \n" + customer.ToString());
        }

    }
}
