using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class FloorPlan : IModel
    {
        public int PlanID;
        public String PlanStyle;
        public int FloorID;
        public String Image;

        public FloorPlan()
        {

        }

        public FloorPlan(int PlanID, String PlanStyle, int FloorID, String Image)
        {
            this.PlanID = PlanID;
            this.PlanStyle = PlanStyle;
            this.FloorID = FloorID;
            this.Image = Image;
        }
    }

}
