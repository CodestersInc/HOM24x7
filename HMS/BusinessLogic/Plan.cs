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
        public String FloorID;
        public String Image;

        public Plan()
        {

        }

        public Plan(int PlanID, String PlanStyle, String FloorID, String Image)
        {
            this.PlanID = PlanID;
            this.PlanStyle = PlanStyle;
            this.FloorID = FloorID;
            this.Image = Image;
        }
    }

}
