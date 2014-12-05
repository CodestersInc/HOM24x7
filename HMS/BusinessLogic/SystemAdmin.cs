using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    class SystemAdmin : IModel
    {
        public int SystemAdminID;
        public string Name;
        public string Username;
        public string Password;
        public string Email;
        public string Phone;

        public SystemAdmin()
        {

        }

        public SystemAdmin(int SystemAdminID, string Name, string Username, string Password, string Email, string Phone)
        {
            this.SystemAdminID = SystemAdminID;
            this.Name = Name;
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
            this.Phone = Phone;
        }
    }
}
