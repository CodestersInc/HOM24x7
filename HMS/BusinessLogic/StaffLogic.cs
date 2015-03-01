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
        public DataTable searchManager(int ID)
        {
            String query = "select Department.Name as 'DepartmentName', Staff.* from Department,Staff where staff.DepartmentID=Department.DepartmentID and Staff.AccountID=@ID order by Staff.StaffCode";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", ID));

            return DBUtility.Select(query, lstParams);
        }
        public DataTable search(String searchstring, int ID)
        {
            String query = "select Department.Name as 'DepartmentName', Staff.* from Department,Staff where Staff.Name like @Name+'%' and Staff.AccountID=@ID and Department.DepartmentID=Staff.DepartmentID order by Staff.StaffCode";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", searchstring));
            lstParams.Add(new SqlParameter("@ID", ID));

            return DBUtility.Select(query, lstParams);
        }

        public Staff create(Staff obj)
        {
            String query = "insert into Staff values(@StaffCode, @Name, @Email, @Phone, @Username, @Password, @UserType, @Designation, @DOB, @DOJ, @Salary, @IsActive, @DepartmentID, @AccountID)";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@StaffCode", obj.StaffCode));
            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@Email", obj.Email));
            lstParams.Add(new SqlParameter("@Phone", obj.Phone));
            lstParams.Add(new SqlParameter("@Username", obj.Username));
            lstParams.Add(new SqlParameter("@Password", obj.Password));
            lstParams.Add(new SqlParameter("@UserType", obj.UserType));
            lstParams.Add(new SqlParameter("@Designation", obj.Designation));
            lstParams.Add(new SqlParameter("@DOB", obj.DOB));
            lstParams.Add(new SqlParameter("@DOJ", obj.DOJ));
            lstParams.Add(new SqlParameter("@Salary", obj.Salary));
            lstParams.Add(new SqlParameter("@IsActive", obj.IsActive));
            lstParams.Add(new SqlParameter("@DepartmentID", obj.DepartmentID));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));

            int res = DBUtility.Modify(query, lstParams);

            if (res == 1)
            {
                String selectquery = "select * from staff where username=@username and password=@password";

                List<SqlParameter> lstParams1 = new List<SqlParameter>();
                lstParams1.Add(new SqlParameter("@Username", obj.Username));
                lstParams1.Add(new SqlParameter("@Password", obj.Password));

                DataTable dt = DBUtility.Select(selectquery, lstParams1);

                if (dt.Rows.Count == 1)
                {
                    return new Staff(Convert.ToInt32(dt.Rows[0]["StaffID"]),
                        dt.Rows[0]["StaffCode"].ToString(),
                        dt.Rows[0]["Name"].ToString(),
                        dt.Rows[0]["Email"].ToString(),
                        dt.Rows[0]["Phone"].ToString(),
                        dt.Rows[0]["Username"].ToString(),
                        dt.Rows[0]["Password"].ToString(),
                        dt.Rows[0]["UserType"].ToString(),
                        dt.Rows[0]["Designation"].ToString(),
                        Convert.ToDateTime(dt.Rows[0]["DOB"]),
                        Convert.ToDateTime(dt.Rows[0]["DOJ"]),
                        Convert.ToDouble(dt.Rows[0]["Salary"]),
                        Convert.ToBoolean(dt.Rows[0]["IsActive"]),
                        Convert.ToInt32(dt.Rows[0]["DepartmentID"]),
                        Convert.ToInt32(dt.Rows[0]["AccountID"]));
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public int update(Staff obj)
        {
            String query = "update Staff set StaffCode=@StaffCode, Name=@Name, Email=@Email, Phone=@Phone, UserType=@UserType, Designation=@Designation, DOB=@DOB, DOJ=@DOJ, Salary=@Salary, IsActive=@IsActive, DepartmentID=@DepartmentID, AccountID=@AccountID where StaffID=@StaffID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@StaffID", obj.StaffID));
            lstParams.Add(new SqlParameter("@StaffCode", obj.StaffCode));
            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@Email", obj.Email));
            lstParams.Add(new SqlParameter("@Phone", obj.Phone));
            lstParams.Add(new SqlParameter("@UserType", obj.UserType));
            lstParams.Add(new SqlParameter("@Designation", obj.Designation));
            lstParams.Add(new SqlParameter("@DOB", obj.DOB));
            lstParams.Add(new SqlParameter("@DOJ", obj.DOJ));
            lstParams.Add(new SqlParameter("@Salary", obj.Salary));
            lstParams.Add(new SqlParameter("@IsActive", obj.IsActive));
            lstParams.Add(new SqlParameter("@DepartmentID", obj.DepartmentID));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));

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
                dt.Rows[0]["StaffCode"].ToString(),
                dt.Rows[0]["Name"].ToString(),
                dt.Rows[0]["Email"].ToString(),
                dt.Rows[0]["Phone"].ToString(),
                dt.Rows[0]["Username"].ToString(),
                dt.Rows[0]["Password"].ToString(),
                dt.Rows[0]["UserType"].ToString(),
                dt.Rows[0]["Designation"].ToString(),
                Convert.ToDateTime(dt.Rows[0]["DOB"]),
                Convert.ToDateTime(dt.Rows[0]["DOJ"]),
                Convert.ToDouble(dt.Rows[0]["Salary"]),
                Convert.ToBoolean(dt.Rows[0]["IsActive"]),
                Convert.ToInt32(dt.Rows[0]["DepartmentID"]),
                Convert.ToInt32(dt.Rows[0]["AccountID"]));
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
            String query = "select Staff.*, Department.Name as 'DepartmentName' from Staff, Department where Staff.DepartmentID = Department.DepartmentID and Staff.AccountID=@AccountID ";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@AccountID", AccountID));

            return DBUtility.Select(query, lstParams);
        }

        public DataTable selectDistinctDesignation(int AccountID)
        {
            String query = "select DISTINCT Designation as 'DesignationChoices' from Staff where Staff.AccountID=@AccountID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@AccountID", AccountID));

            return DBUtility.Select(query, lstParams);
        }

        public DataTable searchManager(int ID)
        {
            String query = "select Department.Name as 'DepartmentName', Staff.* from Department,Staff where staff.DepartmentID=Department.DepartmentID and Staff.AccountID=@ID order by Staff.StaffCode";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", ID));

            return DBUtility.Select(query, lstParams);
        }

        public Staff login(String username, String password)
        {
            String query = "select * from Staff where Username=@Username and Password=@Password";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Username", username));
            lstParams.Add(new SqlParameter("@Password", password));

            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new Staff(Convert.ToInt32(dt.Rows[0]["StaffID"]),
                dt.Rows[0]["StaffCode"].ToString(),
                dt.Rows[0]["Name"].ToString(),
                dt.Rows[0]["Email"].ToString(),
                dt.Rows[0]["Phone"].ToString(),
                dt.Rows[0]["Username"].ToString(),
                dt.Rows[0]["Password"].ToString(),
                dt.Rows[0]["UserType"].ToString(),
                dt.Rows[0]["Designation"].ToString(),
                Convert.ToDateTime(dt.Rows[0]["DOB"]),
                Convert.ToDateTime(dt.Rows[0]["DOJ"]),
                Convert.ToDouble(dt.Rows[0]["Salary"]),
                Convert.ToBoolean(dt.Rows[0]["IsActive"]),
                Convert.ToInt32(dt.Rows[0]["DepartmentID"]),
                Convert.ToInt32(dt.Rows[0]["AccountID"]));
            }
            else
            {
                return null;
            }
        }
    }
}