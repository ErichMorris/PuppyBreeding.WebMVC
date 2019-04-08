using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBreeding.Data
{
    public class Father
    {
        [Key]
        public int FatherId { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public double FatherWeight { get; set; }
        [Required]
        public int FatherAge { get; set; }
    }
}
