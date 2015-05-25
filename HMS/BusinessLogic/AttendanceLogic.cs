using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DataAccess;


namespace BusinessLogic
{
    public class AttendanceLogic : ILogic<Attendance>
    {
        public System.Data.DataTable search(string searchstring, int ID)
        {
            throw new NotImplementedException();
        }

        public Attendance create(Attendance obj)
        {
            String query = "insert into Attendance values(@StaffID, @AttendanceDate, @InTime, @OutTime, @AttendanceStatus)";

            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@StaffID", obj.StaffID));
            lstParams.Add(new SqlParameter("@AttendanceDate", obj.AttendanceDate));
            lstParams.Add(new SqlParameter("@InTime", obj.InTime));
            lstParams.Add(new SqlParameter("@OutTime", obj.OutTime));
            lstParams.Add(new SqlParameter("@AttendanceStatus", obj.AttendanceStatus));

            int res = DBUtility.Modify(query, lstParams);

            if (res == 1)
            {
                String selectQuery = "select * from Attendance where StaffID=@StaffID and AttendanceDate=@AttendanceDate";

                List<SqlParameter> lstParams1 = new List<SqlParameter>();

                lstParams1.Add(new SqlParameter("@StaffID", obj.StaffID));
                lstParams1.Add(new SqlParameter("@AttendanceDate", obj.AttendanceDate));
                lstParams1.Add(new SqlParameter("@InTime", obj.InTime));
                lstParams1.Add(new SqlParameter("@OutTime", obj.OutTime));
                lstParams1.Add(new SqlParameter("@AttendanceStatus", obj.AttendanceStatus));

                DataTable dt = DBUtility.Select(selectQuery, lstParams1);

                if (dt.Rows.Count == 1)
                {
                    return new Attendance(Convert.ToInt32(dt.Rows[0]["AttenddanceID"]),
                    Convert.ToInt32(dt.Rows[0]["StaffID"]),
                    Convert.ToDateTime(dt.Rows[0]["AttendanceDate"]),
                    Convert.ToDateTime(dt.Rows[0]["InTime"]),
                    Convert.ToDateTime(dt.Rows[0]["OutTime"]),
                    Convert.ToBoolean(dt.Rows[0]["AttendanceStatus"]));
                }
                return null;
            }
            return null;
        }

        public int update(Attendance obj)
        {
            String query = "update Attendance set AttendanceDate=@AttendanceDate, InTime=@InTime, OutTime=@OutTime, AttendanceStatus=@AttendanceStatus where AttendanceID=@AttendanceID and StaffID=@StaffID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@StaffID", obj.StaffID));
            lstParams.Add(new SqlParameter("@AttendanceID", obj.AttendanceID));
            lstParams.Add(new SqlParameter("@AttendanceDate", obj.AttendanceDate));
            lstParams.Add(new SqlParameter("@InTime", obj.InTime));
            lstParams.Add(new SqlParameter("@OutTime", obj.OutTime));
            lstParams.Add(new SqlParameter("@AttendanceStatus", obj.AttendanceStatus));

