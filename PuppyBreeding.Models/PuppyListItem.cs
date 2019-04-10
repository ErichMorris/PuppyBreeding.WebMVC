using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBreeding.Models
{
    public class PuppyListItem
    {
        public int PuppyId { get; set; }
        public string PuppyName { get; set; }
        public int FatherId { get; set; }
        public string FatherName { get; set; }
        public int MotherId { get; set; }
        public string MotherName { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public double Price { get; set; }

    }
}
