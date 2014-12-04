using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Attendance : IModel
    {
        public int AttendanceID;
        public int StaffID;
        public DateTime AttendanceDate;
        public DateTime InTime;
        public DateTime OutTime;

        public Attendance()
        {

        }

        public Attendance(int AttendanceID, int StaffID, DateTime AttendanceDate, DateTime InTime, DateTime OutTime)
        {
            this.AttendanceID = AttendanceID;
            this.AttendanceDate = AttendanceDate;
            this.StaffID = StaffID;
            this.InTime = InTime;
            this.OutTime = OutTime;
        }
    }
}
