using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Week2_InheritanceAndPolymorphism
{
    public class Point
    {
        //properties
        public int X { get; set; }
        public int Y { get; set; }
        public int Zoom { get; set; } 
        public Color Color { get; set; }
        public string Id { get; set; }

        //methods
        //virtual: will enable the inherited classes to change ONLY the implementation
        public virtual string Describe()
        { return $"Point with id: {Id}, at ({X}, {Y})"; }

    }
}
