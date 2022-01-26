using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Client.Models
{
    public class CustomerGenre
    {
        public int MyProperty { get; set; }

        public override string ToString()
        {
            return $"{MyProperty} ";
        }
    }
}
