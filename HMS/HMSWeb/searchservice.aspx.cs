using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class searchservice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        if (loggedUser == null || loggedUser.UserType != "HotelAdmin")
        {
            Response.Redirect("login.aspx");
        }        
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        searchResultArea.Visible = true;
        Repeater1.DataSource = new ServiceLogic().search(txtName.Text, loggedUser.AccountID);
        Repeater1.DataBind();
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            ServiceLogic serviceLogic = new ServiceLogic();
            serviceLogic.delete(Convert.ToInt32(e.CommandArgument));
            Staff loggeduser = (Staff)Session["loggeduser"];

            searchResultArea.Visible = true;
            Repeater1.DataSource = serviceLogic.search(txtName.Text, loggeduser.AccountID);
            Repeater1.DataBind();
        }
    }
}