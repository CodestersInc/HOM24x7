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
        public int create(Customer obj)
        {
            String query = "insert into Customer values(@AppUserID, @CreateDate, @IsActive, @Phone, @Address, @Website, @Features)";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@AppUserID", obj.AppUserID));
            lstParams.Add(new SqlParameter("@CreateDate", obj.CreateDate));
            lstParams.Add(new SqlParameter("@IsActive", obj.IsActive));
            
            return DBUtility.Modify(query, lstParams); 
        }

        public int update(Customer obj)
        {
            String query = "update Customer set AppUserID=@AppUserID, CreateDate=@CreateDate, IsActive=@IsActive, Phone=@Phone, Address=@Address, Website=@Website, Features=@Features where CustomerID=@CustomerID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@CustomerID", obj.CustomerID));
            lstParams.Add(new SqlParameter("@AppUserID", obj.AppUserID));
            lstParams.Add(new SqlParameter("@CreateDate", obj.CreateDate));
            lstParams.Add(new SqlParameter("@IsActive", obj.IsActive));

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

            return new Customer(Convert.ToInt32(dt.Rows[0]["CustomerID"]),
                Convert.ToInt32(dt.Rows[0]["AppUserID"]),
                Convert.ToDateTime(dt.Rows[0]["CreateDate"]),
                Convert.ToBoolean(dt.Rows[0]["IsActive"]));
        }

        public Customer selectByAppuserID(int id)
        {
            String query = "select * from Customer where AppUserID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);

            return new Customer(Convert.ToInt32(dt.Rows[0]["CustomerID"]),
                Convert.ToInt32(dt.Rows[0]["AppUserID"]),
                Convert.ToDateTime(dt.Rows[0]["CreateDate"]),
                Convert.ToBoolean(dt.Rows[0]["IsActive"]));
        }

        public DataTable selectAll()
        {
            String query = "select * from Customer";

            return DBUtility.Select(query, new List<SqlParameter>());
        }
    }
}
