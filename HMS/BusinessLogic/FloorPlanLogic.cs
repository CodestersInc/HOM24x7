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
    public class FloorPlanLogic : ILogic<FloorPlan>
    {
        public DataTable search(string searchstring, int ID)
        {
            throw new NotImplementedException();
        }

        public DataTable search(int AccountID)
        {
            String query = "select Floor.FloorNumber as 'FloorNumber', FloorPlan.* from Floor, FloorPlan where Floor.FloorID = FloorPlan.FloorID and Floor.AccountID=@AccountID order by Floor.FloorNumber";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@AccountID", AccountID));

            return DBUtility.Select(query, lstParams);
        }

        public FloorPlan create(FloorPlan obj)
        {
            String query = "insert into FloorPlan values(@PlanStyle, @FloorID, @Image)";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@PlanStyle", obj.PlanStyle));
            lstParams.Add(new SqlParameter("@FloorID", obj.FloorID));
            lstParams.Add(new SqlParameter("@Image", obj.Image));

            int res = DBUtility.Modify(query, lstParams);

            if (res == 1)
            {
                String fetchquery = "select * from FloorPlan where PlanStyle=@PlanStyle and FloorID=@FloorID and Image=@Image;";
                List<SqlParameter> lstParams1 = new List<SqlParameter>();

                lstParams1.Add(new SqlParameter("@PlanStyle", obj.PlanStyle));
                lstParams1.Add(new SqlParameter("@FloorID", obj.FloorID));
                lstParams1.Add(new SqlParameter("@Image", obj.Image));
                DataTable dt = DBUtility.Select(fetchquery, lstParams1);
                if (dt.Rows.Count == 1)
                {
                    return new FloorPlan(Convert.ToInt32(dt.Rows[0]["PlanID"]),
                    dt.Rows[0]["PlanStyle"].ToString(),
                    Convert.ToInt32(dt.Rows[0]["FloorID"]),
                    dt.Rows[0]["Image"].ToString());
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public int update(FloorPlan obj)
        {
            String query = "update FloorPlan set PlanStyle=@PlanStyle, Image=@Image  where PlanID=@PlanID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@PlanID", obj.PlanID));
            lstParams.Add(new SqlParameter("@PlanStyle", obj.PlanStyle));
            lstParams.Add(new SqlParameter("@Image", obj.Image));

            return DBUtility.Modify(query, lstParams);
        }

        public int delete(int id)
        {
            String query = "delete from FloorPlan where PlanID=@PlanID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@PlanID", id));

            return DBUtility.Modify(query, lstParams);
        }

        public FloorPlan selectById(int PlanID)
        {
            String query = "select * from FloorPlan where PlanID=@PlanID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@PlanID", PlanID));
            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new FloorPlan(Convert.ToInt32(dt.Rows[0]["PlanID"]),
                    dt.Rows[0]["PlanStyle"].ToString(),
                    Convert.ToInt32(dt.Rows[0]["FloorID"]),
                    dt.Rows[0]["Image"].ToString());
            }
            else
            {
                return null;
            }
        }

        public DataTable getPlan(int PlanID)
        {
            String query = "select * from FloorPlan where PlanID=@PlanID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@PlanID", PlanID));
            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        public DataTable selectAll()
        {
            String query = "select * from FloorPlan";

            return DBUtility.Select(query, new List<SqlParameter>());
        }
    }
}
