using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_InheritanceAndPolymorphism
{
    public class Circle: Square
    {
//        const double Pi = Math.PI;

        //property
        public double Radius { get {
                return Length / 2;
            } }

        //method:
        public override string Describe()
        {
            return $"Circle with id: {Id}, at ({X}, {Y}) with Radius: {Radius}";
        }


        public override double FindArea()
        {
            //constants - variable with a fixed value which you cannot change

            return Math.PI * Math.Pow(Radius, 2);   
        }
        

    }
}
