﻿using System;
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
    public class ServiceLogic : ILogic<Service>
    {
        public DataTable search(String searchstring, int ID)
        {
            String query = "select * from Service where Name like=@Name and AccountID=@ID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", searchstring));
            lstParams.Add(new SqlParameter("@ID", ID));

            return DBUtility.Select(query, lstParams);
        }

        public Service create(Service obj)
        {
            String query = "insert into Service values(@Name, @DepartmentID, @Rate); select * from Service Name=@Name and DepartmentID=@DepartmentID and Rate=@Rate";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@DepartmentID", obj.DepartmentID));
            lstParams.Add(new SqlParameter("@Rate", obj.Rate));

            DataTable dt = DBUtility.Select(query, lstParams);
            if (dt.Rows.Count == 1)
            {
                return new Service(Convert.ToInt32(dt.Rows[0]["ServiceID"]),
                dt.Rows[0]["Name"].ToString(),
                Convert.ToInt32(dt.Rows[0]["DepartmentID"]),
                Convert.ToDouble(dt.Rows[0]["Rate"]));
            }
            else
            {
                return null;
            }
            
        }

        public int update(Service obj)
        {
            String query = "insert into Account values(Name=@Name, DepartmentID=@DepartmentID, Rate=@Rate where ServiceID=@ServiceID)";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@ServiceID", obj.ServiceID));
            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@DepartmentID", obj.DepartmentID));
            lstParams.Add(new SqlParameter("@Rate", obj.Rate));

            return DBUtility.Modify(query, lstParams); 
        }

        public int delete(int id)
        {
            String query = "delete from Service where ServiceID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);  
        }

        public Service selectById(int id)
        {
            String query = "select * from Service where ServiceID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);
            if (dt.Rows.Count == 1)
            {
                return new Service(Convert.ToInt32(dt.Rows[0]["ServiceID"]),
                dt.Rows[0]["Name"].ToString(),
                Convert.ToInt32(dt.Rows[0]["DepartmentID"]),
                Convert.ToDouble(dt.Rows[0]["Rate"]));
            }
            else
            {
                return null;
            }
            
        }

        public DataTable selectAll()
        {
            String query = "select * from Service";

            return DBUtility.Select(query, new List<SqlParameter>());
        }
    }
}