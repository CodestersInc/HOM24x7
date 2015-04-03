using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BusinessLogic;

/// <summary>
/// Summary description for OnlineBookingService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class OnlineBookingService : System.Web.Services.WebService {

    public OnlineBookingService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string PingServer() {
        return "Server Connected";
    }

    [WebMethod]
    public string createOnlineBooking(int RoomTypeID, int NoOfPersons, string CheckInDate, string PlannedCheckoutDate, int CustomerID,string CustomerRemarks, double WebsiteRate)
    {
        DateTime mCheckInDate;
        DateTime mPlannedCheckoutDate;
        try
        {
            mCheckInDate = Convert.ToDateTime(CheckInDate);
            mPlannedCheckoutDate = Convert.ToDateTime(PlannedCheckoutDate);
        }
        catch(FormatException)
        {
            return "Inappropriate Date Format";
        }
        
        OnlineBooking onlineBookingObj = new OnlineBookingLogic().create(new OnlineBooking(0,
            RoomTypeID,
            NoOfPersons,
            mCheckInDate,
            mPlannedCheckoutDate,
            "",
            CustomerID,
            0,
            "",
            CustomerRemarks,
            WebsiteRate));

        return "Hello World";
    }
}
