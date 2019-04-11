using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBreeding.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int PuppyId { get; set; }
        public int CustomerId { get; set; }
        public string PuppyName { get; set; }
        public string CustomerName { get; set; }
        public double Price { get; set; }
        public bool CustomerApproved { get; set; }
        public bool DepositPaid { get; set; }
        public bool PriceInFullPaid { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
