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
    public class ServiceRequestLogic : ILogic<ServiceRequest>
    {
        public System.Data.DataTable search(string searchstring, int ID)
        {
            throw new NotImplementedException();
        }

        public ServiceRequest create(ServiceRequest obj)
        {
            String query = "insert into ServiceRequest values(@ServiceID, @BookingID, @CreatedDate, @RequestedDate, @Status, @CustomerRemarks, @StaffRemarks, @AssignedID, @Unit) ";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@ServiceID", obj.ServiceID));
            lstParams.Add(new SqlParameter("@BookingID", obj.BookingID));
            lstParams.Add(new SqlParameter("@CreatedDate", obj.CreatedDate));
            lstParams.Add(new SqlParameter("@RequestedDate", obj.RequestedDate));
            lstParams.Add(new SqlParameter("@Status", obj.Status));
            lstParams.Add(new SqlParameter("@CustomerRemarks", obj.CustomerRemarks));
            lstParams.Add(new SqlParameter("@StaffRemarks", obj.StaffRemarks));
            lstParams.Add(new SqlParameter("@AssignedID", obj.AssignedID));
            lstParams.Add(new SqlParameter("@Unit", obj.Unit));

            int res = DBUtility.Modify(query, lstParams);

            if (res == 1)
            {
                String selectQuery = "select * from ServiceRequest where ServiceID=@ServiceID and BookingID=@BookingID and CreatedDate=@CreatedDate and RequestedDate=@RequestedDate and Status=@Status and CustomerRemarks=@CustomerRemarks and StaffRemarks=@StaffRemarks and AssignedID=@AssignedID and Unit=@Unit";

                List<SqlParameter> lstParams1 = new List<SqlParameter>();

                lstParams1.Add(new SqlParameter("@ServiceID", obj.ServiceID));
                lstParams1.Add(new SqlParameter("@BookingID", obj.BookingID));
                lstParams1.Add(new SqlParameter("@CreatedDate", obj.CreatedDate));
                lstParams1.Add(new SqlParameter("@RequestedDate", obj.RequestedDate));
                lstParams1.Add(new SqlParameter("@Status", obj.Status));
                lstParams1.Add(new SqlParameter("@CustomerRemarks", obj.CustomerRemarks));
                lstParams1.Add(new SqlParameter("@StaffRemarks", obj.StaffRemarks));
                lstParams1.Add(new SqlParameter("@AssignedID", obj.AssignedID));
                lstParams1.Add(new SqlParameter("@Unit", obj.Unit));

                DataTable dt = DBUtility.Select(selectQuery, lstParams1);

                if (dt.Rows.Count == 1)
                {
                    return new ServiceRequest(Convert.ToInt32(dt.Rows[0]["ServiceRequestID"]),
                        Convert.ToInt32(dt.Rows[0]["ServiceID"]),
                        Convert.ToInt32(dt.Rows[0]["BookingID"]),
                        Convert.ToDateTime(dt.Rows[0]["CreatedDate"]),
                        Convert.ToDateTime(dt.Rows[0]["RequestedDate"]),
                        dt.Rows[0]["Status"].ToString(),
                        dt.Rows[0]["CustomerRemarks"].ToString(),
                        dt.Rows[0]["StaffRemarks"].ToString(),
                        Convert.ToInt32(dt.Rows[0]["AssignedID"]),
                        Convert.ToInt32(dt.Rows[0]["Unit"]));
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }

        public int update(ServiceRequest obj)
        {
            String query = "update ServiceRequest set ServiceID=@ServiceID, BookingID=@BookingID, CreatedDate=@CreatedDate, RequestedDate=@RequestedDate, Status=@Status, CustomerRemarks=@CustomerRemarks, StaffRemarks=@StaffRemarks, AssignedID=@AssignedID, Unit=@Unit where ServiceRequestID=@ServiceRequestID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@ServiceRequestID", obj.ServiceRequestID));
            lstParams.Add(new SqlParameter("@ServiceID", obj.ServiceID));
            lstParams.Add(new SqlParameter("@BookingID", obj.BookingID));
            lstParams.Add(new SqlParameter("@CreatedDate", obj.CreatedDate));
            lstParams.Add(new SqlParameter("@RequestedDate", obj.RequestedDate));
            lstParams.Add(new SqlParameter("@Status", obj.Status));
            lstParams.Add(new SqlParameter("@CustomerRemarks", obj.CustomerRemarks));
            lstParams.Add(new SqlParameter("@StaffRemarks", obj.StaffRemarks));
            lstParams.Add(new SqlParameter("@AssignedID", obj.AssignedID));
            lstParams.Add(new SqlParameter("@Unit", obj.Unit));

            return DBUtility.Modify(query, lstParams);
        }

        public int delete(int id)
        {
            String query = "delete from ServiceRequest where ServiceRequestID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);
        }

        public ServiceRequest selectById(int id)
        {
            String query = "select * from ServiceRequest where ServiceRequestID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new ServiceRequest(Convert.ToInt32(dt.Rows[0]["ServiceRequestID"]),
                Convert.ToInt32(dt.Rows[0]["ServiceID"]),
                Convert.ToInt32(dt.Rows[0]["BookingID"]),
                Convert.ToDateTime(dt.Rows[0]["CreatedDate"]),
                Convert.ToDateTime(dt.Rows[0]["RequestedDate"]),
                dt.Rows[0]["Status"].ToString(),
                dt.Rows[0]["CustomerRemarks"].ToString(),
                dt.Rows[0]["StaffRemarks"].ToString(),
                Convert.ToInt32(dt.Rows[0]["AssignedID"]),
                Convert.ToInt32(dt.Rows[0]["Unit"]));
            }
            else
            {
                return null;
            }
        }

        public DataTable selectAll()
        {
            String query = "select * from ServiceRequest";

            return DBUtility.Select(query, new List<SqlParameter>());
        }

        public DataTable getPendingRequests(int AccountID)
        {
            String query = "select ServiceRequest.*, Service.Name as ServiceName, Room.RoomNumber as RoomNumber, Room.RoomID from ServiceRequest, Service, ServiceType, Booking, Room where ServiceType.AccountID=@AccountID and ServiceRequest.Status='Pending' and ServiceRequest.ServiceID = Service.ServiceID and Service.ServiceTypeID = ServiceType.ServiceTypeID and ServiceRequest.BookingID = Booking.BookingID and Booking.RoomID = Room.RoomID";

            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@AccountID", AccountID));
            return DBUtility.Select(query, lstParams);
        }

        public DataTable getPendingRequestsOfStaff(Staff serviceProvider)
        {
            String query = "select * from ServiceRequest where AssignedID=@StaffID and Status='Pending'";

            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@StaffID", serviceProvider.StaffID));

            return DBUtility.Select(query, lstParams);
        }

        public DataTable getAssignedRequestsOfStaff(Staff serviceProvider)
        {
            String query = "select ServiceRequest.*, Service.Name as ServiceName, Room.RoomNumber as RoomNumber, Room.RoomID from ServiceRequest, Service, ServiceType, Booking, Room where ServiceRequest.AssignedID=@StaffID and ServiceRequest.Status='Assigned' and ServiceRequest.ServiceID = Service.ServiceID and Service.ServiceTypeID = ServiceType.ServiceTypeID and ServiceRequest.BookingID = Booking.BookingID and Booking.RoomID = Room.RoomID";

            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@StaffID", serviceProvider.StaffID));

            return DBUtility.Select(query, lstParams);
        }
    }
}
