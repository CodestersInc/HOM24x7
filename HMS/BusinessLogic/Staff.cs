﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Staff : IModel
    {
        public int StaffID;
        public String StaffCode;
        public String Name;
        public String Email;
        public String Phone;
        public String Username;
        public String Password;
        public String UserType;
        public String Designation;
        public DateTime DOB;
        public DateTime DOJ;
        public double Salary;
        public Boolean IsActive;
        public String BankACNumber;
        public int DepartmentID;
        public int AccountID;

        public Staff()
        {

        }

        public Staff(int StaffID, String StaffCode, String Name, String Email, String Phone, String Username, String Password, String UserType, String Designation, DateTime DOB, DateTime DOJ, double Salary, Boolean IsActive, String BankACNumber, int DepartmentID, int AccountID)
        {
            this.StaffID = StaffID;
            this.StaffCode = StaffCode;
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
            this.Username = Username;
            this.Password = Password;
            this.UserType = UserType;
            this.Designation = Designation;
            this.DOB = DOB;
            this.DOJ = DOJ;
            this.Salary = Salary;
            this.IsActive = IsActive;
            this.BankACNumber = BankACNumber;
            this.DepartmentID = DepartmentID;
            this.AccountID = AccountID;
        }
    }
}
