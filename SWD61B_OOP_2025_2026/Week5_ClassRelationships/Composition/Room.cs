using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Composition
{
    public class Room
    {
        protected Building building;

        //that makes the relationship between Buiding and Room: composition!!
        public Room(Building b)
        {
            building = b;
        }

        public double Area { get; set; }
        public string Label { get; set; }

        public double GetFractionFromPlotSize()
        {
            return 100*(Area / building.CalculateTotalArea());
        }

        public bool SeaView { get; set; }
        public bool Furnished { get; set; }
        public bool Airconditioned { get; set; }




    }
}
