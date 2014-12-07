using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using DataAccess;

namespace BusinessLogic
{
    class SystemAdminLogic : ILogic<SystemAdmin>
    {

        public SystemAdmin create(SystemAdmin obj)
        {
            String query = "insert into SystemAdmin(Name,Username,Password,Email,Phone) values(@Name,@AccountID, @Username, @Password, @Email, @Phone); select * from SystemAdmin where Username=@Username and Password=@Password;";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@Username", obj.Username));
            lstParams.Add(new SqlParameter("@Password", obj.Password));
            lstParams.Add(new SqlParameter("@Email", obj.Email));
            lstParams.Add(new SqlParameter("@Phone", obj.Phone));

            DataTable dt = DBUtility.Select(query,lstParams);

            if(dt.Rows.Count == 1)
            {
                return new SystemAdmin(Convert.ToInt32(dt.Rows[0]["SystemAdminID"]),
                    dt.Rows[0]["Name"].ToString(),
                    dt.Rows[0]["Username"].ToString(),
                    dt.Rows[0]["Password"].ToString(),
                    dt.Rows[0]["Email"].ToString(),
                    dt.Rows[0]["Phone"].ToString());

            }
            else
            {
                return null;
            }
            
        }

        public int update(SystemAdmin obj)
        {
            String query = "update SystemAdmin set Name=@Name, Email=@Email, Phone=@Phone where Username = @Username and Password = @Password";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@Email", obj.Email));
            lstParams.Add(new SqlParameter("@Phone", obj.Phone));
            lstParams.Add(new SqlParameter("@Username", obj.Username));
            lstParams.Add(new SqlParameter("@Password", obj.Password));
            
            return DBUtility.Modify(query, lstParams);
        }

        public int delete(int id)
        {
            String query = "delete from SystemAdmin where AppUserID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);
        }

        public SystemAdmin selectById(int id)
        {
            String query = "select * from SystemAdmin where SystemAdminID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);

            return new SystemAdmin(Convert.ToInt32(dt.Rows[0]["SystemAdminID"]),
                dt.Rows[0]["Name"].ToString(),
                dt.Rows[0]["Username"].ToString(),
                dt.Rows[0]["Password"].ToString(),
                dt.Rows[0]["Email"].ToString(),
                dt.Rows[0]["Phone"].ToString());
        }

        public DataTable selectAll()
        {
            String query = "select * from SystemAdmin";

            return DBUtility.Select(query, new List<SqlParameter>());
        }

        public SystemAdmin login(String username, String password)
        {
            String query = "select * from SystemAdmin where Username=@Username and Password=@Password";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Username", username));
            lstParams.Add(new SqlParameter("@Password", password));

            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new SystemAdmin(Convert.ToInt32(dt.Rows[0]["SystemAdminID"]),
                dt.Rows[0]["Name"].ToString(),
                dt.Rows[0]["Username"].ToString(),
                dt.Rows[0]["Password"].ToString(),
                dt.Rows[0]["Email"].ToString(),
                dt.Rows[0]["Phone"].ToString());
            }
            else
            {
                return null;
            }
        }
    }
}
