using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Service : IModel
    {
        public int ServiceID;
        public String Name;
        public int DepartmentID;
        public double Rate;
        public String Image;
        public int ServiceTypeID;

        public Service()
        {

        }

        public Service(int ServiceID, String Name, int DepartmentID, double Rate, String Image, int ServiceTypeID)
        {
            this.ServiceID = ServiceID;
            this.Name = Name;
            this.DepartmentID = DepartmentID;
            this.Rate = Rate;
            this.Image = Image;
            this.ServiceTypeID = ServiceTypeID;
        }
    }
}
