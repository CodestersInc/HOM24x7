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
    public class ComponentLogic : ILogic<Component>
    {
        public DataTable search(string searchstring, int ID)
        {
            String query = "select * from Component where Name like @Name+'%' and AccountID=@AccountID order by Name";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", searchstring));
            lstParams.Add(new SqlParameter("@AccountID", ID));

            return DBUtility.Select(query, lstParams);
        }

        public Component create(Component obj)
        {
            String query = "insert into Component values(@Name, @Type, @Description, @Image, @AccountID)";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@Description", obj.Description));
            lstParams.Add(new SqlParameter("@Type", obj.Type));
            lstParams.Add(new SqlParameter("@Image", obj.Image));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));

            int res = DBUtility.Modify(query, lstParams);

            if (res == 1)
            {
                String fetchquery = "select * from Component where Name=@Name and Type=@Type and Description=@Description and Image=@Image and AccountID=@AccountID;";
                List<SqlParameter> lstParams1 = new List<SqlParameter>();

                lstParams1.Add(new SqlParameter("@Name", obj.Name));
                lstParams1.Add(new SqlParameter("@Description", obj.Description));
                lstParams1.Add(new SqlParameter("@Type", obj.Type));
                lstParams1.Add(new SqlParameter("@Image", obj.Image));
                lstParams1.Add(new SqlParameter("@AccountID", obj.AccountID));

                DataTable dt = DBUtility.Select(fetchquery, lstParams1);
                if (dt.Rows.Count == 1)
                {
                    return new Component(Convert.ToInt32(dt.Rows[0]["ComponentID"]),
                    dt.Rows[0]["Name"].ToString(),
                    dt.Rows[0]["Type"].ToString(),
                    dt.Rows[0]["Description"].ToString(),
                    dt.Rows[0]["Image"].ToString(),
                    Convert.ToInt32(dt.Rows[0]["AccountID"]));
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public int update(Component obj)
        {
            String query = "update Component set Name=@Name, Type=@Type, Description=@Description, Image=@Image, AccountID=@AccountID where ComponentID=@ComponentID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@ComponentID", obj.ComponentID));
            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@Description", obj.Description));
            lstParams.Add(new SqlParameter("@Type", obj.Type));
            lstParams.Add(new SqlParameter("@Image", obj.Image));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));

            return DBUtility.Modify(query, lstParams);
        }

        public int delete(int id)
        {
            String query = "delete from Component where ComponentID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);
        }

        public Component selectById(int id)
        {
            String query = "select * from Component where ComponentID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new Component(Convert.ToInt32(dt.Rows[0]["ComponentID"]),
                    dt.Rows[0]["Name"].ToString(),
                    dt.Rows[0]["Type"].ToString(),
                    dt.Rows[0]["Description"].ToString(),
                    dt.Rows[0]["Image"].ToString(),
                    Convert.ToInt32(dt.Rows[0]["AccountID"]));
            }
            else
            {
                return null;
            }
        }

        public DataTable selectAll()
        {
            String query = "select * from Component";

            return DBUtility.Select(query, new List<SqlParameter>());
        }

        public DataTable selectAll(int AccountID)
        {
            String query = "select * from Component where AccountID=@AccountID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@AccountID", AccountID));

            return DBUtility.Select(query, lstParams);
        }
    }
}
