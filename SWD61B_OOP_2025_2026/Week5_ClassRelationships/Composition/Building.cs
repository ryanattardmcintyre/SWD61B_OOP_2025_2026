using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Composition
{
    public class Building
    {
        public int Floors { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        private List<Room> rooms { get; set; }
        public string Country { get; set; }
        public double PlotArea { get; set; }
        public double CalculateTotalArea()
        {
            return PlotArea * Floors;
        }

        public Building()
        {
            rooms = new List<Room>();
        }
    }


    public class School: Building { }

    public class Home : Building { }
}
