using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBreeding.Models
{
    public class CustomerEdit
    {
        public int CustomerId { get; set; }
        [Display(Name = "Customer's Name")]
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Display(Name = "Customer Approved?")]
        public bool CustomerApproved { get; set; }
        [Display(Name = "Deposit Paid?")]
        public bool DepositPaid { get; set; }
    }
}
