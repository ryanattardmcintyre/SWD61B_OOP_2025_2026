using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_Worksheet6.Q2
{
    /*
     * 1.	Create an interface IShape.  Declare the method PrintType() to return a string value and Area() to return the answer as double value.

2.	Create a new class Circle which will inherit from the interface IShape.

3.	The class should have the attribute radius.  Cater for the encapsulation technique by using the get and set methods for radius.

4.	Add a constructor for Circle.

5.	The Circle class should have the following methods (from the interface)
-	PrintType() – return “I’m a Circle”
-	Area() – return Math.PI * Radius * Radius

6.	Create another class Rectangle, inheriting from the interface IShape.

7.	Include the attributes Width and Height for the Rectangle class.

8.	Add a constructor.

9.	The Rectangle class should have the following methods (from the interface)
-	PrintType() – return “I’m a Rectangle”
-	Area() – return Width * Height

10.	In main program, declare an array with 2 elements (Circle and Rectangle)
11.	Use a foreach loop to iterate in the array and for each element, call the PrintType() method and display the area. 

     */
    public interface IShape
    {
        string PrintType();
        double Area();
    }
}
