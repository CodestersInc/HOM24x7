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
    class ServiceTypeLogic : ILogic<ServiceType>
    {
        public DataTable search(string searchstring, int ID)
        {
            String query = "select * from ServiceType where Name like @Name+'%' and AccountID=@AccountID order by Name";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", searchstring));
            lstParams.Add(new SqlParameter("@AccountID", ID));

            return DBUtility.Select(query, lstParams);
        }

        public ServiceType create(Component obj)
        {
            String query = "insert into ServiceType values(@Name, @Description, @Image, @AccountID)";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@Description", obj.Description));
            lstParams.Add(new SqlParameter("@Image", obj.Image));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));

            int res = DBUtility.Modify(query, lstParams);

            if (res == 1)
            {
                String fetchquery = "select * from ServiceType where Name=@Name and Description=@Description and Image=@Image and AccountID=@AccountID";
                List<SqlParameter> lstParams1 = new List<SqlParameter>();

                lstParams1.Add(new SqlParameter("@Name", obj.Name));
                lstParams1.Add(new SqlParameter("@Description", obj.Description));
                lstParams1.Add(new SqlParameter("@Image", obj.Image));
                lstParams1.Add(new SqlParameter("@AccountID", obj.AccountID));

                DataTable dt = DBUtility.Select(fetchquery, lstParams1);
                if (dt.Rows.Count == 1)
                {
                    return new ServiceType(Convert.ToInt32(dt.Rows[0]["ComponentID"]),
                    dt.Rows[0]["Name"].ToString(),
                    dt.Rows[0]["Description"].ToString(),
                    dt.Rows[0]["Image"].ToString(),
                    Convert.ToInt32(dt.Rows[0]["AccountID"]));
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public int update(ServiceType obj)
        {
            String query = "update ServiceType set Name=@Name, Description=@Description, Image=@Image, AccountID=@AccountID where ServiceTypeID=@ServiceTypeID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@ServiceTypeID", obj.ServiceTypeID));
            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@Description", obj.Description));
            lstParams.Add(new SqlParameter("@Image", obj.Image));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));

            return DBUtility.Modify(query, lstParams);
        }

        public int delete(int id)
        {
            String query = "delete from ServiceType where ServiceTypeID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);
        }

        public ServiceType selectById(int id)
        {
            String query = "select * from ServiceType where ServiceTypeID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new ServiceType(Convert.ToInt32(dt.Rows[0]["ComponentID"]),
                    dt.Rows[0]["Name"].ToString(),
                    dt.Rows[0]["Description"].ToString(),
                    dt.Rows[0]["Image"].ToString(),
                    Convert.ToInt32(dt.Rows[0]["AccountID"]));
            }
            else
            {
                return null;
            }
        }

        public DataTable selectAll()
        {
            String query = "select * from ServiceType";

            return DBUtility.Select(query, new List<SqlParameter>());
        }

        public DataTable selectAll(int AccountID)
        {
            String query = "select * from ServiceType where AccountID=@AccountID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@AccountID", AccountID));

            return DBUtility.Select(query, lstParams);
        }
    }
}
