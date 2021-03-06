﻿using System;
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
        //non relative con string: @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\App_Data\HMSDB.mdf;Integrated Security=True"
        //relative con string:"Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"|DataDirectory|HMSDB.mdf\";Integrated Security=True"
        //azure con string: Server=tcp:dptugxwwmi.database.windows.net,1433;Database=hom24x7_db;User ID=vraj@dptugxwwmi;Password=400%fail;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;
        //somee con string: workstation id=HOM24x7DB.mssql.somee.com;packet size=4096;user id=themoonraker13_SQLLogin_1;pwd=zf8zbkbr43;data source=HOM24x7DB.mssql.somee.com;persist security info=False;initial catalog=HOM24x7DB
        private static String connectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"|DataDirectory|HMSDB.mdf\";Integrated Security=True";

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
        public static DataTable InsertAndFetch(String query, List<SqlParameter> lstParams)
        {
            return Select(query,lstParams);
        }
    }
}