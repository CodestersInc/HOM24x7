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
    public class StaffLogic : ILogic<Staff>
    {
        public DataTable search(String searchstring, int ID)
        {
            String query = "select AppUser.*, Staff.StaffID, Department.Name as 'DepartmentName' from AppUser,Department,Staff where AppUser.Name like '%'+@Name+'%' and AppUser.AccountID=@ID and AppUser.AppUserID=Staff.AppUserID and Department.DepartmentID=Staff.DepartmentID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", searchstring));
            lstParams.Add(new SqlParameter("@ID", ID));

            return DBUtility.Select(query, lstParams);
        }

        public int create(Staff obj)
        {
            String query = "insert into Staff values(@AppUserID, @Designation, @DOB, @DOJ, @Salary, @SalaryFrequency, @IsActive, @DepartmentID)";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@AppUserID", obj.AppUserID));
            lstParams.Add(new SqlParameter("@Designation", obj.Designation));
            lstParams.Add(new SqlParameter("@DOB", obj.DOB));
            lstParams.Add(new SqlParameter("@DOJ", obj.DOJ));
            lstParams.Add(new SqlParameter("@Salary", obj.Salary));
            lstParams.Add(new SqlParameter("@SalaryFrequency", obj.SalaryFrequency));
            lstParams.Add(new SqlParameter("@IsActive", obj.IsActive));
            lstParams.Add(new SqlParameter("@DepartmentID", obj.DepartmentID));


            return DBUtility.Modify(query, lstParams);
        }

        public int update(Staff obj)
        {
            String query = "update Staff set AppUserID=@AppUserID, Designation=@Designation, DOB=@DOB, DOJ=@DOJ, Salary=@Salary, SalaryFrequency=@SalaryFrequency, IsActive=@IsActive, DepartmentID=@DepartmentID where StaffID=@StaffID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@StaffID", obj.StaffID));
            lstParams.Add(new SqlParameter("@AppUserID", obj.AppUserID));
            lstParams.Add(new SqlParameter("@Designation", obj.Designation));
            lstParams.Add(new SqlParameter("@DOB", obj.DOB));
            lstParams.Add(new SqlParameter("@DOJ", obj.DOJ));
            lstParams.Add(new SqlParameter("@Salary", obj.Salary));
            lstParams.Add(new SqlParameter("@SalaryFrequency", obj.SalaryFrequency));
            lstParams.Add(new SqlParameter("@IsActive", obj.IsActive));
            lstParams.Add(new SqlParameter("@DepartmentID", obj.DepartmentID));


            return DBUtility.Modify(query, lstParams);
        }

        public int delete(int id)
        {
            String query = "delete from Staff where StaffID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);
        }

        public Staff selectById(int id)
        {
            String query = "select * from Staff where StaffID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new Staff(Convert.ToInt32(dt.Rows[0]["StaffID"]),
                Convert.ToInt32(dt.Rows[0]["AppUserID"]),
                dt.Rows[0]["Designation"].ToString(),
                Convert.ToDateTime(dt.Rows[0]["DOB"]),
                Convert.ToDateTime(dt.Rows[0]["DOJ"]),
                Convert.ToDouble(dt.Rows[0]["Salary"]),
                dt.Rows[0]["SalaryFrequency"].ToString(),
                Convert.ToBoolean(dt.Rows[0]["IsActive"]),
                Convert.ToInt32(dt.Rows[0]["DepartmentID"]));
            }
            else
            {
                return null;
            }

        }

        public Staff selectByAppUserId(int id)
        {
            String query = "select * from Staff where AppUserID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);
            if (dt.Rows.Count == 1)
            {
                return new Staff(Convert.ToInt32(dt.Rows[0]["StaffID"]),
                Convert.ToInt32(dt.Rows[0]["AppUserID"]),
                dt.Rows[0]["Designation"].ToString(),
                Convert.ToDateTime(dt.Rows[0]["DOB"]),
                Convert.ToDateTime(dt.Rows[0]["DOJ"]),
                Convert.ToDouble(dt.Rows[0]["Salary"]),
                dt.Rows[0]["SalaryFrequency"].ToString(),
                Convert.ToBoolean(dt.Rows[0]["IsActive"]),
                Convert.ToInt32(dt.Rows[0]["DepartmentID"]));
            }
            else
            {
                return null;
            }

        }

        public DataTable selectAll()
        {
            String query = "select * from Staff";

            return DBUtility.Select(query, new List<SqlParameter>());
        }

        public DataTable getStaffNames(int AccountID)
        {
            String query = "select AppUser.Name as 'AppUserName', Department.Name as 'DepartmentName', Staff.StaffID as 'StaffID' from AppUser,Department,Staff where AppUser.AppUserID=Staff.AppUserID and AppUser.AccountID=Department.AccountID  and AppUser.AccountID=@AccountID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@AccountID", AccountID));

            return DBUtility.Select(query, lstParams);
        }

        public DataTable selectDistinctDesignation(int AccountID)
        {
            String query = "select DISTINCT Designation as 'DesignationChoice', Staff.StaffID from Department, Staff where AccountID=@AccountID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@AccountID", AccountID));

            DataTable dt = DBUtility.Select(query, lstParams);

            int i = 0;
            for (i = 0; i < dt.Columns.Count; i++)
            {
                dt.Rows[i]["Designation"]=dt.Rows[i]["Designation"].ToString();
                dt.AcceptChanges();
            }
            return dt;
        }
    }
}
