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
        //Constructors are special methods which
        //1) they take the class name
        //2) are used to construct objects in memory e.g. Point when called
        //3) often used to default fields /properties
        //4) code which you want to run FIRST you put it in the constructor
        public Point()
        {
            canvasMode = "2D";
            Color = Color.Black;
        }

        //overloaded constructors
        public Point(int x, int y) : this() //this() is calling first the default constructor
        {
            X = x; //immediately (as soon as the object is constructed) we are assigning
            Y = y; //parameter x and parameter y into the respective properties
        }

        public Point (int x, int y, string id): this(x,y)
        {
            Id = id;
        }

        //properties
        public int X { get; set; }
        public int Y { get; set; }
        public int Zoom { get; set; } 
        public Color Color { get; set; }
        public string Id { get; set; }

        protected string canvasMode; //protected: allows the field accessible ONLY from this class 
                                     //or inherited classes 

        private string privateField;

        //methods
        //virtual: will enable the inherited classes to change ONLY the implementation
        public virtual string Describe()
        { return $"Point with id: {Id}, at ({X}, {Y})"; }


        /// <summary>
        /// Equals method is used when comparing the two objects. e.g.
        /// if(p1.Equals(p2)) will return true if X, Y match
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
          return obj.GetHashCode() == GetHashCode();
        }
        public override int GetHashCode()
        {
            //object => 34567890987654567
            string mustProperties = "" + X + "" + Y;
            return mustProperties.GetHashCode();
        }

        public override string ToString()
        {
            return Describe();
        }

        //This is static polymorphism
        public void Scale(int scale)
        {
            Zoom += scale;
        }

        public void Scale(double percentage)
        {
            Zoom *= Convert.ToInt32((percentage / 100));
        }

        public void Scale(int scale,  int min, int max)
        {
            Zoom += scale;
            if(Zoom > max)
                Zoom = max;
            if (Zoom < min)
                Zoom = min;
        }
    }
}
