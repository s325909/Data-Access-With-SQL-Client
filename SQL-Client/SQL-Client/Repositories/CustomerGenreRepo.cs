using SQL_Client.Models;
using SQL_Client.SqlHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Client.Repositories
{
    public class CustomerGenreRepo : ICustomerGenreRepo
    {
        public CustomerGenre GetCustomerGenre(int customerId)
        {
            string sql = "SELECT TOP 1 WITH TIES Genre.Name, Customer.FirstName, Customer.LastName, ";
            sql += "COUNT(Genre.Name) AS COUNT FROM Genre ";
            sql += "INNER JOIN Track ON Genre.GenreId = Track.GenreId ";
            sql += "INNER JOIN InvoiceLine ON InvoiceLine.TrackId = Track.TrackId ";
            sql += "INNER JOIN Invoice ON InvoiceLine.InvoiceLineId = Invoice.InvoiceId ";
            sql += "INNER JOIN Customer ON Invoice.CustomerId = Customer.CustomerId ";
            sql += "WHERE Customer.CustomerId = @CustomerId ";
            sql += "GROUP BY Customer.FirstName, Customer.LastName, Genre.Name ";
            sql += "ORDER BY COUNT DESC;";
            return ConnectExecutionHelper.GetCustomerMostPopularGenre(sql, customerId);
        }
    }
}
