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
        public float Rate;
        public float AgentDiscount;
        public float MaxDiscount;
        public float WebsiteRate;

        public SeasonRoom()
        {

        }

        public SeasonRoom(int SeasonRoomID, int SeasonID, int RoomTypeID, float Rate, float AgentDiscount, float MaxDiscount, float WebsiteRate)
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
