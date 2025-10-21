using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<INotifier> myNotificationsTechniques = new List<INotifier>();
            myNotificationsTechniques.Add(new ConsoleNotifier());
            myNotificationsTechniques.Add(new TextFileNotifier("notifications.txt"));

            Console.WriteLine("Input name");
            string name = Console.ReadLine();


            Console.WriteLine("Write a message to be saved into the database");
            string message = Console.ReadLine();


            Console.WriteLine("Input recipient");
            string recipient = Console.ReadLine();


            //saving the details of the user in the database
            //after the saving is completed SUCCESSFULLY
            //...

            foreach (INotifier notifier in myNotificationsTechniques)
            {
                notifier.Notify(message, recipient, "noreply@ouraddress.com");
            }

            Console.WriteLine("Press a key to terminate...");
            Console.ReadKey();




        }
    }
}
