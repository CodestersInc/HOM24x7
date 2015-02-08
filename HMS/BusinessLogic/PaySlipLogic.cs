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

        public PaySlip create(PaySlip obj)
        {
            String query = "insert into PaySlip values(@SaffID, @BasicSalary, @Allowance, @Deduction, @FromDate, @ToDate, @GenerateDate, @ApproverID); select * from PaySlip where BasicSalary=@BasicSalary and Allowance=@Allowance and Deduction=@Deduction and FromDate=@FromDate and ToDate=@ToDate and GenerateDate=@GenerateDate PayDate=@PayDate and ApproverID=@ApproverID);";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@SaffID", obj.SaffID));
            lstParams.Add(new SqlParameter("@BasicSalary", obj.BasicSalary));
            lstParams.Add(new SqlParameter("@Allowance", obj.Allowance));
            lstParams.Add(new SqlParameter("@Deduction", obj.Deduction));
            lstParams.Add(new SqlParameter("@FromDate", obj.FromDate));
            lstParams.Add(new SqlParameter("@ToDate", obj.ToDate));
            lstParams.Add(new SqlParameter("@GenerateDate", obj.GenerateDate));
            lstParams.Add(new SqlParameter("@PayDate", obj.PayDate));
            lstParams.Add(new SqlParameter("@ApproverID", obj.ApproverID));

            DataTable dt = DBUtility.InsertAndFetch(query, lstParams);

            if (dt.Rows.Count == 1)
            {
                return new PaySlip(Convert.ToInt32(dt.Rows[0]["PaySlipID"]),
                Convert.ToInt32(dt.Rows[0]["StaffID"]),
                Convert.ToDouble(dt.Rows[0]["BasicSalary"]),
                Convert.ToDouble(dt.Rows[0]["Allowance"]),
                Convert.ToDouble(dt.Rows[0]["Deduction"]),
                Convert.ToDateTime(dt.Rows[0]["FromDate"]),
                Convert.ToDateTime(dt.Rows[0]["ToDate"]),
                Convert.ToDateTime(dt.Rows[0]["GeneratedDate"]),
                Convert.ToDateTime(dt.Rows[0]["PayDate"]),
                Convert.ToInt32(dt.Rows[0]["ApproverID"]));

            }
            else
            {
                return null;
            }
        }

        public int update(PaySlip obj)
        {
            String query = "update PaySlip set SaffID=@SaffID, BasicSalary=@BasicSalary, Allowance=@Allowance, Deduction=@Deduction, FromDate=@FromDate, ToDate=@ToDate, GenerateDate=@GenerateDate, ApproverID=@ApproverID where PaySlipID=@PaySlipID";
            List<SqlParameter> lstParams = new List<SqlParameter>();

            lstParams.Add(new SqlParameter("@PaySlipID", obj.PaySlipID));
            lstParams.Add(new SqlParameter("@SaffID", obj.SaffID));
            lstParams.Add(new SqlParameter("@BasicSalary", obj.BasicSalary));
            lstParams.Add(new SqlParameter("@Allowance", obj.Allowance));
            lstParams.Add(new SqlParameter("@Deduction", obj.Deduction));
            lstParams.Add(new SqlParameter("@FromDate", obj.FromDate));
            lstParams.Add(new SqlParameter("@ToDate", obj.ToDate));
            lstParams.Add(new SqlParameter("@GenerateDate", obj.GenerateDate));
            lstParams.Add(new SqlParameter("@ApproverID", obj.ApproverID));

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
                Convert.ToDouble(dt.Rows[0]["Allowance"]),
                Convert.ToDouble(dt.Rows[0]["Deduction"]),
                Convert.ToDateTime(dt.Rows[0]["FromDate"]),
                Convert.ToDateTime(dt.Rows[0]["ToDate"]),
                Convert.ToDateTime(dt.Rows[0]["GeneratedDate"]),
                Convert.ToDateTime(dt.Rows[0]["PayDate"]),
                Convert.ToInt32(dt.Rows[0]["ApproverID"]));

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
    }
}
