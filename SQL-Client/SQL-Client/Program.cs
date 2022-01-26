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

            ICustomerCountryRepo customerCountryRepo = new CustomerCountryRepo();

            ICustomerSpenderRepo customerSpenderRepo = new CustomerSpenderRepo();

            ICustomerGenreRepo customerGenreRepo = new CustomerGenreRepo();


            // Reads all the customers in the database
            TestGetAllCustomers(customerRepo);

            // Reads a specific customer from the database by id
            TestGetCustomerById(customerRepo);

            // Reads a specific customer from the database by name using keyword LIKE
            TestGetCustomerByName(customerRepo);

            // Returns a page of customers from the database using keywords LIMIT and OFFSET
            TestLimitCustomersByOffset(customerRepo);

            // Adds a new customer to the database
            TestCreateCustomer(customerRepo);

            // Updates an existing customer
            TestUpdateCustomer(customerRepo);

            // get the number of customers in each country
            TestGetCustomersPerCountry(customerCountryRepo);

            // get the highest spenders
            TestGetCustomerSpenders(customerSpenderRepo);

            Console.WriteLine("\n\nGet most popular genre(s) from customers");

            // get most popular genres from customers
            TestGetCustomerGenres(customerGenreRepo, 29);
            TestGetCustomerGenres(customerGenreRepo, 39);

            for (int i = 1; i < 60; i++)
            {
                // TestGetCustomerGenres(customerGenreRepo, i);
            }
        }

        private static void TestGetAllCustomers(ICustomerRepo repo)
        {
            var customers = repo.GetAllCustomers();

            Console.WriteLine("\nAll Customers: ");
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
            Console.WriteLine("\nCustomer by name Mark \n" + customer.ToString());
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
            string name = "Chad";
            Customer customer = new() 
            {
                FirstName = name,
                LastName = "Nielsen",
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

            customer.FirstName = "Ultra Chad";

            bool successful = customerRepo.UpdateCustomer(customer); 
            if (successful)
                Console.WriteLine("Succesful: " + customerRepo.GetCustomer(60));
            else
                Console.WriteLine("FAILED TO AUPDATE CUSTOMER...");
        }

        private static void TestGetCustomersPerCountry(ICustomerCountryRepo customerCountryRepo)
        {
            Console.WriteLine("\nGet number of customers in each country");

            var customerCountries = customerCountryRepo.GetCustomerCountries();

            foreach (var customerCountry in customerCountries)
            {
                Console.WriteLine(customerCountry.ToString());
            }
        }

        private static void TestGetCustomerSpenders(ICustomerSpenderRepo customerSpenderRepo)
        {
            Console.WriteLine("\nGet top 10 highest spending customers");

            var spenders = customerSpenderRepo.GetCustomerSpenders();

            foreach (var spender in spenders)
            {
                Console.WriteLine(spender.ToString());
            }
        }

        private static void TestGetCustomerGenres(ICustomerGenreRepo customerGenreRepo, int customerId)
        {
            Console.WriteLine($"\nGet customer [{customerId}] most popular genre(s)");

            var customerGenres = customerGenreRepo.GetCustomerGenre(customerId); 

            foreach (var customerGenre in customerGenres)
            {
                Console.WriteLine(customerGenre.ToString());
            }
        }
    }
}
