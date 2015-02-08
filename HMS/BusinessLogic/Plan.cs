using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Plan : IModel
    {
        public int PlanID;
        public String PlanStyle;
        public String FloorNumber;
        public int AccountID;

        public Plan()
        {

        }

        public Plan(int PlanID, String PlanStyle, String FloorNumber, int AccountID)
        {
            this.PlanID = PlanID;
            this.PlanStyle = PlanStyle;
            this.FloorNumber = FloorNumber;
            this.AccountID = AccountID;
        }
    }

}
