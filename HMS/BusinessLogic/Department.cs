using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Department : IModel
    {
        public int DepartmentID;
        public String Name;
        public int AccountID;
        public int ManagerID;

        public Department()
        {

        }

        public Department(int DepartmentID, String Name, int AccountID, int ManagerID)
        {
            this.DepartmentID = DepartmentID;
            this.Name = Name;
            this.AccountID = AccountID;
            this.ManagerID = ManagerID;
        }
    }
}
