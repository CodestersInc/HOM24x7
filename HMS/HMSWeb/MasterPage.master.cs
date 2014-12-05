using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUser LoggedAppUser = (AppUser)Session["AppUser"];

        if (LoggedAppUser == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            lblUsername.Text = LoggedAppUser.Name;
        }
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        AppUser LoggedAppUser = (AppUser)Session["AppUser"];
        Session["AppUser"] = null;
        Response.Redirect("login.aspx");
    }
}
