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
    public class PaySlipLogic : ILogic<PaySlip>
    {
        public System.Data.DataTable search(string searchstring, int ID)
        {
            throw new NotImplementedException();
        }

        public DataTable search(DateTime FromDate, DateTime ToDate, int StaffID, String flag)
        {
            if (flag == "Staff")
            {
                String query = "select Department.Name as 'DepartmentName', PaySlip.*, Staff.StaffCode, Staff.Name from Department, PaySlip, Staff where PaySlip.StaffID=Staff.StaffID and Staff.DepartmentID = Department.DepartmentID and GenerateDate BETWEEN @FromDate AND @ToDate and PaySlip.StaffID=@StaffID";

                List<SqlParameter> lstParams = new List<SqlParameter>();

                lstParams.Add(new SqlParameter("@FromDate", FromDate));
                lstParams.Add(new SqlParameter("@ToDate", ToDate));
                lstParams.Add(new SqlParameter("@StaffID", StaffID));

                return DBUtility.Select(query, lstParams);
            }
            else
            {
                return null;
            }
        }

        //Search Department Wise
        public DataTable search(DateTime FromDate, DateTime ToDate, int DepartmentID, int AccountID)
        {
            if (DepartmentID == 0)
            {
                return search(FromDate, ToDate, AccountID);
            }
            String query = "select Department.Name as 'DepartmentName', PaySlip.*, Staff.StaffCode, Staff.Name from Department, PaySlip, Staff where Staff.StaffID=PaySlip.StaffID and Staff.DepartmentID = Department.DepartmentID and Department.DepartmentID=@DepartmentID and PaySlip.AccountID=@AccountID and GenerateDate BETWEEN @FromDate AND @ToDate";
            
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@FromDate", FromDate));
            lstParams.Add(new SqlParameter("@ToDate", ToDate));
            lstParams.Add(new SqlParameter("@DepartmentID", DepartmentID));
            lstParams.Add(new SqlParameter("@AccountID", AccountID));

            return DBUtility.Select(query, lstParams);
        }

        //Global Search
        public DataTable search(DateTime FromDate, DateTime ToDate, int AccountID)
        {
            String query = "select Department.Name as 'DepartmentName', PaySlip.*, Staff.StaffCode, Staff.Name from Department, PaySlip, Staff where Staff.StaffID=PaySlip.StaffID and Staff.DepartmentID = Department.DepartmentID and PaySlip.AccountID=@AccountID and GenerateDate BETWEEN @FromDate AND @ToDate";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@FromDate", FromDate));
            lstParams.Add(new SqlParameter("@ToDate", ToDate));
            lstParams.Add(new SqlParameter("@AccountID", AccountID));

            return DBUtility.Select(query, lstParams);
        }

        public PaySlip create(PaySlip obj)
        {
            String query = "insert into PaySlip values(@StaffID, @BasicSalary, @ConvAllowance, @Bonus, @PF, @ProfessionalTax, @IncomeTax, @Netpay, @FromDate, @ToDate, @DaysPayable, @GenerateDate, @PayDate, @ApproverID, @AccountID)";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@StaffID", obj.StaffID));
            lstParams.Add(new SqlParameter("@BasicSalary", obj.BasicSalary));
            lstParams.Add(new SqlParameter("@ConvAllowance", obj.ConvAllowance));
            lstParams.Add(new SqlParameter("@Bonus", obj.Bonus));
            lstParams.Add(new SqlParameter("@PF", obj.PF));
            lstParams.Add(new SqlParameter("@ProfessionalTax", obj.ProfessionalTax));
            lstParams.Add(new SqlParameter("@IncomeTax", obj.IncomeTax));
            lstParams.Add(new SqlParameter("@NetPay", obj.NetPay));
            lstParams.Add(new SqlParameter("@FromDate", obj.FromDate));
            lstParams.Add(new SqlParameter("@ToDate", obj.ToDate));
            lstParams.Add(new SqlParameter("@DaysPayable", obj.DaysPayable));
            lstParams.Add(new SqlParameter("@GenerateDate", obj.GenerateDate));
            lstParams.Add(new SqlParameter("@PayDate", obj.PayDate));
            lstParams.Add(new SqlParameter("@ApproverID", obj.ApproverID));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));

            int res = DBUtility.Modify(query, lstParams);

            if (res==1)
            {
                String selectquery = "select * from PaySlip where StaffID=@StaffID and FromDate=@FromDate and ToDate=@ToDate and GenerateDate=@GenerateDate and ApproverID=@ApproverID and AccountID=@AccountID";

                List<SqlParameter> lstParams1 = new List<SqlParameter>();

                lstParams1.Add(new SqlParameter("@StaffID", obj.StaffID));
                lstParams1.Add(new SqlParameter("@FromDate", obj.FromDate));
                lstParams1.Add(new SqlParameter("@ToDate", obj.ToDate));
                lstParams1.Add(new SqlParameter("@GenerateDate", obj.GenerateDate));                
                lstParams1.Add(new SqlParameter("@ApproverID", obj.ApproverID));
                lstParams1.Add(new SqlParameter("@AccountID", obj.AccountID));

                DataTable dt = DBUtility.Select(selectquery, lstParams1);

                return new PaySlip(Convert.ToInt32(dt.Rows[0]["PaySlipID"]),
                Convert.ToInt32(dt.Rows[0]["StaffID"]),
                Convert.ToDouble(dt.Rows[0]["BasicSalary"]),
                Convert.ToDouble(dt.Rows[0]["ConvAllowance"]),
                Convert.ToDouble(dt.Rows[0]["Bonus"]),
                Convert.ToDouble(dt.Rows[0]["PF"]),
                Convert.ToDouble(dt.Rows[0]["ProfessionalTax"]),
                Convert.ToDouble(dt.Rows[0]["IncomeTax"]),
                Convert.ToDouble(dt.Rows[0]["NetPay"]),
                Convert.ToDateTime(dt.Rows[0]["FromDate"]),
                Convert.ToDateTime(dt.Rows[0]["ToDate"]),
                Convert.ToInt32(dt.Rows[0]["DaysPayable"]),
                Convert.ToDateTime(dt.Rows[0]["GenerateDate"]),
                Convert.ToDateTime(dt.Rows[0]["PayDate"]),
                Convert.ToInt32(dt.Rows[0]["ApproverID"]),
                Convert.ToInt32(dt.Rows[0]["AccountID"]));
            }
            else
            {
                return null;
            }
        }

        public int update(PaySlip obj)
        {
            String query = "update PaySlip set BasicSalary=@BasicSalary, ConvAllowance=@ConvAllowance, Bonus=@Bonus, PF=@PF, ProfessionalTax=@ProfessionalTax, IncomeTax=@IncomeTax, NetPay=@Netpay, ApproverID=@ApproverID  where PaySlipID=@PaySlipID and AccountID=@AccountID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@BasicSalary", obj.BasicSalary));
            lstParams.Add(new SqlParameter("@ConvAllowance", obj.ConvAllowance));
            lstParams.Add(new SqlParameter("@Bonus", obj.Bonus));
            lstParams.Add(new SqlParameter("@PF", obj.PF));
            lstParams.Add(new SqlParameter("@ProfessionalTax", obj.ProfessionalTax));
            lstParams.Add(new SqlParameter("@IncomeTax", obj.IncomeTax));
            lstParams.Add(new SqlParameter("@NetPay", obj.NetPay));
            lstParams.Add(new SqlParameter("@ApproverID", obj.ApproverID));
            lstParams.Add(new SqlParameter("@PaySlipID", obj.PaySlipID));
            lstParams.Add(new SqlParameter("@AccountID", obj.AccountID));

            return DBUtility.Modify(query, lstParams); 
        }

        public int delete(int id)
        {
            String query = "delete from PaySlip where PaySlipID=@ID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ID", id));

            return DBUtility.Modify(query, lstParams);  
        }

        public PaySlip selectById(int id)
        {
            String query = "select * from PaySlip where PaySlipID=@id";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@id", id));
            DataTable dt = DBUtility.Select(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new PaySlip(Convert.ToInt32(dt.Rows[0]["PaySlipID"]),
                Convert.ToInt32(dt.Rows[0]["StaffID"]),
                Convert.ToDouble(dt.Rows[0]["BasicSalary"]),
                Convert.ToDouble(dt.Rows[0]["ConvAllowance"]),
                Convert.ToDouble(dt.Rows[0]["Bonus"]),
                Convert.ToDouble(dt.Rows[0]["PF"]),
                Convert.ToDouble(dt.Rows[0]["ProfessionalTax"]),
                Convert.ToDouble(dt.Rows[0]["IncomeTax"]),
                Convert.ToDouble(dt.Rows[0]["NetPay"]),
                Convert.ToDateTime(dt.Rows[0]["FromDate"]),
                Convert.ToDateTime(dt.Rows[0]["ToDate"]),
                Convert.ToInt32(dt.Rows[0]["DaysPayable"]),
                Convert.ToDateTime(dt.Rows[0]["GenerateDate"]),
                Convert.ToDateTime(dt.Rows[0]["PayDate"]),
                Convert.ToInt32(dt.Rows[0]["ApproverID"]),
                Convert.ToInt32(dt.Rows[0]["AccountID"]));
            }
            else
            {
                return null;
            }
            
        }

        public DataTable selectAll()
        {
            String query = "select * from PaySlip";

            return DBUtility.Select(query, new List<SqlParameter>());
        }

        public DataTable getLastPaySlipGenerateDate(int AccountID)
        {
            String query = "select ToDate from PaySlip where PaySlipID = ( select MAX(PaySlipID) from PaySlip where AccountID=@AccountID)";
            
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@AccountID", AccountID));

            return DBUtility.Select(query, lstParams); 
        }
    }
}