            return DBUtility.Modify(query, lstParams);
        }

        public int delete(int id)
        {
            String query = "delete from Attendance where AttendanceID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);
        }

        public Attendance selectById(int id)
        {
            String query = "select * from Attendance where AttendanceID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new Attendance(Convert.ToInt32(dt.Rows[0]["AttenddanceID"]),
                Convert.ToInt32(dt.Rows[0]["StaffID"]),
                Convert.ToDateTime(dt.Rows[0]["AttendanceDate"]),
                Convert.ToDateTime(dt.Rows[0]["InTime"]),
                Convert.ToDateTime(dt.Rows[0]["OutTime"]),
                Convert.ToBoolean(dt.Rows[0]["AttendanceStatus"]));
            }
            else
            {
                return null;
            }

        }

        public DataTable selectAll()
        {
            String query = "select * from Attendance";

            return DBUtility.Select(query, new List<SqlParameter>());
        }

        public DataTable getAttendanceForRange(DateTime FromDate, DateTime ToDate, int StaffID, string Flag)
        {
            if (Flag == "Staff")
            {
                String query = "select * from Attendance where Attendance.StaffID=@StaffID and AttendanceDate between @FromDate and @ToDate";

                List<SqlParameter> lstParams = new List<SqlParameter>();

                lstParams.Add(new SqlParameter("@StaffID", StaffID));
                lstParams.Add(new SqlParameter("@FromDate", FromDate));
                lstParams.Add(new SqlParameter("@ToDate", ToDate));

                return DBUtility.Select(query, lstParams);
            }
            else
            {
                return null;
            }            
        }

        public DataTable getAttendanceForRange(DateTime FromDate, DateTime ToDate, int DepartmentID, int AccountID)
        {
            if (DepartmentID == 0)
            {
                return getAttendanceForRange(FromDate, ToDate, AccountID);
            }
            String query = "select Department.Name as 'DepartmentName', Staff.*, Attendance.* from Attendance, Staff, Department where Attendance.StaffID=Staff.StaffID and Staff.DepartmentID=Department.DepartmentID and Staff.DepartmentID = @DepartmentID and Staff.AccountID = @AccountID and AttendanceDate between @FromDate and @ToDate";

            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@DepartmentID", DepartmentID));
            lstParams.Add(new SqlParameter("@AccountID", AccountID));
            lstParams.Add(new SqlParameter("@FromDate", FromDate));
            lstParams.Add(new SqlParameter("@ToDate", ToDate));

            return DBUtility.Select(query, lstParams);
        }

        public DataTable getAttendanceForRange(DateTime FromDate, DateTime ToDate, int AccountID)
        {
            String query = "select Department.Name as 'DepartmentName', Staff.*, Attendance.* from Attendance, Staff, Department where Attendance.StaffID=Staff.StaffID and Staff.DepartmentID=Department.DepartmentID and Staff.AccountID = @AccountID and AttendanceDate between @FromDate and @ToDate";

            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@AccountID", AccountID));
            lstParams.Add(new SqlParameter("@FromDate", FromDate));
            lstParams.Add(new SqlParameter("@ToDate", ToDate));

            return DBUtility.Select(query, lstParams);
        }

        public int getPayableDaysForStaff(DateTime FromDate, DateTime ToDate, int StaffID)
        {
            String query = "select COUNT(AttendanceID) from Attendance where AttendanceDate BETWEEN @FromDate AND @ToDate and StaffID=@StaffID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            
            lstParams.Add(new SqlParameter("@FromDate", FromDate));
            lstParams.Add(new SqlParameter("@ToDate", ToDate));
            lstParams.Add(new SqlParameter("@StaffID", StaffID));

            return Convert.ToInt32(DBUtility.Select(query, lstParams).Rows[0][0]);
        }

        public DataTable getStaffForAttendance(int DepartmentID, int AccountID)
        {
            if (DepartmentID == 0)
            {
                return getAllStaffForAttendance(AccountID);
            }
            String query = "select * from Staff where Staff.StaffID NOT IN (select StaffID from Attendance where AttendanceDate=@Today) and Staff.DepartmentID=@DepartmentID and AccountID=@AccountID";            
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@DepartmentID", DepartmentID));
            lstParams.Add(new SqlParameter("@AccountID", AccountID));
            lstParams.Add(new SqlParameter("@Today", DateTime.Now.Date));

            return DBUtility.Select(query, lstParams);
        }

        public DataTable getAllStaffForAttendance(int AccountID)
        {
            String query = "select * from Staff where Staff.StaffID NOT IN (select StaffID from Attendance where AttendanceDate=@Today) and AccountID=@AccountID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@AccountID", AccountID));
            lstParams.Add(new SqlParameter("@Today", DateTime.Now.Date));

            return DBUtility.Select(query, lstParams);
        }
    }
}