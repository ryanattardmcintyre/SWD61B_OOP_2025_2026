using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_InheritanceAndPolymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {


            int choice = 0;
            List<Circle> myShapes = new List<Circle>();
            do
            {
                Console.Clear();
                Console.WriteLine("Menu");
                Console.WriteLine("1. Add a Circle");
                Console.WriteLine("2. Add a Sphere");
                Console.WriteLine("3. Find Area");
                Console.WriteLine("4. Find Volume");
                Console.WriteLine("5. Quit");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Circle myCircle = new Circle();
                        Console.WriteLine("input x");
                        myCircle.X = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("input y");
                        myCircle.Y = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("input diameter");
                        myCircle.Length = Convert.ToInt32(Console.ReadLine());

                        myShapes.Add(myCircle);
                        Console.WriteLine("Circle added. Press a key to go back to main menu...");
                        break;
                    case 2:

                        Sphere mySphere = new Sphere();
                        Console.WriteLine("input x");
                        mySphere.X = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("input y");
                        mySphere.Y = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("input diameter");
                        mySphere.Length = Convert.ToInt32(Console.ReadLine());

                        myShapes.Add(mySphere);
                        Console.WriteLine("Sphere added. Press a key to go back to main menu...");

                        break;
                    case 3:
                        //var is a generic variable which can be used to represent all objects
                        foreach (var shape in myShapes)
                        {  //Circle vs Sphere
                            Console.WriteLine($"Area of {shape.GetType().Name} is {shape.FindArea()}");
                        }
                        Console.WriteLine("Areas calulated. Press a key to go back to main menu...");
                        break;
                    case 4:
                        foreach (var shape in myShapes)
                        {  //Circle vs Sphere
                            if (shape.GetType() == typeof(Sphere) || shape.GetType() == typeof(Cylinder))
                            {   
                                //shape is of type Circle because List<Circle>
                                Sphere shapeForVolume = (Sphere) shape; //Typecasting shape => Sphere
                                Console.WriteLine($"Volume of {shape.GetType().Name} is {shapeForVolume.FindVolume()}");
                            }
                        }
                        Console.WriteLine("Volumes calulated. Press a key to go back to main menu...");

                        break;
                }

                Console.ReadKey();
            } while (choice != 5);
        }


        public static ConsoleColor FastQuantized(Color c)
        {
            // Map RGB ≥ 128 to bright bits
            int r = c.R >= 128 ? 1 : 0;
            int g = c.G >= 128 ? 1 : 0;
            int b = c.B >= 128 ? 1 : 0;

            // Base index from RGB bits (0..7)
            int idx = (r << 2) | (g << 1) | b;

            // Brightness: use "dark" (0..7) vs "bright" (8..15) by overall intensity
            bool bright = (c.R + c.G + c.B) >= (128 * 3);
            if (bright) idx |= 8;

            return (ConsoleColor)idx; // enum values align with this bit layout
        }

    }
}

