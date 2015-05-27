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
        public System.Data.DataTable search(string searchstring, int ID)
        {
            throw new NotImplementedException();
        }

        public SeasonRoom create(SeasonRoom obj)
        {
            String insertquery = "insert into SeasonRoom values(@SeasonID, @RoomTypeID, @Rate, @AgentDiscount, @MaxDiscount, @WebsiteRate);";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@SeasonID", obj.SeasonID));
            lstParams.Add(new SqlParameter("@RoomTypeID", obj.RoomTypeID));
            lstParams.Add(new SqlParameter("@Rate", obj.Rate));
            lstParams.Add(new SqlParameter("@AgentDiscount", obj.AgentDiscount));
            lstParams.Add(new SqlParameter("@MaxDiscount", obj.MaxDiscount));
            lstParams.Add(new SqlParameter("@WebsiteRate", obj.WebsiteRate));

            int res = DBUtility.Modify(insertquery, lstParams);

            if (res == 1)
            {
                String selectquery = "select * from SeasonRoom where SeasonID=@SeasonID and RoomTypeID=@RoomTypeID and Rate=@Rate and AgentDiscount=@AgentDiscount and MaxDiscount=@MaxDiscount and WebsiteRate=@WebsiteRate;";
                List<SqlParameter> lstParams1 = new List<SqlParameter>();

                lstParams1.Add(new SqlParameter("@SeasonID", obj.SeasonID));
                lstParams1.Add(new SqlParameter("@RoomTypeID", obj.RoomTypeID));
                lstParams1.Add(new SqlParameter("@Rate", obj.Rate));
                lstParams1.Add(new SqlParameter("@AgentDiscount", obj.AgentDiscount));
                lstParams1.Add(new SqlParameter("@MaxDiscount", obj.MaxDiscount));
                lstParams1.Add(new SqlParameter("@WebsiteRate", obj.WebsiteRate));

                DataTable dt = DBUtility.Select(selectquery, lstParams1);

                if (dt.Rows.Count == 1)
                {
                    return new SeasonRoom(Convert.ToInt32(dt.Rows[0]["SeasonRoomID"]),
                    Convert.ToInt32(dt.Rows[0]["SeasonID"]),
                    Convert.ToInt32(dt.Rows[0]["RoomTypeID"]),
                    Convert.ToSingle(dt.Rows[0]["Rate"]),
                    Convert.ToSingle(dt.Rows[0]["AgentDiscount"]),
                    Convert.ToSingle(dt.Rows[0]["MaxDiscount"]),
                    Convert.ToSingle(dt.Rows[0]["WebsiteRate"]));
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public int update(SeasonRoom obj)
        {
            String query = "update SeasonRoom set SeasonID=@SeasonID, RoomTypeID=@RoomTypeID, Rate=@Rate, AgentDiscount=@AgentDiscount, MaxDiscount=@MaxDiscount, WebsiteRate=@WebsiteRate where SeasonRoomID=@SeasonRoomID";
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
                Convert.ToSingle(dt.Rows[0]["Rate"]),
                Convert.ToSingle(dt.Rows[0]["AgentDiscount"]),
                Convert.ToSingle(dt.Rows[0]["MaxDiscount"]),
                Convert.ToSingle(dt.Rows[0]["WebsiteRate"]));
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

        public DataTable getAllSeasonRooms(int roomTypeID, int accountID)
        {
            String query = "select SeasonRoom.SeasonRoomID, Season.SeasonID, Season.Name, SeasonRoom.Rate, SeasonRoom.AgentDiscount, SeasonRoom.MaxDiscount, SeasonRoom.WebsiteRate from Season, SeasonRoom where SeasonRoom.SeasonID = Season.SeasonID and SeasonRoom.RoomTypeID=@RoomTypeID and Season.AccountID=@AccountID;";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@AccountID", accountID));
            lstParams.Add(new SqlParameter("@RoomTypeID", roomTypeID));

            return DBUtility.Select(query, lstParams);
        }

        public Double fetchCurrentRoomRate(int RoomTypeID, int AccountID)
        {
            String query = "select SeasonRoom.Rate from SeasonRoom, Season where SeasonRoom.SeasonID = (select Max(SeasonID) from Season where Season.FromDate < '2015/03/29' and Season.ToDate > '2015/03/29' and AccountID=@AccountID) and SeasonRoom.RoomTypeID=@RoomTypeID and Season.SeasonID = SeasonRoom.SeasonID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@AccountID", AccountID));
            lstParams.Add(new SqlParameter("@RoomTypeID", RoomTypeID));

            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 0)
            {
                String query1 = "select SeasonRoom.Rate from SeasonRoom, Season where SeasonRoom.SeasonID=Season.SeasonID and SeasonRoom.RoomTypeID=@RoomTypeID and Season.AccountID=@AccountID";

                List<SqlParameter> lstParams1 = new List<SqlParameter>();
                lstParams1.Add(new SqlParameter("@AccountID", AccountID));
                lstParams1.Add(new SqlParameter("@RoomTypeID", RoomTypeID));

                dt = DBUtility.Select(query1, lstParams1);

                return Convert.ToDouble(dt.Rows[0][0]);
            }
            else
            {
                return Convert.ToDouble(dt.Rows[0][0]);
            }            
        }
    }
}