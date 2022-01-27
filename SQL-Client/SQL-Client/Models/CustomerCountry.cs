﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Client.Models
{
    public class CustomerCountry
    {
        public string CountryName { get; set; } 
        public int CustomerCount { get; set; }

        public override string ToString()
        {
            return $"{CountryName}: {CustomerCount}";
        }
    }
}
