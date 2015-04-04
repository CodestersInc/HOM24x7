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
    public class FloorLogic:ILogic<Floor>
    {
        public DataTable search(String searchstring, int ID)
        {
            String query = "select * from Floor where FloorNumber like @FloorNumber+'%' and AccountID=@ID order by FloorNumber";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@FloorNumber", searchstring));
            lstParams.Add(new SqlParameter("@ID", ID));

            return DBUtility.Select(query, lstParams);
        }

        public Floor create(Floor obj)
        {
            String query = "insert into Floor(FloorNumber, Description, AccountID) values(@FloorNumber, @Description, @AccountID)";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@FloorNumber", obj.FloorNumber));
            lstParams.Add(new SqlParameter("@Description", obj.Description));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));

            int res = DBUtility.Modify(query, lstParams);

            if (res == 1)
            {
                String selectquery = "select * from Floor where FloorNumber=@FloorNumber and AccountID=@AccountID";
                List<SqlParameter> lstParams1 = new List<SqlParameter>();

                lstParams1.Add(new SqlParameter("@FloorNumber", obj.FloorNumber));
                lstParams1.Add(new SqlParameter("@AccountID", obj.AccountID));

                DataTable dt = DBUtility.Select(selectquery, lstParams1);

                if (dt.Rows.Count == 1)
                {
                    return new Floor(Convert.ToInt32(dt.Rows[0]["FloorID"]),
                    dt.Rows[0]["FloorNumber"].ToString(),
                    dt.Rows[0]["Description"].ToString(),
                    (Convert.ToInt32(dt.Rows[0]["AccountID"])));
                }
                else
                {
                    return null;
                }
            }
            return null;

        }

        public int update(Floor obj)
        {
            String query = "update Floor set FloorNumber=FloorNumber, Description=@Description, AccountID=@AccountID where SeasonID=@SeasonID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@FloorNumber", obj.FloorNumber));
            lstParams.Add(new SqlParameter("@Description", obj.Description));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));

            return DBUtility.Modify(query, lstParams);
        }

        public int delete(int id)
        {
            String query = "delete from Floor where FloorID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);
        }

        public Floor selectById(int id)
        {
            String query = "select * from Floor where FloorID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new Floor(Convert.ToInt32(dt.Rows[0]["FloorID"]),
                    dt.Rows[0]["FloorNumber"].ToString(),
                    dt.Rows[0]["Description"].ToString(),
                    (Convert.ToInt32(dt.Rows[0]["AccountID"])));
            }
            else
            {
                return null;
            }

        }

        public DataTable selectAll()
        {
            String query = "select * from Floor";

            return DBUtility.Select(query, new List<SqlParameter>());
        }

        public DataTable selectAll(int id)
        {
            String query = "select * from Floor where AccountID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            return DBUtility.Select(query, lstParams);
        }

        /* Obtain floors whose plan isn't configured yet */
        public DataTable selectFloorsWithoutPlan(int AccountID)
        {
            String query = "select * from Floor where Floor.FloorID NOT IN (select FloorPlan.FloorID from FloorPlan) and Floor.AccountID = @AccountID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@AccountID", AccountID));
            return DBUtility.Select(query, lstParams);
        }

        public DataTable getFloorsForRoomType(int RoomTypeID, int AccountID)
        {
            String query = "select DISTINCT Floor.FloorNumber, Floor.FloorID from Floor, Room, RoomType where Room.FloorID = Floor.FloorID and Room.RoomTypeID=RoomType.RoomTypeID and Room.RoomTypeID =@RoomTypeID and Floor.AccountID=@AccountID";

            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@RoomTypeID", RoomTypeID));
            lstParams.Add(new SqlParameter("@AccountID", AccountID));
            return DBUtility.Select(query, lstParams);
        }
    }
}
