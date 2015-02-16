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
        public int FloorID;
        public String Building;
        public String Status;

        public Room()
        {

        }

        public Room(int RoomID, int RoomTypeID, String Number, int FloorID, String Building, String Status)
        {
            this.RoomID = RoomID;
            this.RoomTypeID = RoomTypeID;
            this.Number = Number;
            this.FloorID = FloorID;
            this.Building = Building;
            this.Status = Status;
        }
    }
}
