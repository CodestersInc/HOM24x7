using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Customer : IModel
    {
        public int CustomerID { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int AccountID { get; set; }

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
