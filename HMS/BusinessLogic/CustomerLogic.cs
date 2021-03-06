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
    public class CustomerLogic : ILogic<Customer>
    {
        public DataTable search(string searchstring, int ID)
        {
            String query = "select * from Customer where Name like @Name+'%' and AccountID=@ID order by Name";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", searchstring));
            lstParams.Add(new SqlParameter("@ID", ID));

            return DBUtility.Select(query, lstParams);
        }

        public Customer create(Customer obj)
        {
            String checkquery = "select * from Customer where Name=@Name and Email=@Email and Phone=@Phone and AccountID=@AccountID";
            List<SqlParameter> lstParamsc = new List<SqlParameter>();

            lstParamsc.Add(new SqlParameter("@CreateDate", obj.CreateDate));
            lstParamsc.Add(new SqlParameter("@Name", obj.Name));
            lstParamsc.Add(new SqlParameter("@Email", obj.Email));
            lstParamsc.Add(new SqlParameter("@Phone", obj.Phone));
            lstParamsc.Add(new SqlParameter("@AccountID", obj.AccountID));

            DataTable records = DBUtility.Select(checkquery, lstParamsc);

            if (records.Rows.Count == 1)
            {
                return new Customer(Convert.ToInt32(records.Rows[0]["CustomerID"]),
                        Convert.ToDateTime(records.Rows[0]["CreateDate"]),
                        records.Rows[0]["Name"].ToString(),
                        records.Rows[0]["Email"].ToString(),
                        records.Rows[0]["Phone"].ToString(),
                        records.Rows[0]["Username"].ToString(),
                        records.Rows[0]["Password"].ToString(),
                        Convert.ToBoolean(records.Rows[0]["IsActive"]),
                        Convert.ToInt32(records.Rows[0]["AccountID"]));
            }
            else
            {
                String query = "insert into Customer values(@CreateDate, @Name, @Email, @Phone, @Username, @Password, @IsActive, @AccountID);";
                List<SqlParameter> lstParams = new List<SqlParameter>();

                lstParams.Add(new SqlParameter("@CreateDate", obj.CreateDate));
                lstParams.Add(new SqlParameter("@Name", obj.Name));
                lstParams.Add(new SqlParameter("@Email", obj.Email));
                lstParams.Add(new SqlParameter("@Phone", obj.Phone));
                lstParams.Add(new SqlParameter("@Username", obj.Username));
                lstParams.Add(new SqlParameter("@Password", obj.Password));
                lstParams.Add(new SqlParameter("@IsActive", obj.IsActive));
                lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));

                int res = DBUtility.Modify(query, lstParams);

                if (res == 1)
                {
                    String fetchquery = "select * from Customer where CreateDate=@CreateDate and Name=@Name and Email=@Email and Phone=@Phone and Username=@Username and Password=@Password and IsActive=@IsActive and AccountID=@AccountID";
                    List<SqlParameter> lstParams1 = new List<SqlParameter>();

                    lstParams1.Add(new SqlParameter("@CreateDate", obj.CreateDate));
                    lstParams1.Add(new SqlParameter("@Name", obj.Name));
                    lstParams1.Add(new SqlParameter("@Email", obj.Email));
                    lstParams1.Add(new SqlParameter("@Phone", obj.Phone));
                    lstParams1.Add(new SqlParameter("@Username", obj.Username));
                    lstParams1.Add(new SqlParameter("@Password", obj.Password));
                    lstParams1.Add(new SqlParameter("@IsActive", obj.IsActive));
                    lstParams1.Add(new SqlParameter("@AccountID", obj.AccountID));
                    DataTable dt = DBUtility.Select(fetchquery, lstParams1);

                    if (dt.Rows.Count == 1)
                    {
                        return new Customer(Convert.ToInt32(dt.Rows[0]["CustomerID"]),
                            Convert.ToDateTime(dt.Rows[0]["CreateDate"]),
                            dt.Rows[0]["Name"].ToString(),
                            dt.Rows[0]["Email"].ToString(),
                            dt.Rows[0]["Phone"].ToString(),
                            dt.Rows[0]["Username"].ToString(),
                            dt.Rows[0]["Password"].ToString(),
                            Convert.ToBoolean(dt.Rows[0]["IsActive"]),
                            Convert.ToInt32(dt.Rows[0]["AccountID"]));
                    }
                    else
                    {
                        return null;
                    }
                }
                return null;
            }                                  
        }

        public int update(Customer obj)
        {
            String query = "update Customer set CreateDate=@CreateDate, Name=@Name, Email=@Email, Phone=@Phone, Password=@Password, IsActive=@IsActive, AccountID=@AccountID where CustomerID=@CustomerID;";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@CreateDate", obj.CreateDate));
            lstParams.Add(new SqlParameter("@Name", obj.Name));
            lstParams.Add(new SqlParameter("@Email", obj.Email));
            lstParams.Add(new SqlParameter("@Phone", obj.Phone));
            lstParams.Add(new SqlParameter("@Username", obj.Username));
            lstParams.Add(new SqlParameter("@Password", obj.Password));
            lstParams.Add(new SqlParameter("@IsActive", obj.IsActive));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));
            lstParams.Add(new SqlParameter("@CustomerID", obj.CustomerID));
            
            return DBUtility.Modify(query, lstParams); 
        }

        public int delete(int id)
        {
            String query = "delete from Customer where CustomerID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);  
        }

        public Customer selectById(int id)
        {
            String query = "select * from Customer where CustomerID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));

            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new Customer(Convert.ToInt32(dt.Rows[0]["CustomerID"]),
                    Convert.ToDateTime(dt.Rows[0]["CreateDate"]),
                    dt.Rows[0]["Name"].ToString(),
                    dt.Rows[0]["Email"].ToString(),
                    dt.Rows[0]["Phone"].ToString(),
                    dt.Rows[0]["Username"].ToString(),
                    dt.Rows[0]["Password"].ToString(),
                    Convert.ToBoolean(dt.Rows[0]["IsActive"]),
                    Convert.ToInt32(dt.Rows[0]["AccountID"]));
            }
            else
            {
                return null;
            }
        }

        public DataTable selectAll()
        {
            String query = "select * from Customer";

            return DBUtility.Select(query, new List<SqlParameter>());
        }

        public DataTable selectAll(int AccountID)
        {
            String query = "select * from Customer where AccountID=@AccountID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@AccountID", AccountID));

            return DBUtility.Select(query, lstParams);
        }

        public Customer login(String username, String password)
        {
            String query = "select * from Customer where Username=@Username and Password=@Password";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Username", username));
            lstParams.Add(new SqlParameter("@Password", password));

            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new Customer(Convert.ToInt32(dt.Rows[0]["CustomerID"]),
                    Convert.ToDateTime(dt.Rows[0]["CreateDate"]),
                    dt.Rows[0]["Name"].ToString(),
                    dt.Rows[0]["Email"].ToString(),
                    dt.Rows[0]["Phone"].ToString(),
                    dt.Rows[0]["Username"].ToString(),
                    dt.Rows[0]["Password"].ToString(),
                    Convert.ToBoolean(dt.Rows[0]["IsActive"]),
                    Convert.ToInt32(dt.Rows[0]["AccountID"]));
            }
            else
            {
                return null;
            }
        }

        public Booking getCurrentBooking(int CustomerID)
        {
            String query = "select * from Booking where CustomerID = @CustomerID order by CheckInDate";
            
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@CustomerID", CustomerID));

            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count != 0)
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

        public Booking hasBookingNow(int CustomerID, int AccountID)
        {
            string query = "select * from Booking, Customer where Booking.CustomerID = Customer.CustomerID and Booking.CustomerID=@CustomerID and Customer.AccountID=@AccountID and @CurrentDate BETWEEN Booking.CheckInDate AND Booking.CheckOutDate";
            
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@CustomerID", CustomerID));
            lstParams.Add(new SqlParameter("@AccountID", AccountID));
            lstParams.Add(new SqlParameter("@CurrentDate", DateTime.Now));

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

        public Customer getUserByEmail(string Email)
        {
            String query = "select * from Customer where Email=@Email";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Email", Email));

            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new Customer(Convert.ToInt32(dt.Rows[0]["CustomerID"]),
                Convert.ToDateTime(dt.Rows[0]["CreateDate"]),
                dt.Rows[0]["Name"].ToString(),
                dt.Rows[0]["Email"].ToString(),
                dt.Rows[0]["Phone"].ToString(),
                dt.Rows[0]["Username"].ToString(),
                dt.Rows[0]["Password"].ToString(),
                Convert.ToBoolean(dt.Rows[0]["IsActive"]),
                Convert.ToInt32(dt.Rows[0]["AccountID"]));
            }
            else
            {
                return null;
            }
        }
    }
}
