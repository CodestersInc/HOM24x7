using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Booking : IModel
    {
        public int BookingID;
        public int RoomID;
        public int NumberOfPersons;
        public DateTime CheckInDate;
        public DateTime PlannedCheckOutDate;
        public DateTime CheckOutDate;
        public String Status;                  //To be chenged when needed
        public double PaidAmount;
        public int CustomerID;
        public int ApproverID;
        public int ReceiverID;
        public String StaffRemarks;            //can also be changed to "List<String> StaffRemarks;"
        public String CustomerRemarks;
        public double RoomRate;
        public String PaymentMode;
        public int ChequeNo;
        public String BankName;
        public int OnlineBookingID;

        public Booking()
        {

        }

        public Booking(int BookingID, int RoomID, int NumberOfPersons, DateTime CheckInDate, DateTime PlannedCheckOutDate, DateTime CheckOutDate, String Status, double PaidAmount, int CustomerID, int ApproverID, int ReceiverID, String StaffRemarks, String CustomerRemarks, double RoomRate, String PaymentMode, int ChequeNo, String BankName, int OnlineBookingID)
        {
            this.BookingID = OnlineBookingID;
            this.RoomID = RoomID;
            this.NumberOfPersons = NumberOfPersons;
            this.CheckInDate = CheckInDate;
            this.PlannedCheckOutDate = PlannedCheckOutDate;
            this.CheckOutDate = CheckOutDate;
            this.Status = Status;
            this.PaidAmount = PaidAmount;
            this.CustomerID = CustomerID;
            this.ApproverID = ApproverID;
            this.ReceiverID = ReceiverID;
            this.StaffRemarks = StaffRemarks;
            this.CustomerRemarks = CustomerRemarks;
            this.RoomRate = RoomRate;
            this.PaymentMode = PaymentMode;
            this.ChequeNo = ChequeNo;
            this.BankName = BankName;
            this.OnlineBookingID = OnlineBookingID;
        }
    }
}
