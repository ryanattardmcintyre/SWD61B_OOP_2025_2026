using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Common
{
    //2 terms:
    //Models: classes that are modelled on the database
    //         e.g Student, Unit, Group, Attendance, etc
    //ViewModels: classes that are created to present a selection of
    //            data on screen/ui to make it more "user-friendly"
    //            e.g. AttendanceDetailsViewModel
    public class AttendanceDetailsViewModel
    {
        public string FullName { get; set; }
        public string GroupName { get; set; }
        public string UnitName { get; set; }
        public string StatusName { get; set; }
        public DateTime DateTaken { get; set; }


    }
}
