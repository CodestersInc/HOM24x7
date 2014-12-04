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
        public int AppUserID;
        public DateTime CreateDate;
        public Boolean IsActive;

        public Customer()
        {

        }

        public Customer(int CustomerID, int AppUserID, DateTime CreateDate, Boolean IsActive)
        {
            this.CustomerID = CustomerID;
            this.AppUserID = AppUserID;
            this.CreateDate = CreateDate;
            this.IsActive = IsActive;
        }
    }
}
