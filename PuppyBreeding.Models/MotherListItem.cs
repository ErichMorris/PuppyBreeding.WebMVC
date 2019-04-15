using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBreeding.Models
{
    public class MotherListItem
    {
        public int MotherId { get; set; }
        [Display(Name = "Name")]
        public string MotherName { get; set; }
        [Display(Name = "Weight (pounds)")]
        public double MotherWeight { get; set; }
        [Display(Name = "Age (years)")]
        public int MotherAge { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
