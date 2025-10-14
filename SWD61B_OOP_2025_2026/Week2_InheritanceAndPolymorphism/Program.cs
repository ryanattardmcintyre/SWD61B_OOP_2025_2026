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
            Point p = new Point();
            p.Id = "P1";
            p.X = 10; p.Y=20;
            p.Color = Color.Red;
            

            Square s = new Square();
            s.Id = "S1";
            s.X = 20; s.Y = 30;
            s.Color = Color.Green;
            s.Length= 30;

            List<Point> shapes =new List<Point>();
            shapes.Add(p);
            shapes.Add(s);

            foreach (Point pt in shapes)
            {
                Console.ForegroundColor = FastQuantized(pt.Color);
                Console.WriteLine(pt.Describe());
            }
            Console.ReadKey();
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
