﻿using System.Collections.Generic;
using SQL_Client.Models;

namespace SQL_Client.Repositories
{
    public interface ICustomerSpenderRepo
    {
        public List<CustomerSpender> GetCustomerSpenders();
    }
}
