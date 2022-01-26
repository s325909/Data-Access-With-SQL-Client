using System.Collections.Generic;
using SQL_Client.Models;

namespace SQL_Client.Repositories
{
    public interface ICustomerGenreRepo
    {
        public List<CustomerGenre> GetCustomerGenres();
    } 
}