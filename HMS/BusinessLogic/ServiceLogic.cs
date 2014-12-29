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
    public class ServiceLogic : ILogic<Service>
    {
        public DataTable search(String searchstring, int ID)
        {
            String query = "select Department.Name as 'DepartmentName', Service.* from Department,Service where Service.Name like @Name+'%' and Service.AccountID=@ID and Department.DepartmentID=Service.DepartmentID order by Service.Name";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", searchstring));
            lstParams.Add(new SqlParameter("@ID", ID));

            return DBUtility.Select(query, lstParams);
        }

        public Service create(Service obj)
        {
            String query = "insert into Service values(@Name, @DepartmentID, @Rate, @AccountID)";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@DepartmentID", obj.DepartmentID));
            lstParams.Add(new SqlParameter("@Rate", obj.Rate));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));

            int res = DBUtility.Modify(query, lstParams);

            if (res == 1)
            {
                String selectquery = "select * from Service where Name=@ServiceName and DepartmentID=@DepartmentID and AccountID=@AccountID";
                List<SqlParameter> lstParams1 = new List<SqlParameter>();

                lstParams1.Add(new SqlParameter("@ServiceName", obj.Name));
                lstParams1.Add(new SqlParameter("@DepartmentID", obj.DepartmentID));
                lstParams1.Add(new SqlParameter("@AccountID", obj.AccountID));

                DataTable dt = DBUtility.Select(selectquery, lstParams1);

                if (dt.Rows.Count == 1)
                {
                    return new Service(Convert.ToInt32(dt.Rows[0]["ServiceID"]),
                    dt.Rows[0]["Name"].ToString(),
                    Convert.ToInt32(dt.Rows[0]["DepartmentID"]),
                    Convert.ToDouble(dt.Rows[0]["Rate"]),
                    Convert.ToInt32(dt.Rows[0]["AccountID"]));
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public int update(Service obj)
        {
            String query = "update Service set Name=@Name, DepartmentID=@DepartmentID, Rate=@Rate where ServiceID=@ServiceID and AccountID=@AccountID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@ServiceID", obj.ServiceID));
            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@DepartmentID", obj.DepartmentID));
            lstParams.Add(new SqlParameter("@Rate", obj.Rate));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));

            return DBUtility.Modify(query, lstParams);
        }

        public int delete(int id)
        {
            String query = "delete from Service where ServiceID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);
        }

        public Service selectById(int id)
        {
            String query = "select * from Service where ServiceID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);
            if (dt.Rows.Count == 1)
            {
                return new Service(Convert.ToInt32(dt.Rows[0]["ServiceID"]),
                dt.Rows[0]["Name"].ToString(),
                Convert.ToInt32(dt.Rows[0]["DepartmentID"]),
                Convert.ToDouble(dt.Rows[0]["Rate"]),
                Convert.ToInt32(dt.Rows[0]["AccountID"]));
            }
            else
            {
                return null;
            }
        }

        public DataTable selectAll()
        {
            String query = "select * from Service";

            return DBUtility.Select(query, new List<SqlParameter>());
        }
    }
}