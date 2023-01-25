
using Logic.Enums;
using MediaBazaar.Logic.Models;

namespace Logic.Models
{
    public class Attendance
    {
        public Attendance(Employee employee, bool? isPresent,string absenceReason, AttendanceStatus? attendanceStatus) 
        {
            this.Employee = employee;
            this.IsPresent = isPresent;
            this.AbsenceReason = absenceReason;
            this.AttendanceStatus = attendanceStatus;
        }

        public Employee Employee { get; set; }

        public bool? IsPresent { get;  set; }

        public string AbsenceReason { get;  set; }

        public AttendanceStatus? AttendanceStatus { get;  set; }
    }
}
