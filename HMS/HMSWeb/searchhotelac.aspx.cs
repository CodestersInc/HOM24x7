using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class hacsearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUser LoggedAppUser = (AppUser)Session["AppUser"];
        if (LoggedAppUser == null)
        {
            Response.Redirect("login.aspx");
        }
        else if (LoggedAppUser.UserType != "SystemAdmin")
        {
            Response.Redirect("login.aspx");
        }
        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        AccountLogic accountlogicobj = new AccountLogic();
        GridView1.DataSource = accountlogicobj.search(txtName.Text,0);
        GridView1.DataBind();
    }
}