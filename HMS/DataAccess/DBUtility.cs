using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DBUtility
    {
        private static String connectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"C:\\Users\\admin\\SkyDrive\\Final year Project\\Code\\HMS\\HMSWeb\\App_Data\\HMSDB.mdf\";Integrated Security=True";

        public static int Modify(String query, List<SqlParameter> lstParams)
        {
            SqlConnection con = new SqlConnection(@connectionString);
            try
            {
                SqlCommand c1 = new SqlCommand(query, con);
                c1.Parameters.AddRange(lstParams.ToArray());
                con.Open();
                return c1.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }

        }
        public static DataTable Select(String query, List<SqlParameter> lstParams)
        {
            SqlConnection con = new SqlConnection(@connectionString);
            try
            {
                SqlCommand c1 = new SqlCommand(query, con);
                c1.Parameters.AddRange(lstParams.ToArray());
                con.Open();
                c1.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(c1);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
            finally
            {
                con.Close();//close con
            }
        }
    }
}