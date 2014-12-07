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
    public class SeasonRoomLogic : ILogic<SeasonRoom>
    {
        public SeasonRoom create(SeasonRoom obj)
        {
            String query = "insert into SeasonRoom values(@SeasonID, @RoomTypeID, @Rate, @AgentDiscount, @MaxDiscount, @WebsiteRate); select * from SeasonRoom where SeasonID=@SeasonID and RoomTypeID=@RoomTypeID and Rate=@Rate and AgentDiscount=@AgentDiscount and MaxDiscount=@MaxDiscount and WebsiteRate=@WebsiteRate";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@SeasonID", obj.SeasonID));
            lstParams.Add(new SqlParameter("@RoomTypeID", obj.RoomTypeID));
            lstParams.Add(new SqlParameter("@Rate", obj.Rate));
            lstParams.Add(new SqlParameter("@AgentDiscount", obj.AgentDiscount));
            lstParams.Add(new SqlParameter("@MaxDiscount", obj.MaxDiscount));
            lstParams.Add(new SqlParameter("@WebsiteRate", obj.WebsiteRate));

            DataTable dt = DBUtility.InsertAndFetch(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new SeasonRoom(Convert.ToInt32(dt.Rows[0]["SeasonRoomID"]),
                Convert.ToInt32(dt.Rows[0]["SeasonID"]),
                Convert.ToInt32(dt.Rows[0]["RoomTypeID"]),
                Convert.ToDouble(dt.Rows[0]["Rate"]),
                Convert.ToDouble(dt.Rows[0]["AgentDiscount"]),
                Convert.ToDouble(dt.Rows[0]["MaxDiscount"]),
                Convert.ToDouble(dt.Rows[0]["WebsiteRate"]));
            }
            else
            {
                return null;
            }
        }

        public int update(SeasonRoom obj)
        {
            String query = "update SeasonRoom set SeasonID=@SeasonID, RoomTypeID=@RoomTypeID, Rate=@Rate, AgentDiscount=@AgentDiscount, MaxDiscount=@MaxDiscount, WebsiteRate=@WebsiteRate where SeasonRommID=@SeasonRommID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@SeasonRoomID", obj.SeasonRoomID));
            lstParams.Add(new SqlParameter("@SeasonID", obj.SeasonID));
            lstParams.Add(new SqlParameter("@RoomTypeID", obj.RoomTypeID));
            lstParams.Add(new SqlParameter("@Rate", obj.Rate));
            lstParams.Add(new SqlParameter("@AgentDiscount", obj.AgentDiscount));
            lstParams.Add(new SqlParameter("@MaxDiscount", obj.MaxDiscount));
            lstParams.Add(new SqlParameter("@WebsiteRate", obj.WebsiteRate));

            return DBUtility.Modify(query, lstParams); 
        }

        public int delete(int id)
        {
            String query = "delete from SeasonRoom where SeasonRoomID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);  
        }

        public SeasonRoom selectById(int id)
        {
            String query = "select * from SeasonRoom where SeasonRoomID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new SeasonRoom(Convert.ToInt32(dt.Rows[0]["SeasonRoomID"]),
                Convert.ToInt32(dt.Rows[0]["SeasonID"]),
                Convert.ToInt32(dt.Rows[0]["RoomTypeID"]),
                Convert.ToDouble(dt.Rows[0]["Rate"]),
                Convert.ToDouble(dt.Rows[0]["AgentDiscount"]),
                Convert.ToDouble(dt.Rows[0]["MaxDiscount"]),
                Convert.ToDouble(dt.Rows[0]["WebsiteRate"]));
            }
            else
            {
                return null;
            }
            
        }

        public DataTable selectAll()
        {
            String query = "select * from SeasonRoom";

            return DBUtility.Select(query, new List<SqlParameter>());
        }
    }
}
