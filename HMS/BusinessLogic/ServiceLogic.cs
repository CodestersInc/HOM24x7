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
        public int create(Service obj)
        {
            String query = "insert into Account values(@Name, @DepartmentID, @Rate)";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@DepartmentID", obj.DepartmentID));
            lstParams.Add(new SqlParameter("@Rate", obj.Rate));
            
            return DBUtility.Modify(query, lstParams); 
        }

        public int update(Service obj)
        {
            String query = "insert into Account values(Name=@Name, DepartmentID=@DepartmentID, Rate=@Rate where ServiceID=@ServiceID)";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@ServiceID", obj.ServiceID));
            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@DepartmentID", obj.DepartmentID));
            lstParams.Add(new SqlParameter("@Rate", obj.Rate));

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

            return new Service(Convert.ToInt32(dt.Rows[0]["ServiceID"]),
                dt.Rows[0]["Name"].ToString(),
                Convert.ToInt32(dt.Rows[0]["DepartmentID"]),
                Convert.ToDouble(dt.Rows[0]["Rate"]));
            
        }

        public DataTable selectAll()
        {
            String query = "select * from Service";

            return DBUtility.Select(query, new List<SqlParameter>());
        }
    }
}
