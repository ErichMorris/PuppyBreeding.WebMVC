using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBreeding.Data
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public bool PriceInFullPaid { get; set; }
        //Table References
        [Required]
        public int PuppyId { get; set; }
        [Required]
        public int CustomerId { get; set; }

        public virtual Puppy Puppy { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
