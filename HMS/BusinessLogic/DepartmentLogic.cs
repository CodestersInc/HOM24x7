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
    public class DepartmentLogic : ILogic<Department>
    {
        public DataTable search(String searchstring, int ID)
        {
            String query = "select Department.Name as 'Department', Department.DepartmentID, Staff.Name as 'Manager', Staff.StaffID from Department,Staff where Department.ManagerID=Staff.StaffID and Department.Name like @Name+'%' and Department.AccountID=@AccountID order by Department.Name";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", searchstring));
            lstParams.Add(new SqlParameter("@AccountID", ID));

            return DBUtility.Select(query, lstParams);
        }

        public Department create(Department obj)
        {
            String query = "insert into Department values(@Name, @AccountID, @ManagerID)";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));
            lstParams.Add(new SqlParameter("@ManagerID", obj.ManagerID));

            int res = DBUtility.Modify(query, lstParams);

            if(res==1)
            {
                String fetchquery = "select * from Department where Name=@Name and AccountID=@AccountID and ManagerID=@ManagerID;";
                List<SqlParameter> lstParams1 = new List<SqlParameter>();

                lstParams1.Add(new SqlParameter("@Name", obj.Name));
                lstParams1.Add(new SqlParameter("@AccountID", obj.AccountID));
                lstParams1.Add(new SqlParameter("@ManagerID", obj.ManagerID));
                DataTable dt = DBUtility.Select(fetchquery, lstParams1);
                if (dt.Rows.Count == 1)
                {
                    return new Department(Convert.ToInt32(dt.Rows[0]["DepartmentID"]),
                    dt.Rows[0]["Name"].ToString(),
                    Convert.ToInt32(dt.Rows[0]["AccountID"]),
                    Convert.ToInt32(dt.Rows[0]["ManagerID"]));
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public int update(Department obj)
        {
            String query = "update Department set Name=@Name, AccountID=@AccountID, ManagerID=@ManagerID where DepartmentID=@DepartmentID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@DepartmentID", obj.DepartmentID));
            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));
            lstParams.Add(new SqlParameter("@ManagerID", obj.ManagerID));

            return DBUtility.Modify(query, lstParams); 
        }

        public int delete(int id)
        {
            String query = "delete from Department where DepartmentID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);  
        }

        public Department selectById(int id)
        {
            String query = "select * from Department where DepartmentID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new Department(Convert.ToInt32(dt.Rows[0]["DepartmentID"]),
                dt.Rows[0]["Name"].ToString(),
                Convert.ToInt32(dt.Rows[0]["AccountID"]),
                Convert.ToInt32(dt.Rows[0]["ManagerID"]));
            }
            else
            {
                return null;
            }    
        }

        public DataTable selectAll()
        {
            String query = "select * from Department";

            return DBUtility.Select(query, new List<SqlParameter>());
        }

        public DataTable selectAll(int AccountID)
        {
            String query = "select * from Department where AccountID=@AccountID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@AccountID", AccountID));

            return DBUtility.Select(query, lstParams);
        }

        public DataTable selectDistinctDepartment(int AccountID)
        {
            String query = "select DISTINCT Name as 'DepartmentChoices', DepartmentID from Department where AccountID=@AccountID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@AccountID", AccountID));

            return DBUtility.Select(query, lstParams);
        }

        public int fetchLastRecordId()
        {
            String query = "select MAX(DepartmentID) from Department";

            DataTable dt = DBUtility.Select(query, new List<SqlParameter>());

            return Convert.ToInt32(dt.Rows[0][0]);
        }
    }
}
