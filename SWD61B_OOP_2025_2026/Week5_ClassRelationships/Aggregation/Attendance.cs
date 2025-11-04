using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Aggregation
{
    //Composition
    //e.g. Attendance -> Group
    //e.g. Attendance -> Lecturer | reason: both Lecturer & Group are passed in the constructor and stored in the object

    //Aggregation
    //e.g. Attendance -> Student | reason: Student is not passed in the constructor BUT its used in one of the methods
    //                                     and then stored in one of the Lists which are a property in the (attendance)
    //                                     object.  Therefore the Student object will live as long as the Attendance
    //                                     object lives

    public class Attendance: ILog
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }

        private Group group;
        public Group Group { get { return group; } }
        public Lecturer Lecturer { get; set; }

        public List<Person> PresentPeople { get; set; }
        public List<Person> AbsentPeople { get; set; }


        public Attendance(Lecturer l, Group g) 
        {
            Timestamp = DateTime.Now;
            Lecturer = l;
            group = g;

            PresentPeople = new List<Person>(); //if you don't instantiate these lists you will get
            AbsentPeople = new List<Person>();  //a runtime error when trying to add objects
        }

        public void TakeAttendance(Student s, bool present)
        {
            if (present)
            {
                PresentPeople.Add(s);
            }
            else
            {
                AbsentPeople.Add(s);
            }
        }

        public void WriteToFile(string path)
        {
            System.IO.File.AppendText("Present students: \n");
            foreach (Student s in PresentPeople)
            {
                s.OutputToCSV(path);
            }

            System.IO.File.AppendText("Absent students: \n");
            foreach (Student s in AbsentPeople)
            {
                s.OutputToCSV(path);
            }
        }
    }
}
