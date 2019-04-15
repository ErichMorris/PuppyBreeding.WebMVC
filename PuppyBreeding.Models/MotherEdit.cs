using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBreeding.Models
{
    public class MotherEdit
    {
        public int MotherId { get; set; }
        [Display(Name = "Mother's Name")]
        public string MotherName { get; set; }
        [Display(Name = "Mother's Weight (pounds)")]
        public double MotherWeight { get; set; }
        [Display(Name = "Mother's Age (years)")]
        public int MotherAge { get; set; }
    }
}
