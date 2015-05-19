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
    class BillLogic : ILogic<Bill>
    {
        public DataTable search(String searchsttring, int id)
        {
            return null;
        }

        public DataTable search(String CustomerName)
        {
            String query;
            List<SqlParameter> lstParams = new List<SqlParameter>();
            
            query = "select Bill.*, Customer.Name from Bill, Customer where Customer.Name like @CustomerName+'%' and Customer.CustomerID=Bill.CustomerID order by Bill.BillID";
            
            lstParams.Add(new SqlParameter("@CustomerName", CustomerName));
            return DBUtility.Select(query, lstParams);
        }

        public Bill create(Bill obj)
        {
            String insertQuery = "insert into Bill values(@CustomerID, @RoomID, @RoomCharges, @ServiceCharges, @TotalAmount, @DiscountPercentage, @PayableAmount, @PaymentMode, @PaymentDetails)";

            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@CustomerID", obj.CustomerID));
            lstParams.Add(new SqlParameter("@RoomID", obj.RoomID));
            lstParams.Add(new SqlParameter("@RoomCharges", obj.RoomCharges));
            lstParams.Add(new SqlParameter("@ServiceCharges", obj.ServiceCharges));
            lstParams.Add(new SqlParameter("@TotalAmount", obj.TotalAmount));
            lstParams.Add(new SqlParameter("@Discount", obj.DiscountPercentage));
            lstParams.Add(new SqlParameter("@PayableAmount", obj.PayableAmount));
            lstParams.Add(new SqlParameter("@PaymentMode", obj.PaymentMode));
            lstParams.Add(new SqlParameter("@PaymentDetails", obj.PaymentDetails));

            int res = DBUtility.Modify(insertQuery, lstParams);

            if (res == 1)
            {
                String selectQuery = "select * from Bill where CustomerID=@CustomerID, RoomID=@RoomID, RoomCharges=@RoomCharges, ServiceCharges=@ServiceCharge, TotalAmount=@TotalAmount, DiscountPercentage=@DiscountPercentage, PayableAmount=@PayableAmount, PaymentMode=@PaymentMode, PaymentDetails=@PaymentDetails";

                List<SqlParameter> lstParams1 = new List<SqlParameter>();

                lstParams1.Add(new SqlParameter("@CustomerID", obj.CustomerID));
                lstParams1.Add(new SqlParameter("@RoomID", obj.RoomID));
                lstParams1.Add(new SqlParameter("@RoomCharges", obj.RoomCharges));
                lstParams1.Add(new SqlParameter("@ServiceCharges", obj.ServiceCharges));
                lstParams1.Add(new SqlParameter("@TotalAmount", obj.TotalAmount));
                lstParams1.Add(new SqlParameter("@Discount", obj.DiscountPercentage));
                lstParams1.Add(new SqlParameter("@PayableAmount", obj.PayableAmount));
                lstParams1.Add(new SqlParameter("@PaymentMode", obj.PaymentMode));
                lstParams1.Add(new SqlParameter("@PaymentDetails", obj.PaymentDetails));

                DataTable dt = DBUtility.Select(selectQuery, lstParams1);

                if (dt.Rows.Count == 1)
                {
                    return new Bill(Convert.ToInt32(dt.Rows[0]["BillID"]),
                        Convert.ToInt32(dt.Rows[0]["CusomerID"]),
                        Convert.ToInt32(dt.Rows[0]["RoomID"]),
                        Convert.ToDouble(dt.Rows[0]["RoomCharges"]),
                        Convert.ToDouble(dt.Rows[0]["ServiceCharges"]),
                        Convert.ToDouble(dt.Rows[0]["TotalAmount"]),
                        Convert.ToDouble(dt.Rows[0]["DiscountPercentage"]),
                        Convert.ToDouble(dt.Rows[0]["PayableAmount"]),
                        dt.Rows[0]["PaymentMode"].ToString(),
                        dt.Rows[0]["PaymentDetails"].ToString());
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public int update(Bill obj)
        {
            String query = "update Bill set @CustomerID, RoomID=@RoomID, RoomCharges=@RoomCharges, ServiceCharges=@ServiceCharge, TotalAmount=@TotalAmount, DiscountPercentage=@DiscountPercentage, PayableAmount=@PayableAmount, PaymentMode=@PaymentMode, PaymentDetails=@PaymentDetails";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@CustomerID", obj.CustomerID));
            lstParams.Add(new SqlParameter("@RoomID", obj.RoomID));
            lstParams.Add(new SqlParameter("@RoomCharges", obj.RoomCharges));
            lstParams.Add(new SqlParameter("@ServiceCharges", obj.ServiceCharges));
            lstParams.Add(new SqlParameter("@TotalAmount", obj.TotalAmount));
            lstParams.Add(new SqlParameter("@Discount", obj.DiscountPercentage));
            lstParams.Add(new SqlParameter("@PayableAmount", obj.PayableAmount));
            lstParams.Add(new SqlParameter("@PaymentMode", obj.PaymentMode));
            lstParams.Add(new SqlParameter("@PaymentDetails", obj.PaymentDetails));

            return DBUtility.Modify(query, lstParams);
        }

        public int delete(int BillID)
        {
            String query = "delete from Bill where BillID=@BillID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", BillID));

            return DBUtility.Modify(query, lstParams);
        }

        public Bill selectById(int BillID)
        {
            String query = "select * from Bill where BillID=@BillID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@BillID", BillID));
            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new Bill(Convert.ToInt32(dt.Rows[0]["BillID"]),
                    Convert.ToInt32(dt.Rows[0]["CusomerID"]),
                    Convert.ToInt32(dt.Rows[0]["RoomID"]),
                    Convert.ToDouble(dt.Rows[0]["RoomCharges"]),
                    Convert.ToDouble(dt.Rows[0]["ServiceCharges"]),
                    Convert.ToDouble(dt.Rows[0]["TotalAmount"]),
                    Convert.ToDouble(dt.Rows[0]["DiscountPercentage"]),
                    Convert.ToDouble(dt.Rows[0]["PayableAmount"]),
                    dt.Rows[0]["PaymentMode"].ToString(),
                    dt.Rows[0]["PaymentDetails"].ToString());
            }
            else
            {
                return null;
            }
        }

        public DataTable selectAll()
        {
            String query = "select * from Bill";

            return DBUtility.Select(query, new List<SqlParameter>());
        }
    }
}
