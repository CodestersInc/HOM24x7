using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    class ServiceType: IModel
    {
        public int ServiceTypeID;
        public string Name;
        public string Description;
        public string Image;
        public int AccountID;

        public ServiceType()
        {

        }

        public ServiceType(int ServiceTypeID, string Name, string Description, string Image, int AccountID)
        {
            this.ServiceTypeID = ServiceTypeID;
            this.Name = Name;
            this.Description = Description;
            this.Image = Image;
            this.AccountID = AccountID;
        }
    }
}
