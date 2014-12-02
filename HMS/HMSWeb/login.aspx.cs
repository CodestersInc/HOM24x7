using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        AppUserLogic appUserLogic = new AppUserLogic();
        AppUser loger = appUserLogic.login(txtUsername.Text, txtPassword.Text);
        if ( loger!= null)
        {
            Session.Add("AppUser", loger);
            Response.Redirect("home.aspx");
        }
        else
        {
            
        }

    }
}