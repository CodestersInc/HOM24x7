using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SeasonRoom : IModel
    {
        public int SeasonRoomID;
        public int SeasonID;
        public int RoomTypeID;
        public double Rate;
        public double AgentDiscount;
        public double MaxDiscount;
        public double WebsiteRate;

        public SeasonRoom()
        {

        }

        public SeasonRoom(int SeasonRoomID, int SeasonID, int RoomTypeID, double Rate, double AgentDiscount, double MaxDiscount, double WebsiteRate)
        {
            this.SeasonRoomID = SeasonRoomID;
            this.SeasonID = SeasonID;
            this.RoomTypeID = RoomTypeID;
            this.Rate = Rate;
            this.AgentDiscount = AgentDiscount;
            this.MaxDiscount = MaxDiscount;
            this.WebsiteRate = WebsiteRate;
        }

    }
}
