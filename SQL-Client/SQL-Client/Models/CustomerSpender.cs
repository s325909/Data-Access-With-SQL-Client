using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Client.Models
{
    public class CustomerSpender
    {
        public string SpenderFirstName { get; set; }
        public string SpenderLastName { get; set; }
        public decimal SpenderTotalAmount { get; set; } 

        public override string ToString()
        {
            return $"{SpenderFirstName} {SpenderLastName}: {SpenderTotalAmount}";
        }
    }
}
