using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class OnlineBooking : IModel
    {
        public int OnlineBookingID;
        public int RoomTypeID;
        public int NumberOfPersons;
        public DateTime CheckInDate;
        public DateTime PlannedCheckOutDate;
        public String Status;
        public int CustomerID;
        public int ConverterID;
        public String StaffRemarks;
        public String CustomerRemarks;
        public double WebsiteRate;

        public OnlineBooking()
        {

        }

        public OnlineBooking(int OnlineBookingID, int RoomTypeID, int NumberOfPersons, DateTime CheckInDate, DateTime PlannedCheckOutDate, String Status, int CustomerID, int ConverterID, String StaffRemarks, String CustomerRemarks, double WebsiteRate)
        {
            this.OnlineBookingID = OnlineBookingID;
            this.RoomTypeID = RoomTypeID;
            this.NumberOfPersons = NumberOfPersons;
            this.CheckInDate = CheckInDate;
            this.PlannedCheckOutDate = PlannedCheckOutDate;
            this.Status = Status;
            this.CustomerID = CustomerID;
            this.ConverterID = ConverterID;
            this.StaffRemarks = StaffRemarks;
            this.CustomerRemarks = CustomerRemarks;
            this.WebsiteRate = WebsiteRate;
        }
    }
}
