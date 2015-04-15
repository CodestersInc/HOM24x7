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
    public class OnlineBookingLogic : ILogic<OnlineBooking>
    {
        public System.Data.DataTable search(string searchstring, int ID)
        {
            throw new NotImplementedException();
        }

        public OnlineBooking create(OnlineBooking obj)
        {
            String query = "insert into OnlineBooking values(@RoomTypeID, @NoOfRooms, @NoOfPersons, @CheckInDate, @PlannedCheckOutDate, @Status, @CustomerID, @ConverterID, @StaffRemarks, @CustomerRemarks, @WebsiteRate, @AccountID)";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@RoomTypeID", obj.RoomTypeID));
            lstParams.Add(new SqlParameter("@NoOfRooms", obj.NumberOfRooms));
            lstParams.Add(new SqlParameter("@NoOfPersons", obj.NumberOfPersons));
            lstParams.Add(new SqlParameter("@CheckInDate", obj.CheckInDate));
            lstParams.Add(new SqlParameter("@PlannedCheckOutDate", obj.PlannedCheckOutDate));
            lstParams.Add(new SqlParameter("@Status", obj.Status));
            lstParams.Add(new SqlParameter("@CustomerID", obj.CustomerID));
            lstParams.Add(new SqlParameter("@ConverterID", obj.ConverterID));
            lstParams.Add(new SqlParameter("@StaffRemarks", obj.StaffRemarks));
            lstParams.Add(new SqlParameter("@CustomerRemarks", obj.CustomerRemarks));
            lstParams.Add(new SqlParameter("@WebsiteRate", obj.WebsiteRate));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));

            int res = DBUtility.Modify(query, lstParams);


            if (res == 1)
            {
                String QueryString = "select * from OnlineBooking where RoomTypeID=@RoomTypeID and NoOfRooms=@NumberOfRooms and NoOfPersons=@NumberOfPersons and CheckInDate=@CheckInDate and PlannedCheckOutDate=@PlannedCheckOutDate and Status=@Status and CustomerID=@CustomerID and ConverterID=@ConverterID and StaffRemarks=@StaffRemarks and CustomerRemarks=@CustomerRemarks and WebsiteRate=@WebsiteRate and AccountID=@AccountID";

                List<SqlParameter> lstParams1 = new List<SqlParameter>();

                lstParams1.Add(new SqlParameter("@RoomTypeID", obj.RoomTypeID));
                lstParams1.Add(new SqlParameter("@NumberOfRooms", obj.NumberOfRooms));
                lstParams1.Add(new SqlParameter("@NumberOfPersons", obj.NumberOfPersons));
                lstParams1.Add(new SqlParameter("@CheckInDate", obj.CheckInDate));
                lstParams1.Add(new SqlParameter("@PlannedCheckOutDate", obj.PlannedCheckOutDate));
                lstParams1.Add(new SqlParameter("@Status", obj.Status));
                lstParams1.Add(new SqlParameter("@CustomerID", obj.CustomerID));
                lstParams1.Add(new SqlParameter("@ConverterID", obj.ConverterID));
                lstParams1.Add(new SqlParameter("@StaffRemarks", obj.StaffRemarks));
                lstParams1.Add(new SqlParameter("@CustomerRemarks", obj.CustomerRemarks));
                lstParams1.Add(new SqlParameter("@WebsiteRate", obj.WebsiteRate));
                lstParams1.Add(new SqlParameter("@AccountID", obj.AccountID));

                DataTable dt = DBUtility.Select(QueryString, lstParams1);

                return new OnlineBooking(Convert.ToInt32(dt.Rows[0]["OnlineBookingID"]),
                Convert.ToInt32(dt.Rows[0]["RoomTypeID"]),
                Convert.ToInt32(dt.Rows[0]["NoOfRooms"]),
                Convert.ToInt32(dt.Rows[0]["NoOfPersons"]),
                Convert.ToDateTime(dt.Rows[0]["CheckInDate"]),
                Convert.ToDateTime(dt.Rows[0]["PlannedCheckoutDate"]),
                dt.Rows[0]["Status"].ToString(),
                Convert.ToInt32(dt.Rows[0]["CustomerID"]),
                Convert.ToInt32(dt.Rows[0]["ConverterID"]),
                dt.Rows[0]["StaffRemarks"].ToString(),
                dt.Rows[0]["CustomerRemarks"].ToString(),
                Convert.ToDouble(dt.Rows[0]["WebsiteRate"]),
                Convert.ToInt32(dt.Rows[0]["AccountID"]));
            }
            else
            {
                return null;
            }
        }

        public int update(OnlineBooking obj)
        {
            String query = "update Booking RoomTypeID=@RoomTypeID,NoOfRooms=@NoOfRooms NoOfPersons=@NumberOfPersons, CheckInDate=@CheckInDate, PlannedCheckOutDate=@PlannedCheckOutDate, Status=@Status, CustomerID=@CustomerID, ConverterID=@ConverterID, StaffRemarks=@StaffRemarks, CustomerRemarks=@CustomerRemarks, WebsiteRate=@WebsiteRate AccountID=@AccountID where OnlineBookingID=@OnlineBookingID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@OnlineBookingID", obj.OnlineBookingID));
            lstParams.Add(new SqlParameter("@RoomTypeID", obj.RoomTypeID));
            lstParams.Add(new SqlParameter("@NoOfRooms", obj.NumberOfRooms));
            lstParams.Add(new SqlParameter("@NumberOfPersons", obj.NumberOfPersons));
            lstParams.Add(new SqlParameter("@CheckInDate", obj.CheckInDate));
            lstParams.Add(new SqlParameter("@PlannedCheckOutDate", obj.PlannedCheckOutDate));
            lstParams.Add(new SqlParameter("@Status", obj.Status));
            lstParams.Add(new SqlParameter("@CustomerID", obj.CustomerID));
            lstParams.Add(new SqlParameter("@ConverterID", obj.ConverterID));
            lstParams.Add(new SqlParameter("@StaffRemarks", obj.StaffRemarks));
            lstParams.Add(new SqlParameter("@CustomerRemarks", obj.CustomerRemarks));
            lstParams.Add(new SqlParameter("@WebsiteRate", obj.WebsiteRate));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));

            return DBUtility.Modify(query, lstParams);
        }

        public int delete(int id)
        {
            String query = "delete from OnlineBooking where OnlineBookingID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);  
        }

        public OnlineBooking selectById(int id)
        {
            String query = "select * from OnlineBooking where OnlineBookingID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new OnlineBooking(Convert.ToInt32(dt.Rows[0]["OnlineBookingID"]),
                Convert.ToInt32(dt.Rows[0]["RoomTypeID"]),
                Convert.ToInt32(dt.Rows[0]["NoOfRooms"]),
                Convert.ToInt32(dt.Rows[0]["NumberOfPersons"]),
                Convert.ToDateTime(dt.Rows[0]["CheckInDate"]),
                Convert.ToDateTime(dt.Rows[0]["PlannedCheckoutDate"]),
                dt.Rows[0]["Status"].ToString(),
                Convert.ToInt32(dt.Rows[0]["CustomerID"]),
                Convert.ToInt32(dt.Rows[0]["ConverterID"]),
                dt.Rows[0]["StaffRemarks"].ToString(),
                dt.Rows[0]["CustomerRemarks"].ToString(),
                Convert.ToDouble(dt.Rows[0]["WebsiteRate"]),
                Convert.ToInt32(dt.Rows[0]["AccountID"]));
            }
            else
            {
                return null;
            }
            
        }

        public DataTable selectAll()
        {
            String query = "select * from OnlineBooking";

            return DBUtility.Select(query, new List<SqlParameter>());
        }

        public DataTable selectAll(int AccountID)
        {
            String query = "select * from OnlineBooking where AccountID=@AccountID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@AccountID", AccountID));

            return DBUtility.Select(query, lstParams);
        }
    }
}
