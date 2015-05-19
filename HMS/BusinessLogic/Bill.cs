using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    class Bill : IModel
    {
        public int BillID;
        public int CustomerID;
        public int RoomID;
        public double RoomCharges;
        public double ServiceCharges;
        public double TotalAmount;
        public double DiscountPercentage;
        public double PayableAmount;
        public string PaymentMode;
        public string PaymentDetails;

        public Bill()
        {

        }

        public Bill(int BillID, int CustomerID, int RoomID, double RoomCharges, double ServiceCharges, double TotalAmount, double DiscountPercentage, double PayableAmount, string PaymentMode, string PaymentDetails)
        {
            this.BillID = BillID;
            this.CustomerID = CustomerID;
            this.RoomID = RoomID;
            this.RoomCharges = RoomCharges;
            this.ServiceCharges = ServiceCharges;
            this.TotalAmount = TotalAmount;
            this.DiscountPercentage = DiscountPercentage;
            this.PayableAmount = PayableAmount;
            this.PaymentMode = PaymentMode;
            this.PaymentDetails = PaymentDetails;
        }
    }
}