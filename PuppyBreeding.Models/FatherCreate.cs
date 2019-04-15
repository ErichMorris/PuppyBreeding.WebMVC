using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBreeding.Models
{
    public class FatherCreate
    {
        [Display(Name = "Father's Name")]
        public string FatherName { get; set; }
        [Display(Name = "Father's Weight (pounds)")]
        public double FatherWeight { get; set; }
        [Display(Name = "Father's Age (years)")]
        public int FatherAge { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
