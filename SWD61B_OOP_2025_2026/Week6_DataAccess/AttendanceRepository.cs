using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_Common;

namespace Week6_DataAccess
{
    public class AttendanceRepository
    {
        private AttendanceDbContext _context;
        public AttendanceRepository(AttendanceDbContext context)
        {
            _context = context; //assigning the parameter holding the object which
                                //represents the database into a field. Why?
                                //Reason: I need to make calls on that object from the CRUD methods
        }


        public void TakeAttendance(Attendance a)
        { 
           _context.Attendances.Add(a);
           _context.SaveChanges(); //<<<<< without this nothing will be saved in the database
        }

        public void TakeAttendances(List<Attendance> attendances) {
            DateTime timeTaken = DateTime.Now;

            foreach (var attendance in attendances)
            {
                attendance.Timeslot = timeTaken;
                TakeAttendance(attendance);
            }
        }

        public IQueryable<AttendanceDetailsViewModel> GetAttendancesForStudent(int studentId, DateTime fromDate, DateTime to)
        {
            /*
             *   Id  | Student Name | Unit Name | Date + Time | Status
             *   
             *   1       Joe Borg       OOP         16/12/2025   Present
             */

            //Notes:
            //1. We are forming AttendanceDetailsViewModel. Why? because we would like to return
            //   data fetched from various tables which makes sense to the end-user
            //2. Note the benefits we gain from using navigational properties such as a.Student, a.Status
            //   What benefits? we don't need to code complicated inner join statements!!
            //3. Approach 2: is raw linq - we are not using any lambda expressions or built-in methods
            //4. Approach 1: is using LINQ-to-Entities - using the lambda expression

            //Approach 1
            var list = _context.Attendances
                .Where(s=>s.StudentFK==studentId && s.Timeslot >= fromDate && s.Timeslot <= to)
                .OrderByDescending(s=>s.Timeslot)
                .Select(a => new AttendanceDetailsViewModel()
            {
                FullName = a.Student.Name + ' ' + a.Student.Surname,
                DateTaken = a.Timeslot,
                GroupName = a.Student.Group.Name,
                StatusName = a.Status.Name,
                UnitName = a.Unit.Name
            });

            //Approach 2
            //Select * From Attendances
            //Where StudentFK = studentId and Timeslot >= from and Timeslot <= to
            IQueryable<AttendanceDetailsViewModel> listApproach2 =
                 from a in _context.Attendances
                 where a.StudentFK == studentId && a.Timeslot>= fromDate && a.Timeslot<=to
                 orderby a.Timeslot descending //most recent one
                 select new AttendanceDetailsViewModel()
                 {
                     FullName = a.Student.Name + ' ' + a.Student.Surname,
                     DateTaken = a.Timeslot,
                     GroupName = a.Student.Group.Name,
                     StatusName = a.Status.Name,
                     UnitName = a.Unit.Name
                 };

            return listApproach2;
        }


        public double GetAbsenteesimPercentage(int studentId)
        {
            //STUDENT = 3
            //Attendance Records Count = 2
            //Absent Records Count = 1

            // (1 / 2) * 100% = 50%

            //1/2 = 0
            //*100 = 0

            var result = from a in _context.Attendances
                         where a.StudentFK == studentId
                         group a by a.StudentFK into cluster
                         select (((cluster.Where(x => x.StatusFK == 2).Count() * 1.0) / (cluster.Count()*1.0)) * 100.0);

            return result.First();
        }





    }
}
