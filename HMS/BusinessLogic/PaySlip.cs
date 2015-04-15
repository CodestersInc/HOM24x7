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
        public int StaffID;
        public double BasicSalary;
        public double ConvAllowance;
        public double Bonus;
        public double PF;
        public double ProfessionalTax;
        public double IncomeTax;
        public double NetPay;
        public DateTime FromDate;
        public DateTime ToDate;
        public int DaysPayable;
        public DateTime PayDate;
        public DateTime GenerateDate;
        public int ApproverID;
        public int AccountID;

        public PaySlip()
        {

        }
        public PaySlip(int PaySlipID, int StaffID, double BasicSalary, double ConvAllowance, double Bonus, double PF, double ProfessionalTax, double IncomeTax, double NetPay, DateTime FromDate, DateTime ToDate, int DaysPayable, DateTime PayDate, DateTime GenerateDate, int ApproverID, int AccountID)
        {
            this.PaySlipID = PaySlipID;
            this.StaffID = StaffID;
            this.BasicSalary = BasicSalary;
            this.ConvAllowance = ConvAllowance;
            this.Bonus = Bonus;
            this.PF = PF;
            this.ProfessionalTax = ProfessionalTax;
            this.IncomeTax = IncomeTax;
            this.NetPay = NetPay;
            this.FromDate = FromDate;
            this.ToDate = ToDate;
            this.DaysPayable = DaysPayable;
            this.PayDate = PayDate;
            this.GenerateDate = GenerateDate;
            this.ApproverID = ApproverID;
            this.AccountID = AccountID;
        }
    }
}
