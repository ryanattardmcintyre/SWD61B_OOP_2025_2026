using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_Common;
using Week6_DataAccess;

namespace Week6_PresentationConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ---------- Instantiations --------------
            AttendanceDbContext db = new AttendanceDbContext(); //db represents the database
            StudentsRepository studentsRepository = new StudentsRepository(db);

            int choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("----- Menu -----");
                Console.WriteLine("1. Students");
                Console.WriteLine("2. Groups");
                Console.WriteLine("3. Units");
                Console.WriteLine("4. Attendances");
                Console.WriteLine("5. Quit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        StudentsMenu(studentsRepository);
                        break;

                    case 2:
                        break;

                        case 3:
                        break;

                    case 4:
                        break;

                    case 5:
                        Console.WriteLine("Application is terminating. Click a key to continue...");
                        break;

                    default:
                        Console.WriteLine("The keyed input is not valid. Input choices from 1 to 5.  Click a key to continue...");
                        break;
                }

                Console.ReadKey();

            } while (choice != 5);



        }

        static void StudentsMenu(StudentsRepository studentsRepository)
        {
            int studentChoice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("-------- Students menu ----------");
                Console.WriteLine("1.   List All Students");
                Console.WriteLine("2.   Search for a student");
                Console.WriteLine("3.   List by Group");
                Console.WriteLine("4.   See Details of a student");
                Console.WriteLine("999. Go Back To Main menu");

                studentChoice = Convert.ToInt32(Console.ReadLine());

                switch (studentChoice)
                {
                    case 1:
                        var list = studentsRepository.Get();

                        foreach(var student in list)
                        {
                            Console.WriteLine($"{student.Id}\t{student.Name}\t{student.Surname}");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Press a key to go back to Students menu...");

                        break;

                    case 2:
                        Console.WriteLine("Input student name: ");
                        string keyword = Console.ReadLine();

                        var filteredList = studentsRepository.Get(keyword);

                        foreach (var student in filteredList)
                        {
                            Console.WriteLine($"{student.Id}\t{student.Name}\t{student.Surname}");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Press a key to go back to Students menu...");


                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    case 999:
                        Console.WriteLine("Going back to main menu. Click a key to continue...");
                        break;

                    default:
                        Console.WriteLine("The keyed input is not valid. Input choices from 1 to 4 or 999.  Click a key to continue...");
                        break;
                }

                Console.ReadKey();

            } while(studentChoice != 999);



        }
    }
}
