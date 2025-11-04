using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Aggregation
{
    public class Group
    {
        public string Id { get; set; } //e.g. SWD6.1B
        public Programme Programme { get; set; }
        public string Year { get; set; } //2025-2026
        
    }
}
