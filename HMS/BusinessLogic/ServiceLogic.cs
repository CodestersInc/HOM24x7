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
            String query = "select Department.Name as 'DepartmentName', ServiceType.Name as 'ServiceTypeName', Service.* from Department, Service, ServiceType where Service.Name like @Name+'%' and Service.ServiceTypeID=@ID and Department.DepartmentID=Service.DepartmentID and ServiceType.ServiceTypeID = Service.ServiceTypeID order by Service.Name";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", searchstring));
            lstParams.Add(new SqlParameter("@ID", ID));

            return DBUtility.Select(query, lstParams);
        }

        public Service create(Service obj)
        {
            String query = "insert into Service values(@Name, @DepartmentID, @Rate, @Image @ServiceTypeID)";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@DepartmentID", obj.DepartmentID));
            lstParams.Add(new SqlParameter("@Rate", obj.Rate));
            lstParams.Add(new SqlParameter("@Image", obj.Image));
            lstParams.Add(new SqlParameter("@ServiceTypeID", obj.ServiceTypeID));

            int res = DBUtility.Modify(query, lstParams);

            if (res == 1)
            {
                String selectquery = "select * from Service where Name=@ServiceName and DepartmentID=@DepartmentID and Image=@Image and ServiceTypeID=@ServiceTypeID";
                List<SqlParameter> lstParams1 = new List<SqlParameter>();

                lstParams1.Add(new SqlParameter("@ServiceName", obj.Name));
                lstParams1.Add(new SqlParameter("@DepartmentID", obj.DepartmentID));
                lstParams1.Add(new SqlParameter("@ServiceTypeID", obj.ServiceTypeID));

                DataTable dt = DBUtility.Select(selectquery, lstParams1);

                if (dt.Rows.Count == 1)
                {
                    return new Service(Convert.ToInt32(dt.Rows[0]["ServiceID"]),
                    dt.Rows[0]["Name"].ToString(),
                    Convert.ToInt32(dt.Rows[0]["DepartmentID"]),
                    Convert.ToDouble(dt.Rows[0]["Rate"]),
                    dt.Rows[0]["Image"].ToString(),
                    Convert.ToInt32(dt.Rows[0]["ServiceTypeID"]));
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
            String query = "update Service set Name=@Name, DepartmentID=@DepartmentID, Rate=@Rate Image=@Image where ServiceID=@ServiceID and ServiceTypeID=@ServiceTypeID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@ServiceID", obj.ServiceID));
            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@DepartmentID", obj.DepartmentID));
            lstParams.Add(new SqlParameter("@Rate", obj.Rate));
            lstParams.Add(new SqlParameter("@Image", obj.Image));
            lstParams.Add(new SqlParameter("@ServiceTypeID", obj.ServiceTypeID));

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
                dt.Rows[0]["Image"].ToString(),
                Convert.ToInt32(dt.Rows[0]["ServiceTypeID"]));
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