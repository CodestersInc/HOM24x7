using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Staff : IModel
    {
        public int StaffID;
        public int AppUserID;
        public String Designation;
        public DateTime DOB;
        public DateTime DOJ;
        public double Salary;
        public String SalaryFrequency;
        public Boolean IsActive;
        public int DepartmentID;

        public Staff()
        {

        }

        public Staff(int StaffID, int AppUserID, String Designation, DateTime DOB, DateTime DOJ, double Salary, String SalaryFrequency, Boolean IsActive, int DepartmentID)
        {
            this.StaffID = StaffID;
            this.AppUserID = AppUserID;
            this.Designation = Designation;
            this.DOB = DOB;
            this.DOJ = DOJ;
            this.Salary = Salary;
            this.SalaryFrequency = SalaryFrequency;
            this.IsActive = IsActive;
            this.DepartmentID = DepartmentID;
        }
    }
}
