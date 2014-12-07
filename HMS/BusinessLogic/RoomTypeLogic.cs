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
        public RoomType create(RoomType obj)
        {
            String query = "insert into RoomType values(@Name, @Description, @Photo, @AccountID); select * from RoomTypeLogic where Name=@Name and Description=@Description and Photo=@Photo and AccountID=@AccountID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@Description", obj.Description));
            lstParams.Add(new SqlParameter("@Photo", obj.Photo));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));

            DataTable dt = DBUtility.InsertAndFetch(query, lstParams);

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
    }
}
