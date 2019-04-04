using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBreeding.Models
{
    public class CustomerEdit
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool CustomerApproved { get; set; }
        public bool DepositPaid { get; set; }
    }
}
