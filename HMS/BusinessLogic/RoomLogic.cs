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
    public class RoomLogic : ILogic<Room>
    {
        public DataTable search(string searchstring, int ID)
        {
            String query = "select Room.*, RoomType.Name, Floor.FloorNumber, Floor.FloorID from Room, RoomType, Floor where Room.RoomNumber like @RoomNumber+'%' and Room.FloorID=Floor.FloorID and Room.RoomTypeID=RoomType.RoomTypeID and RoomType.AccountID=@ID;";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@RoomNumber", searchstring));
            lstParams.Add(new SqlParameter("@ID", ID));

            return DBUtility.Select(query, lstParams);
        }

        public Room create(Room obj)
        {
            String insertquery = "insert into Room values(@RoomTypeID, @RoomNumber, @FloorID, @Status);";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@RoomTypeID", obj.RoomTypeID));
            lstParams.Add(new SqlParameter("@RoomNumber", obj.RoomNumber));
            lstParams.Add(new SqlParameter("@FloorID", obj.FloorID));
            lstParams.Add(new SqlParameter("@Status", obj.Status));

            int res = DBUtility.Modify(insertquery, lstParams);

            if (res == 1)
            {
                String selectquery = "select * from Room where RoomTypeID=@RoomTypeID and RoomNumber=@RoomNumber and FloorID=@FloorID and Status=@Status;";
                List<SqlParameter> lstParams1 = new List<SqlParameter>();

                lstParams1.Add(new SqlParameter("@RoomTypeID", obj.RoomTypeID));
                lstParams1.Add(new SqlParameter("@RoomNumber", obj.RoomNumber));
                lstParams1.Add(new SqlParameter("@FloorID", obj.FloorID));
                lstParams1.Add(new SqlParameter("@Status", obj.Status));

                DataTable dt = DBUtility.Select(selectquery, lstParams1);

                if (dt.Rows.Count == 1)
                {
                    return new Room(Convert.ToInt32(dt.Rows[0]["RoomID"]),
                    Convert.ToInt32(dt.Rows[0]["RoomTypeID"]),
                    dt.Rows[0]["RoomNumber"].ToString(),
                    Convert.ToInt32(dt.Rows[0]["FloorID"]),
                    dt.Rows[0]["Status"].ToString());
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public int update(Room obj)
        {
            String query = "update Room set RoomTypeID=@RoomTypeID, RoomNumber=@RoomNumber, FloorID=@FloorID, Status=@Status where RoomID=@RoomID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@RoomID", obj.RoomID));
            lstParams.Add(new SqlParameter("@RoomTypeID", obj.RoomTypeID));
            lstParams.Add(new SqlParameter("@RoomNumber", obj.RoomNumber));
            lstParams.Add(new SqlParameter("@FloorID", obj.FloorID));
            lstParams.Add(new SqlParameter("@Status", obj.Status));

            return DBUtility.Modify(query, lstParams);
        }

        public int delete(int id)
        {
            String query = "delete from Room where RoomID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);
        }

        public Room selectById(int id)
        {
            String query = "select * from Room where RoomID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new Room(Convert.ToInt32(dt.Rows[0]["RoomID"]),
                Convert.ToInt32(dt.Rows[0]["RoomTypeID"]),
                dt.Rows[0]["RoomNumber"].ToString(),
                Convert.ToInt32(dt.Rows[0]["FloorID"]),
                dt.Rows[0]["Status"].ToString());
            }
            else
            {
                return null;
            }
        }

        public DataTable selectAll()
        {
            String query = "select * from Room";

            return DBUtility.Select(query, new List<SqlParameter>());
        }

        public DataTable getFilteredRooms(int RoomTypeID, int FloorID)
        {
            String query = "select * from Room where RoomTypeID=@RoomTypeID and FloorID=@FloorID";

            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@RoomTypeID", RoomTypeID));
            lstParams.Add(new SqlParameter("@FloorID", FloorID));
            return DBUtility.Select(query, lstParams);

        }

        public DataTable selectAll(int AccountID)
        {
            String query = "select Room.* from Room, RoomType where Room.RoomTypeID = RoomType.RoomTypeID and RoomType.AccountID=@AccountID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@AccountID", AccountID));

            return DBUtility.Select(query, lstParams);
        }

        public DataTable getRooms(int FloorID, int AccountID)
        {
            String query = "select Room.* from Room, Floor where Room.FloorID=@FloorID and Floor.FloorID=Room.FloorID and Floor.AccountID=@AccountID";

            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@FloorID", FloorID));
            lstParams.Add(new SqlParameter("@AccountID", AccountID));

            return DBUtility.Select(query, lstParams);
        }
    }
}
