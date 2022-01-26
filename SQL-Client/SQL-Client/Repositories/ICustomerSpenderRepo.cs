using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQL_Client.Models;

namespace SQL_Client.Repositories
{
    public interface ICustomerSpenderRepo
    {
        public List<CustomerSpender> GetCustomerSpenders();
    }
}
