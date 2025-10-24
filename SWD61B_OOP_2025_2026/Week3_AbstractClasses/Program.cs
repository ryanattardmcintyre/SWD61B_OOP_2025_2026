using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_AbstractClasses
{
    /*
     * Similarities:
     * - Interfaces & Abstract classes are both created to be INHERITED
     * - Both cannot be instantiated NOT ALLOWED: INotifier myInstance = new INotifier();
     *                               NOT ALLOWED: BankAccount myAccount = new BankAccount(); 
     * 
     * Characteristics of an Abstract class
     * - can have implementations inside
     * - can also have non implemented methods inside
     * - it can have a private constructor
     * - non-implemented methods have to be overriden
     * 
     * Differences:
     * - An abstract class can have implemented methods inside 
     *   while an interface allow only just method declrations
     * - Abstract class allows a private constructor; An interface NO
     * - In an ordinary class, you can inherit more than one interface,
     *   but you can only inherit one abstract class
     * - An abstract class can also inherit an interface
     */ 






    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
