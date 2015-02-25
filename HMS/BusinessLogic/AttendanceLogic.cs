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

        public DataTable getStaffByDepartment(int DepartmentID, int AccountID)
        {
            String query = "select * from Staff where AccountID=@AccountID and DepartmentID=@DepartmentID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@DepartmentID", DepartmentID));
            lstParams.Add(new SqlParameter("@AccountID", AccountID));

            return DBUtility.Select(query, lstParams);
        }

        public DataTable getTodaysAttendance(int AccountID)
        {
            throw new NotImplementedException();
        }

        public Attendance create(Attendance obj)
        {
            String query = "insert into Attendance values(@StaffID, @AttendanceDate, @InTime, @OutTime, @AttendanceStatus);";


            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@StaffID", obj.StaffID));
            lstParams.Add(new SqlParameter("@AttendanceDate", obj.AttendanceDate));
            lstParams.Add(new SqlParameter("@InTime", obj.InTime));
            lstParams.Add(new SqlParameter("@OutTime", obj.OutTime));
            lstParams.Add(new SqlParameter("@AttendanceStatus", obj.AttendanceStatus));

            DataTable dt = DBUtility.InsertAndFetch(query, lstParams);

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

        public int update(Attendance obj)
        {
            String query = "update Attendance set StaffID=@StaffID, AttendanceDate=@AttendanceDate, InTime=@InTime, OutTime=@OutTime AttendanceStatus=@AttendanceStatus where AttendanceID=@AttendanceID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@StaffID", obj.StaffID));
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
    }
}
