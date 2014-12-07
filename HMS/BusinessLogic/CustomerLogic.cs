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
    public class CustomerLogic : ILogic<Customer>
    {
        public Customer create(Customer obj)
        {
            String query = "insert into Customer values(@CreateDate, @Name, @Email, @Phone, @Username, @Password, @IsActive, @AccountID); select * from Customer where Username=@Username and Password=@Password;";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@CreateDate", obj.CreateDate));
            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@Email", obj.Email));
            lstParams.Add(new SqlParameter("@Phone", obj.Phone));
            lstParams.Add(new SqlParameter("@Username", obj.Username));
            lstParams.Add(new SqlParameter("@Password", obj.Password));
            lstParams.Add(new SqlParameter("@IsActive", obj.IsActive));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));
            
            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new Customer(Convert.ToInt32(dt.Rows[0]["CustomerID"]),
                    Convert.ToDateTime(dt.Rows[0]["CreateDate"]),
                    dt.Rows[0]["Name"].ToString(),
                    dt.Rows[0]["Email"].ToString(),
                    dt.Rows[0]["Phone"].ToString(),
                    dt.Rows[0]["Username"].ToString(),
                    dt.Rows[0]["Password"].ToString(),
                    Convert.ToBoolean(dt.Rows[0]["IsActive"]),
                    Convert.ToInt32(dt.Rows[0]["AccountID"]));
            }
            else
            {
                return null; 
            }
        }

        public int update(Customer obj)
        {
            String query = "update Customer set CreateDate=@CreateDate, Name=@Name, Email=@Email, Phone=@Phone, Username=@Username, Password=@Password, IsActive=@IsActive, AccountID=@AccountID where CustomerID=@CustomerID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@CreateDate", obj.CreateDate));
            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@Email", obj.Email));
            lstParams.Add(new SqlParameter("@Phone", obj.Phone));
            lstParams.Add(new SqlParameter("@Username", obj.Username));
            lstParams.Add(new SqlParameter("@Password", obj.Password));
            lstParams.Add(new SqlParameter("@IsActive", obj.IsActive));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));
            lstParams.Add(new SqlParameter("@CustomerID", obj.CustomerID));
            
            return DBUtility.Modify(query, lstParams); 
        }

        public int delete(int id)
        {
            String query = "delete from Customer where CustomerID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);  
        }

        public Customer selectById(int id)
        {
            String query = "select * from Customer where CustomerID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));

            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new Customer(Convert.ToInt32(dt.Rows[0]["CustomerID"]),
                    Convert.ToDateTime(dt.Rows[0]["CreateDate"]),
                    dt.Rows[0]["Name"].ToString(),
                    dt.Rows[0]["Email"].ToString(),
                    dt.Rows[0]["Phone"].ToString(),
                    dt.Rows[0]["Username"].ToString(),
                    dt.Rows[0]["Password"].ToString(),
                    Convert.ToBoolean(dt.Rows[0]["IsActive"]),
                    Convert.ToInt32(dt.Rows[0]["AccountID"]));
            }
            else
            {
                return null;
            }
        }

        public DataTable selectAll()
        {
            String query = "select * from Customer";

            return DBUtility.Select(query, new List<SqlParameter>());
        }
    }
}
