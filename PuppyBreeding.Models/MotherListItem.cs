﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBreeding.Models
{
    public class MotherListItem
    {
        public int MotherId { get; set; }
        public string MotherName { get; set; }
        public double MotherWeight { get; set; }
        public int MotherAge { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
