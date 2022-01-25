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

            // Reads all the customers in the database
            TestGetAllCustomers(customerRepo);

            // Reads a specific customer from the database by id
            TestGetCustomerById(customerRepo);

            // Reads a specific customer from the database by name using keyword LIKE
            TestGetCustomerByName(customerRepo);

            // Returns a page of customers from the database using keywords LIMIT and OFFSET
            TestLimitCustomersByOffset(customerRepo);


            // Adds a new customer to the database
            //TestCreateCustomer(customerRepo);

            // Updates an existing customer
            //TestUpdateCustomer(customerRepo);



            
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


        private static void TestGetAllCustomers(ICustomerRepo repo)
        {
            var customers = repo.GetAllCustomers();

            Console.WriteLine("\nCustomers: ");
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ToString());
            }
        }

        private static void TestGetCustomerById(ICustomerRepo repo)
        {
            Customer customer = repo.GetCustomer(10);
            Console.WriteLine("\nCustomerId 10: \n" + customer.ToString());
        }

        private static void TestGetCustomerByName(ICustomerRepo repo)
        {
            Customer customer = repo.GetCustomer("Mark");
            Console.WriteLine("\nCustomer(s) by name Mark \n" + customer.ToString());
        }

        private static void TestLimitCustomersByOffset(ICustomerRepo repo) 
        {
            var customers = repo.GetAllCustomers(5, 15);

            Console.WriteLine("\nCustomers (limit 5 | offset 15): ");
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ToString());
            }
        }

        private static void TestCreateCustomer(ICustomerRepo customerRepo)
        {
            string name = "Berit";
            Customer customer = new() 
            {
                FirstName = name,
                LastName = "Pettersen",
                Country = "Norge",
                PostalCode = "3000",
                PhoneNumber = "0309940224",
                Email = "AJdks@djsfp.ado"
            };
            Console.WriteLine("\nCreate Customer: " + customer.ToString());
            bool successful = customerRepo.CreateCustomer(customer);
            if (successful)
                Console.WriteLine("Succesful: " + customerRepo.GetCustomer(name));
            else
                Console.WriteLine("FAILED TO ADD NEW CUSTOMER...");
        }

        private static void TestUpdateCustomer(ICustomerRepo customerRepo)
        {
            // string name = "Arne";
            Customer customer = customerRepo.GetCustomer(60);
            Console.WriteLine("\nUpdate Customer: " + customer.ToString());

            customer.FirstName = "Gunnar";

            bool successful = customerRepo.UpdateCustomer(customer); 
            if (successful)
                Console.WriteLine("Succesful: " + customerRepo.GetCustomer(60));
            else
                Console.WriteLine("FAILED TO AUPDATE CUSTOMER...");
        }
    }
}
