using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Room : IModel
    {
        public int RoomID;
        public int RoomTypeID;
        public String Number;
        public String Floor;
        public String Building;
        public String Status;

        public Room()
        {

        }

        public Room(int RoomID, int RoomTypeID, String Number, String Floor, String Building, String Status)
        {
            this.RoomID = RoomID;
            this.RoomTypeID = RoomTypeID;
            this.Number = Number;
            this.Floor = Floor;
            this.Building = Building;
            this.Status = Status;
        }
    }
}
