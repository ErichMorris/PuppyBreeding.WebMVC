using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBreeding.Models
{
    public class FatherListItem
    {
        public int FatherId { get; set; }
        [Display(Name = "Name")]
        public string FatherName { get; set; }
        [Display(Name = "Weight (pounds)")]
        public double FatherWeight { get; set; }
        [Display(Name = "Age (years)")]
        public int FatherAge { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
