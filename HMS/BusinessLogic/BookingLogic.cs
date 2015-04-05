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
    public class BookingLogic : ILogic<Booking>
    {
        public DataTable search(string searchstring, int ID)
        {
            String query = "select Room.RoomNumber, Customer.*, Booking.* from Room, Customer, Booking where Customer.CustomerID = Booking.CustomerID and Customer.Name like @Name+'%' and Customer.AccountID=@AccountID and Room.RoomID = Booking.RoomID order by Customer.Name";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", searchstring));
            lstParams.Add(new SqlParameter("@AccountID", ID));

            return DBUtility.Select(query, lstParams);
        }

        public Booking create(Booking obj)
        {
            String query = "insert into Booking values(@RoomID, @NumberOfPersons, @CheckInDate, @PlannedCheckOutDate, @CheckOutDate, @Status, @PaidAmount, @CustomerID, @ApproverID, @ReceiverID, @StaffRemarks, @CustomerRemarks, @RoomRate, @PaymentMode, @ChequeNo, @BankName, @OnlineBookingID);";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@RoomID", obj.RoomID));
            lstParams.Add(new SqlParameter("@NumberOfPersons", obj.NumberOfPersons));
            lstParams.Add(new SqlParameter("@CheckInDate", obj.CheckInDate));
            lstParams.Add(new SqlParameter("@PlannedCheckOutDate", obj.PlannedCheckOutDate));
            lstParams.Add(new SqlParameter("@CheckOutDate", obj.CheckOutDate));
            lstParams.Add(new SqlParameter("@Status", obj.Status));
            lstParams.Add(new SqlParameter("@PaidAmount", obj.PaidAmount));
            lstParams.Add(new SqlParameter("@CustomerID", obj.CustomerID));
            lstParams.Add(new SqlParameter("@ApproverID", obj.ApproverID));
            lstParams.Add(new SqlParameter("@ReceiverID", obj.ReceiverID));
            lstParams.Add(new SqlParameter("@StaffRemarks", obj.StaffRemarks));
            lstParams.Add(new SqlParameter("@CustomerRemarks", obj.CustomerRemarks));
            lstParams.Add(new SqlParameter("@RoomRate", obj.RoomRate));
            lstParams.Add(new SqlParameter("@PaymentMode", obj.PaymentMode));
            lstParams.Add(new SqlParameter("@ChequeNo", obj.ChequeNo));
            lstParams.Add(new SqlParameter("@BankName", obj.BankName));
            lstParams.Add(new SqlParameter("@OnlineBookingID", obj.OnlineBookingID));


            int res = DBUtility.Modify(query, lstParams);

            if (res == 1)
            {
                String fetchquery = " select * from Booking where RoomID=@RoomID and NoOfPersons=@NumberOfPersons and CheckInDate=@CheckInDate and PlannedCheckOutDate=@PlannedCheckOutDate and Status=@Status and PaidAmount=@PaidAmount and CustomerID=@CustomerID and ApproverID=@ApproverID and ReceiverID=@ReceiverID and StaffRemarks=@StaffRemarks and CustomerRemarks=@CustomerRemarks and RoomRate=@RoomRate and PaymentMode=@PaymentMode and ChequeNo=@ChequeNo and BankName=@BankName and OnlineBookingID=@OnlineBookingID;";

                lstParams = new List<SqlParameter>();

                lstParams.Add(new SqlParameter("@RoomID", obj.RoomID));
                lstParams.Add(new SqlParameter("@NumberOfPersons", obj.NumberOfPersons));
                lstParams.Add(new SqlParameter("@CheckInDate", obj.CheckInDate));
                lstParams.Add(new SqlParameter("@PlannedCheckOutDate", obj.PlannedCheckOutDate));
                lstParams.Add(new SqlParameter("@CheckOutDate", obj.CheckOutDate));
                lstParams.Add(new SqlParameter("@Status", obj.Status));
                lstParams.Add(new SqlParameter("@PaidAmount", obj.PaidAmount));
                lstParams.Add(new SqlParameter("@CustomerID", obj.CustomerID));
                lstParams.Add(new SqlParameter("@ApproverID", obj.ApproverID));
                lstParams.Add(new SqlParameter("@ReceiverID", obj.ReceiverID));
                lstParams.Add(new SqlParameter("@StaffRemarks", obj.StaffRemarks));
                lstParams.Add(new SqlParameter("@CustomerRemarks", obj.CustomerRemarks));
                lstParams.Add(new SqlParameter("@RoomRate", obj.RoomRate));
                lstParams.Add(new SqlParameter("@PaymentMode", obj.PaymentMode));
                lstParams.Add(new SqlParameter("@ChequeNo", obj.ChequeNo));
                lstParams.Add(new SqlParameter("@BankName", obj.BankName));
                lstParams.Add(new SqlParameter("@OnlineBookingID", obj.OnlineBookingID));

                DataTable dt = DBUtility.Select(fetchquery, lstParams);

                return new Booking(Convert.ToInt32(dt.Rows[0]["BookingID"]),
                Convert.ToInt32(dt.Rows[0]["RoomID"]),
                Convert.ToInt32(dt.Rows[0]["NoOfPersons"]),
                Convert.ToDateTime(dt.Rows[0]["CheckInDate"]),
                Convert.ToDateTime(dt.Rows[0]["PlannedCheckoutDate"]),
                Convert.ToDateTime(dt.Rows[0]["CheckOutDate"]),
                dt.Rows[0]["Status"].ToString(),
                Convert.ToDouble(dt.Rows[0]["PaidAmount"]),
                Convert.ToInt32(dt.Rows[0]["CustomerID"]),
                Convert.ToInt32(dt.Rows[0]["ApproverID"]),
                Convert.ToInt32(dt.Rows[0]["ReceiverID"]),
                dt.Rows[0]["StaffRemarks"].ToString(),
                dt.Rows[0]["CustomerRemarks"].ToString(),
                Convert.ToDouble(dt.Rows[0]["RoomRate"]),
                dt.Rows[0]["PaymentMode"].ToString(),
                Convert.ToInt32(dt.Rows[0]["ChequeNo"]),
                dt.Rows[0]["BankName"].ToString(),
                Convert.ToInt32(dt.Rows[0]["OnlineBookingID"]));
            }
            else
            {
                return null;
            }
        }

        public int update(Booking obj)
        {
            String query = "update Booking set RoomID=@RoomID, NoOfPersons=@NumberOfPersons, CheckInDate=@CheckInDate, PlannedCheckOutDate=@PlannedCheckOutDate, CheckOutDate=@CheckOutDate, Status=@Status, PaidAmount=@PaidAmount, CustomerID=@CustomerID, ApproverID=@ApproverID, ReceiverID=@ReceiverID, StaffRemarks=@StaffRemarks, CustomerRemarks=@CustomerRemarks, RoomRate=@RoomRate, PaymentMode=@PaymentMode, ChequeNo=@ChequeNo, BankName=@BankName, OnlineBookingID=@OnlineBookingID where BookingID=@BookingID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@BookingID", obj.BookingID));
            lstParams.Add(new SqlParameter("@RoomID", obj.RoomID));
            lstParams.Add(new SqlParameter("@NumberOfPersons", obj.NumberOfPersons));
            lstParams.Add(new SqlParameter("@CheckInDate", obj.CheckInDate));
            lstParams.Add(new SqlParameter("@PlannedCheckOutDate", obj.PlannedCheckOutDate));
            lstParams.Add(new SqlParameter("@CheckOutDate", obj.CheckOutDate));
            lstParams.Add(new SqlParameter("@Status", obj.Status));
            lstParams.Add(new SqlParameter("@PaidAmount", obj.PaidAmount));
            lstParams.Add(new SqlParameter("@CustomerID", obj.CustomerID));
            lstParams.Add(new SqlParameter("@ApproverID", obj.ApproverID));
            lstParams.Add(new SqlParameter("@ReceiverID", obj.ReceiverID));
            lstParams.Add(new SqlParameter("@StaffRemarks", obj.StaffRemarks));
            lstParams.Add(new SqlParameter("@CustomerRemarks", obj.CustomerRemarks));
            lstParams.Add(new SqlParameter("@RoomRate", obj.RoomRate));
            lstParams.Add(new SqlParameter("@PaymentMode", obj.PaymentMode));
            lstParams.Add(new SqlParameter("@ChequeNo", obj.ChequeNo));
            lstParams.Add(new SqlParameter("@BankName", obj.BankName));
            lstParams.Add(new SqlParameter("@OnlineBookingID", obj.OnlineBookingID));

            return DBUtility.Modify(query, lstParams);
        }

        public int delete(int id)
        {
            String query = "delete from Booking where BookingID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);  
        }

        public Booking selectById(int id)
        {
            String query = "select * from Booking where BookingID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new Booking(Convert.ToInt32(dt.Rows[0]["BookingID"]),
                Convert.ToInt32(dt.Rows[0]["RoomID"]),
                Convert.ToInt32(dt.Rows[0]["NoOfPersons"]),
                Convert.ToDateTime(dt.Rows[0]["CheckInDate"]),
                Convert.ToDateTime(dt.Rows[0]["PlannedCheckoutDate"]),
                Convert.ToDateTime(dt.Rows[0]["CheckOutDate"]),
                dt.Rows[0]["Status"].ToString(),
                Convert.ToDouble(dt.Rows[0]["PaidAmount"]),
                Convert.ToInt32(dt.Rows[0]["CustomerID"]),
                Convert.ToInt32(dt.Rows[0]["ApproverID"]),
                Convert.ToInt32(dt.Rows[0]["ReceiverID"]),
                dt.Rows[0]["StaffRemarks"].ToString(),
                dt.Rows[0]["CustomerRemarks"].ToString(),
                Convert.ToDouble(dt.Rows[0]["RoomRate"]),
                dt.Rows[0]["PaymentMode"].ToString(),
                Convert.ToInt32(dt.Rows[0]["ChequeNo"]),
                dt.Rows[0]["BankName"].ToString(),
                Convert.ToInt32(dt.Rows[0]["OnlineBookingID"]));
            }
            else
            {
                return null;
            }
            
        }

        public DataTable selectAll()
        {
            String query = "select * from Booking";

            return DBUtility.Select(query, new List<SqlParameter>());
        }
    }
}
