﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBreeding.Models
{
    public class FatherListItem
    {
        public int FatherId { get; set; }
        public string FatherName { get; set; }
        public double FatherWeight { get; set; }
        public int FatherAge { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
