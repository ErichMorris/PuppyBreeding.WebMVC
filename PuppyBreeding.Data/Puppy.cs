using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBreeding.Data
{
    class Puppy
    {
        [Key]
        public int PuppyId { get; set; }

        [Required]
        public string PuppyName { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
