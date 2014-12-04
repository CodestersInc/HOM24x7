using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ServiceRequest : IModel
    {
        public int ServiceRequestID;
        public int ServiceID;
        public int BookingID;
        public DateTime CreatedDate;
        public DateTime RequestedDate;
        /* 
         * There should be a field of completed Date and time 
         */
        public String Status;
        public String CustomerRemarks;
        public String StaffRemarks;
        public int AssignedID;
        public int Unit;

        public ServiceRequest()
        {

        }

        public ServiceRequest(int ServiceRequestID, int ServiceID, int BookingID, DateTime CreatedDate, DateTime RequestedDate, String Status, String CustomerRemarks, String StaffRemarks, int AssignedID, int Unit)
        {
            this.ServiceRequestID = ServiceRequestID;
            this.ServiceID = ServiceID;
            this.BookingID = BookingID;
            this.CreatedDate = CreatedDate;
            this.RequestedDate = RequestedDate;
            this.Status = Status;
            this.CustomerRemarks = CustomerRemarks;
            this.StaffRemarks = StaffRemarks;
            this.AssignedID = AssignedID;
            this.Unit = Unit;
        }
    }
}
