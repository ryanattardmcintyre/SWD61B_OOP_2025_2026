using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4_Worksheet6.Q2;

namespace Week4_Worksheet6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IShape[] shapes = {
             new Circle(){ Radius=5 },
             new Rectangle(){ Width=10, Height=20 }
            };

            shapes[0] = new Circle() { Radius = 100 };

            foreach (IShape item in shapes)
            {
                Console.WriteLine($"{item.PrintType()}, Area: {item.Area()}");
            }
            Console.ReadKey();

            //List<IShape> shapesList = new List<IShape>();
           


        }
    }
}
