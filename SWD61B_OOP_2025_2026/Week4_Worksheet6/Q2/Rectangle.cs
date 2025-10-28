using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_Worksheet6.Q2
{
     
    public class Rectangle : IShape
    {
        public Rectangle() 
        { }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Area()
        {
            return Width * Height;
        }

        public string PrintType()
        {
            return "I'm a rectangle";
        }
    }
}
