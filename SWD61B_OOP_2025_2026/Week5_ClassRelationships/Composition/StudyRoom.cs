using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Composition
{
    public class StudyRoom: Room
    {
        public StudyRoom(Building b):base(b)
        { }

        public int Seats { get; set; }
        public string Facilities { get; set; }

    }
}
