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
        public System.Data.DataTable search(string searchstring, int ID)
        {
            throw new NotImplementedException();
        }

        public Room create(Room obj)
        {
            String query = "insert into Room values(@RoomTypeID, @Number, @Floor, @Building, @Status); select * from Room where RoomTypeID=@RoomTypeID, Number=@Number, Floor=@Floor, Building=@Building, Status=@Status";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@RoomTypeID", obj.RoomTypeID));
            lstParams.Add(new SqlParameter("@Number", obj.Number));
            lstParams.Add(new SqlParameter("@Floor", obj.Floor));
            lstParams.Add(new SqlParameter("@Building", obj.Building));
            lstParams.Add(new SqlParameter("@Status", obj.Status));

            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new Room(Convert.ToInt32(dt.Rows[0]["RoomID"]),
                Convert.ToInt32(dt.Rows[0]["RoomTypeID"]),
                dt.Rows[0]["Number"].ToString(),
                dt.Rows[0]["Floor"].ToString(),
                dt.Rows[0]["Building"].ToString(),
                dt.Rows[0]["Status"].ToString());

            }
            else
            {
                return null;
            }
        }

        public int update(Room obj)
        {
            String query = "update Room set RoomTypeID=@RoomTypeID, Number=@Number, Floor=@Floor, Building=@Building, Status=@Status where RoomID=@RoomID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@RoomID", obj.RoomID));
            lstParams.Add(new SqlParameter("@RoomTypeID", obj.RoomTypeID));
            lstParams.Add(new SqlParameter("@Number", obj.Number));
            lstParams.Add(new SqlParameter("@Floor", obj.Floor));
            lstParams.Add(new SqlParameter("@Building", obj.Building));
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
            String query = "select * from Room where PaySlipID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new Room(Convert.ToInt32(dt.Rows[0]["RoomID"]),
                Convert.ToInt32(dt.Rows[0]["RoomTypeID"]),
                dt.Rows[0]["Number"].ToString(),
                dt.Rows[0]["Floor"].ToString(),
                dt.Rows[0]["Building"].ToString(),
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
    }
}
