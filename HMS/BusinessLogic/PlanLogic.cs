using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BusinessLogic
{
    public class PlanLogic : ILogic<Plan>
    {
        public System.Data.DataTable search(string searchstring, int ID)
        {
            throw new NotImplementedException();
        }

        public Plan create(Plan obj)
        {
            String query = "insert into Plan values(@PlanStyle, @FloorNumber, @AccountID)";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@PlanStyle", obj.PlanStyle));
            lstParams.Add(new SqlParameter("@FloorNumber", obj.FloorNumber));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));

            int res = DBUtility.Modify(query, lstParams);

            if (res == 1)
            {
                String fetchquery = "select * from Plan where PlanStyle=@PlanStyle and FloorNumber=@FloorNumber and AccountID=@AccountID;";
                List<SqlParameter> lstParams1 = new List<SqlParameter>();

                lstParams1.Add(new SqlParameter("@PlanStyle", obj.PlanStyle));
                lstParams1.Add(new SqlParameter("@FloorNumber", obj.FloorNumber));
                lstParams1.Add(new SqlParameter("@AccountID", obj.AccountID));
                DataTable dt = DBUtility.Select(fetchquery, lstParams1);
                if (dt.Rows.Count == 1)
                {
                    return new Plan(Convert.ToInt32(dt.Rows[0]["PlanID"]),
                    dt.Rows[0]["PlanStyle"].ToString(),
                    dt.Rows[0]["FloorNumber"].ToString(),
                    Convert.ToInt32(dt.Rows[0]["AccountID"]));
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public int update(Plan obj)
        {
            String query = "update Plan set PlanStyle=@PlanStyle, FloorNumber=@FloorNumber where PlanID=@PlanID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@PlanID", obj.PlanID));
            lstParams.Add(new SqlParameter("@PlanStyle", obj.PlanStyle));
            lstParams.Add(new SqlParameter("@FloorNumber", obj.FloorNumber));
            lstParams.Add(new SqlParameter("@PlanID", obj.PlanID));

            return DBUtility.Modify(query, lstParams);
        }

        public int delete(int id)
        {
            String query = "delete from Plan where PlanID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);
        }

        public Plan selectById(int id)
        {
            String query = "select * from Plan where PlanID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new Plan(Convert.ToInt32(dt.Rows[0]["PlanID"]),
                    dt.Rows[0]["PlanStyle"].ToString(),
                    dt.Rows[0]["FloorNumber"].ToString(),
                    Convert.ToInt32(dt.Rows[0]["AccountID"]));
            }
            else
            {
                return null;
            }
        }

        public System.Data.DataTable selectAll()
        {
            String query = "select * from Plan";

            return DBUtility.Select(query, new List<SqlParameter>());
        }
    }
}
