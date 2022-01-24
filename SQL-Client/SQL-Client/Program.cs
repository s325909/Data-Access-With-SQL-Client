using System;
using SQL_Client.Repositories;

namespace SQL_Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ICustomerRepo customerRepo = new CustomerRepo();

            //var customers = customerRepo.GetAllCustomers();


            //foreach (var customer in customers)
            //{
            //    Console.WriteLine($"{customer.FirstName} {customer.LastName} " +
            //        $"| {customer.Country} | {customer.PostalCode} | {customer.PhoneNumber} | {customer.Email}" );
            //}

            var customer = customerRepo.GetCustomer(2);
            Console.WriteLine(customer.ToString());
        }
    }
}
