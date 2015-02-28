using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Account : IModel
    {
        public int AccountID;
        public String Company;
        public String ContactPerson;
        public String Email;
        public String Phone;              //to be modified later if needed
        public String Address;
        public String Website;
        public String Features;

        public Account()
        {

        }

        public Account(int AccountID, String Company, String ContactPerson, String Email, String Phone, String Address, String Website, String Features)
        {
            this.AccountID = AccountID;
            this.Company = Company;
            this.ContactPerson = ContactPerson;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.Website = Website;
            this.Features = Features;

        }
    }
}
