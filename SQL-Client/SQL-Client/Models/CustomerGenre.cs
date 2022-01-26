using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Client.Models
{
    public class CustomerGenre
    {
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string GenreName { get; set; }
        public int GenreCount { get; set; } 

        public override string ToString()
        {
            return $"{CustomerFirstName} {CustomerLastName} | {GenreName}: {GenreCount}";
        }
    }
}
