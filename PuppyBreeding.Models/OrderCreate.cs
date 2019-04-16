using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBreeding.Models
{
    public class OrderCreate
    {
        [Display(Name = "Puppy's Name")]
        public int PuppyId { get; set; }
        [Display(Name = "Customer's Name")]
        public int CustomerId { get; set; }
        [Display(Name = "Price (USD)")]
        public double Price { get; set; }
        [Display(Name = "Puppy's Name")]
        public string PuppyName { get; set; }
        [Display(Name = "Customer's Name")]
        public string CustomerName { get; set; }
        [Display(Name = "Customer Approved?")]
        public bool CustomerApproved { get; set; }
        [Display(Name = "Deposit Paid?")]
        public bool DepositPaid { get; set; }
        [Display(Name = "Price Paid in Full?")]
        public bool PriceInFullPaid { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
