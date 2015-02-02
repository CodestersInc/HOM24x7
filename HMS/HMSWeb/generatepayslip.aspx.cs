using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class generatepayslip : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            AppUser LoggedAppUser = (AppUser)Session["AppUser"];
            if (LoggedAppUser == null || LoggedAppUser.UserType != "HotelAdmin")
            {
                Response.Redirect("login.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("ErrorPage500.html");
        }

    }
}