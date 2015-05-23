using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Bill : IModel
    {
        public int BillID;
        public int BookingID;
        public double RoomCharges;
        public double ServiceCharges;
        public double TotalAmount;
        public double DiscountedAmount;
        public double PayableAmount;
        public string PaymentMode;
        public string PaymentDetails;

        public Bill()
        {

        }

        public Bill(int BillID, int BookingID, double RoomCharges, double ServiceCharges, double TotalAmount, double DiscountedAmount, double PayableAmount, string PaymentMode, string PaymentDetails)
        {
            this.BillID = BillID;
            this.BookingID = BookingID;
            this.RoomCharges = RoomCharges;
            this.ServiceCharges = ServiceCharges;
            this.TotalAmount = TotalAmount;
            this.DiscountedAmount = DiscountedAmount;
            this.PayableAmount = PayableAmount;
            this.PaymentMode = PaymentMode;
            this.PaymentDetails = PaymentDetails;
        }
    }
}