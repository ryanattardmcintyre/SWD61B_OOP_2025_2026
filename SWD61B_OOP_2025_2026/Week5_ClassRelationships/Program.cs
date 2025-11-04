using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5_ClassRelationships.Composition;

namespace Week5_ClassRelationships
{

    /*
     * Composition
     * - is the stongest form of relationship between two classes
     * - Class A has a composite type of relationship with Class B meaning
     *   that Class A cannot be instantiated unless Class B object exists already
     * - e.g. Building & Room  
     * - e.g. Engine & Car
     * - e.g. Owner & BankAccount
     * 
     * Aggregation
     * Association
     * 
     * Inheritance
     */ 


    internal class Program
    {
        static void Main(string[] args)
        {
            //if i can code the following line without any errors
            //then IT IS NOT A COMPOSITE TYPE OF RELATIONSHIP
            //between Room and Building
            
            Building myHouse = new Building();

            Room myRoom = new Room(myHouse);
        }
    }
}
