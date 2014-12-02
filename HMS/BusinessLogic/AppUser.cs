using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AppUser : IModel
    {
        public int AppUserID;
        public String Name;
        public String Email;
        public String Phone;           //To be changed as and when needed
        public int AccountID;





        public String Username;
        public String Password;

        public AppUser()
        {

        }

        public AppUser(int AppUserID, String Name, String Email, String Phone, int AccountID, String Username, String Password)
        {
            this.AppUserID = AppUserID;
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
            this.AccountID = AccountID;
            this.Username = Username;
            this.Password = Password;
        }
    }
}
