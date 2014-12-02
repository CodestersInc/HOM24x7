using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Season : IModel
    {
        public int SeasonID;
        public String Name;
        public DateTime FromDate;
        public DateTime ToDate;
        public int AccountID;

        public Season()
        {

        }

        public Season(int SeasonID, String Name, DateTime FromDate, DateTime ToDate, int AccountID)
        {
            this.SeasonID = SeasonID;
            this.Name = Name;
            this.FromDate = FromDate;
            this.ToDate = ToDate;
            this.AccountID = AccountID;
        }
    }
}
