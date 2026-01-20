using System;
using System.Collections.Generic;
using System.Globalization;
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


            GroupsRepository groupsRepository = new GroupsRepository(db);
            AttendanceRepository attendanceRepository = new AttendanceRepository(db);
            UnitsRepository unitsRepository = new UnitsRepository(db);

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
                        StudentsMenu(studentsRepository, groupsRepository);
                        break;

                    case 2:
                        break;

                    case 3:
                        break;

                    case 4:
                        AttendancesMenu(studentsRepository, groupsRepository, attendanceRepository, unitsRepository);
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


        static void AttendancesMenu(StudentsRepository studentsRepository, GroupsRepository groupsRepository,
            AttendanceRepository attendancesRepository, UnitsRepository unitsRepository)
        {
            int choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("-------- Attendances menu ----------");
                Console.WriteLine("1. Take Attendance");
                Console.WriteLine("2. Search for an attendance");

                Console.WriteLine("3. Display Absenteesim Percentage for a student");
                Console.WriteLine("4. Display the surname and how many students have got that surname");
                Console.WriteLine("5. Display how many students there are per group");
                Console.WriteLine("6. Display monthly absenteeism and sort by the most missed month"); //Jan - 50%, Feb - 70%, Mar - 30%
                Console.WriteLine("7. Display monthly absenteeism for a specific student");
                Console.WriteLine("8. Find the avg absenteesim for a student across different units");

                Console.WriteLine("9. Top 5 present students");
                Console.WriteLine("10. Top 5 present students for group");
                Console.WriteLine("11. Top 5 present students for group within a date range");

                Console.WriteLine("12. List attendance for student");
                Console.WriteLine("999. Go Back To Main menu");
                choice  = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        //1 ask for which unit
                        foreach (var u in unitsRepository.Get())
                        {
                            Console.WriteLine($"{u.Code} - {u.Name}");
                        }

                        Console.WriteLine("Type the unit code which you would like to take attendance of: ");
                        var selectedUnitCode = Console.ReadLine();


                        //2 ask for which group
                        foreach (var g in groupsRepository.Get())
                        {
                            Console.WriteLine($"{g.Id} - {g.Name}");
                        }

                        Console.WriteLine("Type the group Ide which you would like to take attendance of: ");
                        var selectedGroupId = Console.ReadLine();

                        //3 get students according to group
                        var listOfStudents = studentsRepository.GetByGroup(Convert.ToInt32(selectedGroupId));

                        List<Attendance> attendances = new List<Attendance>();
                        DateTime attendanceTakenOn = DateTime.Now;
                        //4 start looping within that list of students
                        foreach(var student in listOfStudents)
                        {
                            Console.WriteLine($"Student {student.Name} {student.Surname}. Present / Absent ?");
                            Console.WriteLine("Type 1. Present / 2. Absent");
                            //5 ask the user to mark present or absent
                            var status = Convert.ToInt16(Console.ReadLine());

                            Attendance attendance = new Attendance();
                            attendance.Author = "";
                            attendance.StudentFK = student.Id;
                            attendance.StatusFK = status;
                            attendance.UnitFK = selectedUnitCode;
                            attendance.Timeslot = attendanceTakenOn;

                            attendances.Add(attendance);
                        }

                        attendancesRepository.TakeAttendances(attendances);

                        Console.WriteLine("Saved! Press any key to back to previous menu");
                        Console.ReadKey();

                        break;

                    case 3:
                        Console.WriteLine("Student Id please?");
                        int selectedStudentId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(attendancesRepository.GetAbsenteesimPercentage(selectedStudentId) + "%");
                        Console.WriteLine("Press any key to back to previous menu");
                        Console.ReadKey();
                        break;


                    case 4:

                        var surnameStatisticalList = studentsRepository.GetRecordsCountForSurnames();

                        foreach(var surname in surnameStatisticalList)
                        {
                            Console.WriteLine($"{surname.Surname} -  {surname.Count}");
                        }

                        Console.WriteLine("Saved! Press any key to back to previous menu");
                        Console.ReadKey();

                        break;


                    case 5:
                        var statistics = studentsRepository.GetNumberOfStudentsPerGroup();

                        foreach(var stat in statistics)
                        {
                            Console.WriteLine($"{stat.GroupId} | {stat.GroupName} | {stat.TotalCount}");
                        }
                        Console.WriteLine("Press any key to back to previous menu");
                        Console.ReadKey();
                        break;

                    case 6:
                        var monthly_statistics = attendancesRepository.GetMonthlyAbsenteeism();
                        foreach(var monthly in monthly_statistics)
                        {
                            var month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthly.Month);
                            Console.WriteLine($"{month} | {monthly.Year} | {monthly.AbsenteesimPercentage}%");
                        }
                        Console.WriteLine("Press any key to back to previous menu");
                        Console.ReadKey();
                        break;


                    case 9:
                        var top5students = attendancesRepository.GetTop5MostPresentStudents();
                        foreach(var myStudent in top5students)
                        {
                            Console.WriteLine($"{myStudent.FirstName} {myStudent.LastName} - {myStudent.Presence}");
                        }

                        Console.WriteLine("Press any key to back to previous menu");
                        Console.ReadKey();
                        break;

                }

            } while (choice != 999);
        }

        static void StudentsMenu(StudentsRepository studentsRepository, GroupsRepository groupsRepository)
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
                Console.WriteLine("5. Add student");
                Console.WriteLine("6. Delete Student");
                Console.WriteLine("7. Update student");


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
                        Console.WriteLine("Input group name: ");
                        string groupName = Console.ReadLine();

                        var filteredByGroup = studentsRepository.GetByGroup(groupName);

                        foreach (var student in filteredByGroup)
                        {
                            Console.WriteLine($"{student.Id}\t{student.Name}\t{student.Surname}");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Press a key to go back to Students menu...");
                        break;

                    case 4:
                        Console.WriteLine("Input student id: ");
                        int studentId = Convert.ToInt32(Console.ReadLine());

                        Student filteredStudent = studentsRepository.Get(studentId);

                        if(filteredStudent != null)
                        {
                            Console.WriteLine($"Student Id card: {filteredStudent.IdCardNo}");
                            Console.WriteLine($"Student Name: {filteredStudent.Name}");
                            Console.WriteLine($"Student Surname: {filteredStudent.Surname}");
                            Console.WriteLine($"Student Email: {filteredStudent.Email}");
                            Console.WriteLine($"Student Group Name: {filteredStudent.Group.Name}");
                        }
                        else
                        {
                            Console.WriteLine("No student was found with that id");
                        }

                            Console.WriteLine();
                        Console.WriteLine("Press a key to go back to Students menu...");

                        break;

                    case 5:
                        Student myNewStudent = new Student();
                        Console.WriteLine("Input the student's name");
                        myNewStudent.Name = Console.ReadLine();

                        Console.WriteLine("Input the student's surname");
                        myNewStudent.Surname = Console.ReadLine();

                        Console.WriteLine("Input the student's email");
                        myNewStudent.Email = Console.ReadLine();

                        Console.WriteLine("Input the student's idcard no");
                        myNewStudent.IdCardNo = Console.ReadLine();

                        Console.WriteLine("Input the student's group ID");
                        //...display all the groups
                        foreach(var g in groupsRepository.Get())
                        {
                            Console.WriteLine($"{g.Id} - {g.Name}");
                        }

                        myNewStudent.GroupFK = Convert.ToInt32(Console.ReadLine());

                        studentsRepository.Add(myNewStudent);

                        Console.WriteLine("Student Added. Press a key to go back to Students menu...");

                        break;

                    case 6:

                        Console.WriteLine("input student id");
                        int studentIdToBeDeleted = Convert.ToInt32(Console.ReadLine());

                        studentsRepository.Delete(studentIdToBeDeleted);

                        Console.WriteLine("Student Deleted. " +
                            "Press a key to go back to Students menu...");

                        break;

                    case 7:
                        Console.WriteLine("input student id you would like to amend");
                        int studentIdToBeUpdated = Convert.ToInt32(Console.ReadLine());

                        Student myStudentUpdate = new Student();
                        myStudentUpdate.Id = studentIdToBeUpdated;

                        Console.WriteLine("Input the student's name");
                        myStudentUpdate.Name = Console.ReadLine();

                        Console.WriteLine("Input the student's surname");
                        myStudentUpdate.Surname = Console.ReadLine();

                        Console.WriteLine("Input the student's email");
                        myStudentUpdate.Email = Console.ReadLine();

                        Console.WriteLine("Input the student's idcard no");
                        myStudentUpdate.IdCardNo = Console.ReadLine();

                        Console.WriteLine("Input the student's group ID");
                        //...display all the groups
                        foreach (var g in groupsRepository.Get())
                        {
                            Console.WriteLine($"{g.Id} - {g.Name}");
                        }

                        myStudentUpdate.GroupFK = Convert.ToInt32(Console.ReadLine());

                        studentsRepository.Update(myStudentUpdate);

                        Console.WriteLine("Student Updated. " +
                          "Press a key to go back to Students menu...");


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


        static void GroupsMenu() {

            //1. Get All groups
            //2. Go back to main menu

        }

        static void UnitsMenu() {
         //1. Get All Units
         //2. Go back to main menu
        
        }
    }
}
