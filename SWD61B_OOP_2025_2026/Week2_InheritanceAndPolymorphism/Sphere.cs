using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_InheritanceAndPolymorphism
{
    public class Sphere: Circle
    {  
        public int Z { get; set; }


        public override string Describe()
        {
            return $"Sphere with id: {Id}, at ({X}, {Y}) with Radius: {Radius}";
        }

        public override double FindArea() //surface area
        {
            return 4 * Math.PI * Radius * Radius;
        }
        public virtual double FindVolume()
        {
            return ((4 / 3) * Math.PI * Math.Pow(Radius, 3));
        }
    }
}
