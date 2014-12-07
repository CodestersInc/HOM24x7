using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class searchstaff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            AppUser LoggedAppUser = (AppUser)Session["AppUser"];
            if (LoggedAppUser == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (LoggedAppUser.UserType != "AccountAdmin")
            {
                Response.Redirect("login.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("ErrorPage500.html");
        }
        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            AppUser LoggedAppUser = (AppUser)Session["AppUser"];
            StaffLogic stafflogicobj = new StaffLogic();
            GridView1.DataSource = stafflogicobj.search(txtName.Text, LoggedAppUser.AccountID);
            GridView1.DataBind();
        }
        catch
        {
            Response.Redirect("ErrorPage500.html");
        }
        
    }
}