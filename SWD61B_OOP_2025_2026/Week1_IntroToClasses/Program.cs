using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1_IntroToClasses
{
    //This particular class since it contains the Main method, its used to boot up the app
    internal class Program
    {
        static void Main(string[] args)
        {
            Library myLibrary = new Library();

            Book b = new Book(); //b is an object usually referred to as a local variable/field/object

            Console.WriteLine("Input book name");
            b.Title =  Console.ReadLine();
            
            Console.WriteLine("Input book isbn");
            b.Isbn = Console.ReadLine();

            Console.WriteLine("Input book stock");
            b.Stock = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Input book price");
            b.WholesalePrice = Convert.ToDouble(Console.ReadLine());

            myLibrary.AddBook(b);

            //myLibrary.Delete("1");

            Console.WriteLine($"Books in Library: {myLibrary.BooksCount}");

            Console.WriteLine($"Total cost: {myLibrary.Buy("1", 5)} ");

            Console.ReadKey();








            //--------------------------------------------------------------------------------------------
            //Class is the template
            //Real "objects" are instances of a class

            Person p; //p is an instance/object of type Person [declaring the object]
            p = new Person(); //instantiating the object p

            //How to assign values in p
            p.Name = "Test";

            //How to read values from p
            //notation for local variables is camel case 
            int computedAge = DateTime.Now.Year - p.Dob.Year;

            //How to read values from the screen and assign them in p
            // string name = Console.ReadLine();
            // p.Name = name;
         //   p.Name = Console.ReadLine();

            //How to read values from p and show them on screen
            Console.WriteLine(p.Name);

            //----------------------------------------------------------------------
           
            p = new Person();

            Console.WriteLine("Input first name");
            p.Name = Console.ReadLine();

            Console.WriteLine("Input date of birth (dd/mm/yyyy)");
            p.Dob = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Press a key to calculate your age.");
            Console.ReadKey(); //temporary suspends the application execution
            //Console.WriteLine("Dear " + p.Name + ", you are " + (DateTime.Now.Year - p.Dob.Year) + " years old");
            Console.WriteLine($"Dear {p.Name}, you are {DateTime.Now.Year - p.Dob.Year} years old");

            Console.WriteLine("Press a key to terminate app");
            Console.ReadKey();

            //--------------------------------------------------------------------------

         


        }
    }
}
