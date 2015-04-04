using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class searchbooking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
        Staff loggedUser = (Staff)Session["LoggedUser"];
        searchResultArea.Visible = true;
        Repeater1.DataSource = new BookingLogic().search(txtName.Text, loggedUser.AccountID);
        Repeater1.DataBind();
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            Staff loggedUser = (Staff)Session["LoggedUser"];
            BookingLogic bookingLogic = new BookingLogic();
            bookingLogic.delete(Convert.ToInt32(e.CommandArgument));            
            searchResultArea.Visible = true;
            Repeater1.DataSource = bookingLogic.search(txtName.Text, loggedUser.AccountID);
            Repeater1.DataBind();
        }
    }
}