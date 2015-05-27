using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using BusinessLogic;
using WebUtility;

public partial class createfloor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var User = Session["loggedUser"];
        
        if (!(User is Staff))
            Response.Redirect("login.aspx");

        Staff loggedUser = (Staff)Session["loggedUser"];

        if (loggedUser == null)
        {
            Response.Redirect("login.aspx?url=" + Request.Url);
        }
        if (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff")
        {
            Response.Redirect("home.aspx");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        if (new FloorLogic().create(new Floor(0,
            txtFloorNumber.Text,
            txtDescription.Text,
            loggedUser.AccountID)) != null)
        {
            Utility.MsgBox("Floor created successfully...!!", this.Page, this, "home.aspx");
        }
        else
        {
            Utility.MsgBox("Error: Floor creation failed...!!", this.Page, this, "createfloor.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("createroom.aspx");
    }
}