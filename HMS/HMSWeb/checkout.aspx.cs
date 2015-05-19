using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using WebUtility;
using System.Threading;

public partial class checkout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Booking booking = new BookingLogic().selectById(Convert.ToInt32(Request.QueryString["ID"]));

        if (booking.Status != "Checked In")
        {
            Utility.MsgBox("The user has never checked in", this.Page, this, "searchbooking.aspx");          
        }
    }
}