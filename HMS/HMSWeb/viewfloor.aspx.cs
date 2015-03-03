using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class viewfloor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        if (loggedUser == null || (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff"))
        {
            Response.Redirect("login.aspx");
        }

        if (!IsPostBack)
        {
            Floor floor = new FloorLogic().selectById(Convert.ToInt32(Request.QueryString["ID"]));
            txtDescription.Text = floor.Description;
            txtFloorNumber.Text = floor.FloorNumber;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        new FloorLogic().update(new Floor(Convert.ToInt32(Request.QueryString[ID]),
            txtFloorNumber.Text,
            txtDescription.Text,
            ((Staff)Session["loggedUser"]).AccountID));
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}