using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_InheritanceAndPolymorphism
{
    //Inheritance: Square is inheriting from Point/ Square derives from Point
                //: Point is the base class

    //1) saves you the time of having to repeat coding the same properties/methods/etc
    //2) Square (or inherited classes) they inherit the protected & public properties/methods/etc
    //3) Square therefore is a Point
    //4) object <- Point <- Square <- Circle 


    //Polymorphism: is the ability of the CLR (Common Language Runtime) of recognizing to which
    //              class/type the method that's being called and executed belongs to


    //Task:
    //1) Create a class called Circle which inherits from Square. Create a property with just the get() to find out the radius
    //   Override the Describe() method accordingly
    //2) Create a class called Rectange which inherits from Square. Override the Describe() method accordingly
    //3) Add a new method called FindArea() in Square. Override this in all classes created so far accordingly
    //4) Create a class called Sphere which inherits from Circle. Override Describe() & FindArea()
    //5) Add a new method called FindVolume() in Sphere.
    //6) Create a new class called Cylinder() which inherits from Sphere. Override Describe() & FindArea() & FindVolume()

    public class Square: Point
    {
        //when you create more than 1 constructor you are basically adopting
        //STATIC POLYMORPHISM
        public Square(): base()
        {
            
        }

        //base refers to the constructor of the Base class i.e Point
        public Square(int x , int y): base(x, y)  
        { }


        //properties
        public double Length { get; set; }

        //methods
        //when you are overriding a method that is
        //DYNAMIC POLYMORPHISM
        public override string Describe()
        {
            //return base.Describe(); //it will by default call the Point -> Describe()

            return $"Square with id: {Id}, at ({X}, {Y}) with Length: {Length}";
        }

       


        public virtual double FindArea() {
            return Length * Length;
        
        }

    }
}
