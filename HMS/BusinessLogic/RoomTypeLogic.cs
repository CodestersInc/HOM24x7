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
    public class RoomTypeLogic : ILogic<RoomType>
    {
        public DataTable search(String searchstring, int ID)
        {
            String query = "select * from RoomType where RoomType.Name like @Name+'%' and AccountID=@ID order by RoomType.Name";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", searchstring));
            lstParams.Add(new SqlParameter("@ID", ID));

            return DBUtility.Select(query, lstParams);
        }

        public RoomType create(RoomType obj)
        {
            String query = "insert into RoomType values(@Name, @Description, @Photo, @AccountID)";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@Description", obj.Description));
            lstParams.Add(new SqlParameter("@Photo", obj.Photo));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));

            int res = DBUtility.Modify(query, lstParams);

            if(res==1)
            {
                String fetchquery = "select * from RoomType where Name=@Name and Description=@Description and Photo=@Photo and AccountID=@AccountID";
                List<SqlParameter> lstParams1 = new List<SqlParameter>();

                lstParams1.Add(new SqlParameter("@Name", obj.Name));
                lstParams1.Add(new SqlParameter("@Description", obj.Description));
                lstParams1.Add(new SqlParameter("@Photo", obj.Photo));
                lstParams1.Add(new SqlParameter("@AccountID", obj.AccountID));
                
                
                DataTable dt = DBUtility.Select(fetchquery, lstParams1);
                
                if (dt.Rows.Count == 1)
                {
                    return new RoomType(Convert.ToInt32(dt.Rows[0]["RoomTypeID"]),
                    dt.Rows[0]["Name"].ToString(),
                    dt.Rows[0]["Description"].ToString(),
                    dt.Rows[0]["Photo"].ToString(),
                    Convert.ToInt32(dt.Rows[0]["AccountID"]));
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public int update(RoomType obj)
        {
            String query = "update RoomType set Name=@Name, Description=@Description, Photo=@Photo, AccountID=@AccountID where RoomTypeID=@RoomTypeID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@RoomTypeID", obj.RoomTypeID));
            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@Description", obj.Description));
            lstParams.Add(new SqlParameter("@Photo", obj.Photo));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));

            return DBUtility.Modify(query, lstParams); 
        }

        public int delete(int id)
        {
            String query = "delete from RoomType where RoomTypeID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);  
        }

        public int deleteAllSeasonRooms(int id)
        {
            String query = "delete from SeasonRoom where RoomTypeID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);
        }

        public RoomType selectById(int id)
        {
            String query = "select * from RoomType where RoomTypeID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new RoomType(Convert.ToInt32(dt.Rows[0]["RoomTypeID"]),
                dt.Rows[0]["Name"].ToString(),
                dt.Rows[0]["Description"].ToString(),
                dt.Rows[0]["Photo"].ToString(),
                Convert.ToInt32(dt.Rows[0]["AccountID"]));
            }
            else
            {
                return null;
            }
            
        }

        public DataTable selectAll()
        {
            String query = "select * from RoomType";

            return DBUtility.Select(query, new List<SqlParameter>());
        }

        public DataTable selectAll(int accountID)
        {
            String query = "select * from RoomType where AccountID=@AccountID";

            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@AccountID", accountID));

            return DBUtility.Select(query, lstParams);
        }

        public int getWebsiteRate(int RoomTypeID, DateTime Date, int AccountID)
        {
            String query = "select WebsiteRate from SeasonRoom where SeasonRoom.RoomTypeID=@RoomTypeID and SeasonRoom.SeasonID=(select Season.SeasonID from Season where Season.FromDate < @Date AND Season.ToDate > @Date and Season.AccountID=@AccountID)";

            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@RoomTypeID", RoomTypeID));
            lstParams.Add(new SqlParameter("@Date", Date));
            lstParams.Add(new SqlParameter("@AccountID", AccountID));

            return Convert.ToInt32(DBUtility.Select(query, lstParams).Rows[0][0]);

        }
    }
}
