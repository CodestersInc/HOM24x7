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
        public String RoomNumber;
        public int FloorID;
        public String Status;

        public Room()
        {

        }

        public Room(int RoomID, int RoomTypeID, String RoomNumber, int FloorID, String Status)
        {
            this.RoomID = RoomID;
            this.RoomTypeID = RoomTypeID;
            this.RoomNumber = RoomNumber;
            this.FloorID = FloorID;
            this.Status = Status;
        }
    }
}
