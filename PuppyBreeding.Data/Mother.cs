﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBreeding.Data
{
    public class Mother
    {
        [Key]
        public int MotherId { get; set; }
        [Required]
        public string MotherName { get; set; }
        [Required]
        public double MotherWeight { get; set; }
        [Required]
        public int MotherAge { get; set; }
    }
}
