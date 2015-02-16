using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Floor : IModel
    {
        public int FloorID;
        public String FloorNumber;
        public String Description;
        public int AccountID;

        public Floor()
        {

        }

        public Floor(int FloorID, String FloorNumber, String Description, int AccountID)
        {
            this.FloorID = FloorID;
            this.FloorNumber = FloorNumber;
            this.Description = Description;
            this.AccountID = AccountID;
        }

    }
}
