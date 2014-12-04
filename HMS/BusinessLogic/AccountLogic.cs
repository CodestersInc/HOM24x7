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
    public class AccountLogic : ILogic<Account>
    {
        public DataTable search(String searchstring, int ID)
        {
            String query;
            List<SqlParameter> lstParams = new List<SqlParameter>();
            if (ID == 0)
            {
                query = "select * from Account where Company like '%'+@Company+'%'";
            }
            else
            {
                lstParams.Add(new SqlParameter("@ID", ID));
                query = "select * from Account where Company like '%'+@Company+'%' and AccountID=@ID";
            }

            lstParams.Add(new SqlParameter("@Company", searchstring));
            return DBUtility.Select(query, lstParams);
        }

        public int create(Account obj)
        {
            String insertQuery = "insert into Account values(@Company, @ContactPerson, @Email, @Phone, @Address, @Website, @Features) ; select max(AccountID) as LastID from Account";
        //    String selectQuery = "select AccountID from Account where Company=@Company and ContactPerson=@ContactPerson and Email=@Email and Phone=@Phone and Address=@Address and Website=@Website and Features=@Features";

                     
                List<SqlParameter> lstInsertParams = new List<SqlParameter>();

                lstInsertParams.Add(new SqlParameter("@Company", obj.Company));
                lstInsertParams.Add(new SqlParameter("@ContactPerson", obj.ContactPerson));
                lstInsertParams.Add(new SqlParameter("@Email", obj.Email));
                lstInsertParams.Add(new SqlParameter("@Phone", obj.Phone));
                lstInsertParams.Add(new SqlParameter("@Address", obj.Address));
                lstInsertParams.Add(new SqlParameter("@Website", obj.Website));
                lstInsertParams.Add(new SqlParameter("@Features", obj.Features));

                DataTable dt = DBUtility.Select(insertQuery, lstInsertParams);
                return Convert.ToInt32(dt.Rows[0][0]); 

        }

        public int update(Account obj)
        {
            String query = "update Account set Company=@Company, Contactperson=@ContactPerson, Email=@Email, Phone=@Phone, Address=@Address, Website=@Website, Features=@Features where AccountID=@AccountID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            int dataVal;
            if(obj.Features==true)
            {
                dataVal = 1;
            }
            else dataVal=0;

            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));
            lstParams.Add(new SqlParameter("@Company", obj.Company));
            lstParams.Add(new SqlParameter("@ContactPerson", obj.ContactPerson));
            lstParams.Add(new SqlParameter("@Email", obj.Email));
            lstParams.Add(new SqlParameter("@Phone", obj.Phone));
            lstParams.Add(new SqlParameter("@Address", obj.Address));
            lstParams.Add(new SqlParameter("@Website", obj.Website));
            lstParams.Add(new SqlParameter("@Features", dataVal));

            return DBUtility.Modify(query, lstParams);
        }

        public int delete(int id)
        {
            String query = "delete from Account where AccountID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);
        }

        public Account selectById(int id)
        {
            String query = "select * from Account where AccountID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);

            return new Account(Convert.ToInt32(dt.Rows[0]["AccountID"]),
                dt.Rows[0]["Company"].ToString(),
                dt.Rows[0]["ContactPerson"].ToString(),
                dt.Rows[0]["Email"].ToString(),
                Convert.ToInt64(dt.Rows[0]["Phone"]),
                dt.Rows[0]["Address"].ToString(),
                dt.Rows[0]["WebSite"].ToString(),
                Convert.ToBoolean(dt.Rows[0]["Features"]));

        }

        public DataTable selectAll()
        {
            String query = "select * from Account";

            return DBUtility.Select(query, new List<SqlParameter>());
        }

        public Account fetchFromModel(Account obj)
        {
            String selectQuery = "select * from Account where Company=@Company and ContactPerson=@ContactPerson and Email=@Email and Phone=@Phone and Address=@Address and Website=@Website and Features=@Features";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Company", obj.Company));
            lstParams.Add(new SqlParameter("@ContactPerson", obj.ContactPerson));
            lstParams.Add(new SqlParameter("@Email", obj.Email));
            lstParams.Add(new SqlParameter("@Phone", obj.Phone));
            lstParams.Add(new SqlParameter("@Address", obj.Address));
            lstParams.Add(new SqlParameter("@Website", obj.Website));
            lstParams.Add(new SqlParameter("@Features", obj.Features));

            DataTable dt = DBUtility.Select(selectQuery, lstParams);
            return new Account(Convert.ToInt32(dt.Rows[0]["AccountID"]),
                dt.Rows[0]["Company"].ToString(),
                dt.Rows[0]["ContactPerson"].ToString(),
                dt.Rows[0]["Email"].ToString(),
                Convert.ToInt64(dt.Rows[0]["Phone"]),
                dt.Rows[0]["Address"].ToString(),
                dt.Rows[0]["WebSite"].ToString(),
                Convert.ToBoolean(dt.Rows[0]["Features"]));
        }
    }
}
