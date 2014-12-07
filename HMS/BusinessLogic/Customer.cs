using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Customer : IModel
    {
        public int CustomerID;
        public DateTime CreateDate;
        public String Name;
        public String Email;
        public String Phone;
        public String Username;
        public String Password;
        public Boolean IsActive;
        public int AccountID;

        public Customer()
        {

        }

        public Customer(int CustomerID, DateTime CreateDate, String Name, String Email, String Phone, String Username, String Password, Boolean IsActive, int AccountID)
        {
            this.CustomerID = CustomerID;
            this.CreateDate = CreateDate;
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
            this.Username = Username;
            this.Password = Password;
            this.IsActive = IsActive;
            this.AccountID = AccountID;
        }
    }
}
