using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Common
{
    public class AttendanceExistsException: Exception
    {
        public AttendanceExistsException(): base("Attendance already exists!") { }

        public AttendanceExistsException(string message) : base(message) { }

        public AttendanceExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
