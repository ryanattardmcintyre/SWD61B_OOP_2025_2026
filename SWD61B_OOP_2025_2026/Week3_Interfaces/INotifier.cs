using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_Interfaces
{

    /*
     * 1) Interfaces are like contracts where you declare the rules and then this contract
     *    has to be implemented by a number of "parties" -> classes
     * 2) Therefore, an interface should contain only method signatures to be respected by classes!
     * 3) An interface won't go into the details of implementations, just laying out the rules
     * 4) An interface can be inherted by an unlimited amount of classes
     * 5) IMP: A Class can inherit more than ONE interface
     * 6) An interface can also be used like a base class e.g. List<INotifier> myList;
     * 7) Interfaces are normally named starting with an "I" e.g. INotifier, IList, IQueryable,
     * 8) Methods or properties can be added to the interface WITHOUT implmentation
     * 9) An interface cannot be instantiated but can be used like a base type
     */ 


    //the method(s) inside the "contract" will facilitate notification
    public interface INotifier
    {
        List<string> Notifications { get;  }

        void Notify(string message);
        void Notify(string message, string recipient);
        void Notify(string message, string recipient, string from);
    }
}
