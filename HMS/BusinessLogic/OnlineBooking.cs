using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class OnlineBooking : IModel
    {
        public int OnlineBookingID { get; set; }
        public int RoomTypeID { get; set; }
        public int NumberOfPersons { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime PlannedCheckOutDate { get; set; }
        public string Status { get; set; }
        public int CustomerID { get; set; }
        public int ConverterID { get; set; }
        public double WebsiteRate { get; set; }
        public int AccountID { get; set; }

        public OnlineBooking()
        {

        }

        public OnlineBooking(int OnlineBookingID, int RoomTypeID, int NumberOfPersons, DateTime CheckInDate, DateTime PlannedCheckOutDate, String Status, int CustomerID, int ConverterID, double WebsiteRate, int AccountID)
        {
            this.OnlineBookingID = OnlineBookingID;
            this.RoomTypeID = RoomTypeID;
            this.NumberOfPersons = NumberOfPersons;
            this.CheckInDate = CheckInDate;
            this.PlannedCheckOutDate = PlannedCheckOutDate;
            this.Status = Status;
            this.CustomerID = CustomerID;
            this.ConverterID = ConverterID;
            this.WebsiteRate = WebsiteRate;
            this.AccountID = AccountID;
        }
    }
}
