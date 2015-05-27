using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class systemadminhome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var User = Session["loggedUser"];
        if (!(User is SystemAdmin))
            Response.Redirect("login.aspx");

        SystemAdmin loggedUser = (SystemAdmin)User;

        if (loggedUser == null)
        {
            Response.Redirect("login.aspx?url=" + Request.Url);
        }

        if (!IsPostBack)
        {
        }    
    }
}