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
    public class PlanComponentLogic : ILogic<PlanComponent>
    {
        public System.Data.DataTable search(string searchstring, int ID)
        {
            throw new NotImplementedException();
        }

        public PlanComponent create(PlanComponent obj)
        {
            String query = "insert into PlanComponent values(@PlanComponentStyle, @RoomID, @PlanID, @ComponentID)";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@PlanComponentStyle", obj.PlanComponentStyle));
            lstParams.Add(new SqlParameter("@RoomID", obj.RoomID));
            lstParams.Add(new SqlParameter("@PlanID", obj.PlanID));
            lstParams.Add(new SqlParameter("@ComponentID", obj.ComponentID));

            int res = DBUtility.Modify(query, lstParams);

            if (res == 1)
            {
                String fetchquery = "select * from PlanComponent where PlanComponentStyle=@PlanComponentStyle and RoomID=@RoomID and PlanID=@PlanID and ComponentID=@ComponentID";
                List<SqlParameter> lstParams1 = new List<SqlParameter>();

                lstParams1.Add(new SqlParameter("@PlanComponentStyle", obj.PlanComponentStyle));
                lstParams1.Add(new SqlParameter("@RoomID", obj.RoomID));
                lstParams1.Add(new SqlParameter("@PlanID", obj.PlanID));
                lstParams1.Add(new SqlParameter("@ComponentID", obj.ComponentID));

                DataTable dt = DBUtility.Select(fetchquery, lstParams1);
                if (dt.Rows.Count == 1)
                {
                    return new PlanComponent(Convert.ToInt32(dt.Rows[0]["PlanComponentID"]),
                    dt.Rows[0]["PlanComponentStyle"].ToString(),
                    Convert.ToInt32(dt.Rows[0]["RoomID"]),
                    Convert.ToInt32(dt.Rows[0]["PlanID"]),
                    Convert.ToInt32(dt.Rows[0]["ComponentID"]));
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public int update(PlanComponent obj)
        {
            String query = "update PlanComponent set PlanComponentStyle=@PlanComponentStyle, RoomID=@RoomID, PlanID=@PlanID, ComponentID=@ComponentID where PlanComponentID=@PlanComponentID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@PlanComponentStyle", obj.PlanComponentStyle));
            lstParams.Add(new SqlParameter("@RoomID", obj.RoomID));
            lstParams.Add(new SqlParameter("@PlanID", obj.PlanID));
            lstParams.Add(new SqlParameter("@ComponentID", obj.ComponentID));
            lstParams.Add(new SqlParameter("@PlanComponentID", obj.PlanComponentID));

            return DBUtility.Modify(query, lstParams); 
        }

        public int delete(int PlanComponentID)
        {
            String query = "delete from PlanComponent where PlanComponentID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", PlanComponentID));

            return DBUtility.Modify(query, lstParams);  
        }

        public int deleteAll(int PlanID)
        {
            String query = "delete from PlanComponent where PlanID=@PlanID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@PlanID", PlanID));

            return DBUtility.Modify(query, lstParams);
        }

        public PlanComponent selectById(int id)
        {
            String query = "select * from PlanComponent where PlanComponentID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new PlanComponent(Convert.ToInt32(dt.Rows[0]["PlanComponentID"]),
                       dt.Rows[0]["PlanComponentStyle"].ToString(),
                       Convert.ToInt32(dt.Rows[0]["RoomID"]),
                       Convert.ToInt32(dt.Rows[0]["PlanID"]),
                       Convert.ToInt32(dt.Rows[0]["ComponentID"]));
            }
            else
            {
                return null;
            }    
        }

        public DataTable selectAll()
        {
            String query = "select * from PlanComponent";

            return DBUtility.Select(query, new List<SqlParameter>());
        }

        public DataTable selectAllRoomComponents(int PlanID)
        {
            String query = "select * from PlanComponent where PlanID=@PlanID and ComponentID=0";

            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@PlanID", PlanID));  
        
            return DBUtility.Select(query, lstParams);
        }

        public DataTable selectAllOtherComponents(int PlanID)
        {
            String query = "select * from PlanComponent where PlanID=@PlanID and RoomID=0";

            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@PlanID", PlanID));

            return DBUtility.Select(query, lstParams);
        }
    }
}
