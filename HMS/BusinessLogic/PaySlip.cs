using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class PaySlip : IModel
    {
        public int PaySlipID;
        public int SaffID;
        public double BasicSalary;
        public double Allowance;
        public double Deduction;
        public DateTime FromDate;
        public DateTime ToDate;
        public DateTime GenerateDate;
        public DateTime PayDate;
        public int ApproverID;

        public PaySlip()
        {

        }

        public PaySlip(int PaySlipID, int SaffID, double BasicSalary, double Allowance, double Deduction, DateTime FromDate, DateTime ToDate, DateTime GenerateDate, DateTime PayDate, int ApproverID)
        {
            this.PaySlipID = PaySlipID;
            this.SaffID = SaffID;
            this.BasicSalary = BasicSalary;
            this.Allowance = Allowance;
            this.Deduction = Deduction;
            this.FromDate = FromDate;
            this.ToDate = ToDate;
            this.GenerateDate = GenerateDate;
            this.PayDate = PayDate;
            this.ApproverID = ApproverID;
            
        }
    }
}
