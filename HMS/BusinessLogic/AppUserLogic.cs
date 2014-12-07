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
    public class AppUserLogic //: ILogic<AppUser>
    {
        public int create(AppUser obj)
        {
            String query = "insert into AppUser(Name,Email,Phone,AccountID,Username,Password,UserType) values(@Name, @Email, @Phone, @AccountID, @Username, @Password, @UserType)";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@Email", obj.Email));
            lstParams.Add(new SqlParameter("@Phone", obj.Phone));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));
            lstParams.Add(new SqlParameter("@Username", obj.Username));
            lstParams.Add(new SqlParameter("@Password", obj.Password));
            lstParams.Add(new SqlParameter("@UserType", obj.UserType));

            return DBUtility.Modify(query, lstParams); 
        }

        public int update(AppUser obj)
        {
            String query = "update AppUser set Name=@Name, Email=@Email, Phone=@Phone, AccountID = @AccountID UserType=@UserType where Username = @Username and Password = @Password";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@Email", obj.Email));
            lstParams.Add(new SqlParameter("@Phone", obj.Phone));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));
            lstParams.Add(new SqlParameter("@Username", obj.Username));
            lstParams.Add(new SqlParameter("@Password", obj.Password));
            lstParams.Add(new SqlParameter("@UserType", obj.UserType));

            return DBUtility.Modify(query, lstParams); 
        }

        public int delete(int id)
        {
            String query = "delete from AppUser where AppUserID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);  
        }

        public AppUser selectById(int id)
        {
            String query = "select * from AppUser where AppUserID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);

            return new AppUser(Convert.ToInt32(dt.Rows[0]["AppUserID"]),
                dt.Rows[0]["Name"].ToString(),
                dt.Rows[0]["Email"].ToString(),
                dt.Rows[0]["Phone"].ToString(),
                Convert.ToInt32(dt.Rows[0]["AccountID"]),
                dt.Rows[0]["Username"].ToString(),
                dt.Rows[0]["Password"].ToString(),
                dt.Rows[0]["UserType"].ToString());
        }
        
        public DataTable selectAll()
        {
            String query = "select * from AppUser";

            return DBUtility.Select(query, new List<SqlParameter>());
        }

        public AppUser login(String username, String password)
        {
            String query = "select * from AppUser where Username=@Username and Password=@Password";
            
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Username", username));
            lstParams.Add(new SqlParameter("@Password", password));

            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new AppUser(Convert.ToInt32(dt.Rows[0]["AppUserID"]),
                dt.Rows[0]["Name"].ToString(),
                dt.Rows[0]["Email"].ToString(),
                dt.Rows[0]["Phone"].ToString(),
                Convert.ToInt32(dt.Rows[0]["AccountID"]),
                dt.Rows[0]["Username"].ToString(),
                dt.Rows[0]["Password"].ToString(),
                dt.Rows[0]["UserType"].ToString());
            }
            else
            {
                return null;
            } 
        }

        public AppUser getUserFromUsername(String username)
        {
            String query = "select * from AppUser where Username=@Username";
            
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Username", username));

            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new AppUser(Convert.ToInt32(dt.Rows[0]["AppUserID"]),
                dt.Rows[0]["Name"].ToString(),
                dt.Rows[0]["Email"].ToString(),
                dt.Rows[0]["Phone"].ToString(),
                Convert.ToInt32(dt.Rows[0]["AccountID"]),
                dt.Rows[0]["Username"].ToString(),
                dt.Rows[0]["Password"].ToString(),
                dt.Rows[0]["UserType"].ToString());
            }
            else
            {
                return null;
            } 
        }

        public AppUser selectByStaffId(int staffID)
        {
            String query = "select * from AppUser,Staff where Staff.StaffID=@staffID and AppUser.AppUserID=Staff.AppUserID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@staffID", staffID));
            DataTable dt = DBUtility.Select(query, lstParams);
            if (dt.Rows.Count == 1)
            {
                return new AppUser(Convert.ToInt32(dt.Rows[0]["AppUserID"]),
                    dt.Rows[0]["Name"].ToString(),
                    dt.Rows[0]["Email"].ToString(),
                    dt.Rows[0]["Phone"].ToString(),
                    Convert.ToInt32(dt.Rows[0]["AccountID"]),
                    dt.Rows[0]["Name"].ToString(),
                    dt.Rows[0]["Username"].ToString(),
                    dt.Rows[0]["Password"].ToString());
            }
            else
            {
                return null;
            }
        }
    }
}
