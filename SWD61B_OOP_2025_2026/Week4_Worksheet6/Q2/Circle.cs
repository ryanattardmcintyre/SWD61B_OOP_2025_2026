using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_Worksheet6.Q2
{
    public class Circle: IShape
    {
        public Circle() { }
        public double Radius { get; set; }

        public double Area()
        {
            return Math.PI * Radius * Radius;
        }

        public string PrintType()
        {
            return "I’m a Circle";
        }
    }
}
