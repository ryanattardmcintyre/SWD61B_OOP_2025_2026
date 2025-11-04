using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Aggregation
{
    public class Unit
    {
        public string Code { get; set; }
        public string Name { get; set; } //Object Oriented Programming
        public int Year { get; set; }
        public List<Programme> Programme { get; set; }

        public int Hours { get; set; }
    }
}
