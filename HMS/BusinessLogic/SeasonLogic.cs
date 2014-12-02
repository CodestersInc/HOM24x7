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
    public class SeasonLogic : ILogic<Season>
    {
        public int create(Season obj)
        {
            String query = "insert into Season values(@Name, @FromDate, @ToDate, @AccountID)";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@FromDate", obj.FromDate));
            lstParams.Add(new SqlParameter("@ToDate", obj.ToDate));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));

            return DBUtility.Modify(query, lstParams); 
        }

        public int update(Season obj)
        {
            String query = "update Season set Name=@Name, FromDate=@FromDate, ToDate=@ToDate, AccountID=@AccountID where SeasonID=@SeasonID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@SeasonID", obj.SeasonID));
            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@FromDate", obj.FromDate));
            lstParams.Add(new SqlParameter("@ToDate", obj.ToDate));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));

            return DBUtility.Modify(query, lstParams); 
        }

        public int delete(int id)
        {
            String query = "delete from Season where SeasonID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);  
        }

        public Season selectById(int id)
        {
            String query = "select * from Season where SeasonID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);

            return new Season(Convert.ToInt32(dt.Rows[0]["SeasonID"]),
                dt.Rows[0]["Name"].ToString(),
                (Convert.ToDateTime(dt.Rows[0]["FromDate"])),
                (Convert.ToDateTime(dt.Rows[0]["ToDate"])),
                (Convert.ToInt32(dt.Rows[0]["AccountID"])));
        }

        public DataTable selectAll()
        {
            String query = "select * from Season";

            return DBUtility.Select(query, new List<SqlParameter>());
        }
    }
}
