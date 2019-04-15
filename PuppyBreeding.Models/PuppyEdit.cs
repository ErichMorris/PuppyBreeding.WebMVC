﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBreeding.Models
{
    public class PuppyEdit
    {
        public int PuppyId { get; set; }
        public int MotherId { get; set; }
        public int FatherId { get; set; }
        [Display(Name = "Puppy's Name")]
        public string PuppyName { get; set; }
        [Display(Name = "Mother's Name")]
        public string MotherName { get; set; }
        [Display(Name = "Father's Name")]
        public string FatherName { get; set; }
        [Display(Name = "Weight (in pounds)")]
        public double Weight { get; set; }
        [Display(Name = "Age(months)")]
        public int Age { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Price (USD)")]
        public double Price { get; set; }
    }
}
