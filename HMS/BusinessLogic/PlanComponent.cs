using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class PlanComponent : IModel
    {
        public int PlanComponentID;
        public String PlanComponentStyle;
        public int RoomID; //if any
        public int PlanID;
        public int ComponentID;


        public PlanComponent()
        {

        }

        public PlanComponent(int PlanComponentID,String PlanComponentStyle,int RoomID,int PlanID,int ComponentID)
        {
            this.PlanComponentID = PlanComponentID;
            this.PlanComponentStyle = PlanComponentStyle;
            this.RoomID = RoomID;
            this.PlanID = PlanID;
            this.ComponentID = ComponentID;
        }

    }
}
