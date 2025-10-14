using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_InheritanceAndPolymorphism
{
    public class Rectangle:Square
    {
        public double Width { get; set; }
        public override string Describe()
        {
            return $"Rectangle with id: {Id}, at ({X}, {Y}) with Length: {Length} and Width: {Width}";
        }

        public override double FindArea()
        {
            return Length * Width;
        }
    }
}
