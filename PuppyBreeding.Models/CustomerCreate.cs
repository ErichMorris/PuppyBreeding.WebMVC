using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBreeding.Models
{
    public class CustomerCreate
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool CustomerApproved { get; set; }
        public bool DepositPaid { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
