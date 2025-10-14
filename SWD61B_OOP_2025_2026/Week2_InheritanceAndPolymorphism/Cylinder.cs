using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_InheritanceAndPolymorphism
{
    public class Cylinder: Sphere
    {
        public double Height { get; set; }
        public override string Describe()
        {
            return $"Cylinder with id: {Id}, at ({X}, {Y}) with Radius: {Radius} and Height: {Height}";
        }

        public override double FindArea()
        {
            return (Math.PI * Radius * Radius * 2) + (2 * Math.PI * Radius * Height);
        }

        public override double FindVolume()
        {
            return (Math.PI * Radius * Radius) * Height;
        }
    }
}
