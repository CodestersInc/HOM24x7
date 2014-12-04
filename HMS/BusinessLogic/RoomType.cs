using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class RoomType : IModel
    {
        public int RoomTypeID;
        public String Name;
        public String Description;
        public String Photo;
        public int AccountID;

        public RoomType()
        {

        }

        public RoomType(int RoomTypeID, String Name, String Description, String Photo, int AccountID)
        {
            this.RoomTypeID = RoomTypeID;
            this.Name = Name;
            this.Description = Description;
            this.Photo = Photo;
            this.AccountID = AccountID;
        }
    }
}
