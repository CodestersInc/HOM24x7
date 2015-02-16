using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;


public partial class searchseason : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        if (loggedUser == null || loggedUser.UserType != "HotelAdmin")
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        searchResultArea.Visible = true;
        Repeater1.DataSource = new SeasonLogic().search(txtSeasonName.Text, loggedUser.AccountID);
        Repeater1.DataBind();
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            SeasonLogic seasonLogic = new SeasonLogic();
            seasonLogic.delete(Convert.ToInt32(e.CommandArgument));
            Staff loggeduser = (Staff)Session["loggeduser"];

            searchResultArea.Visible = true;
            Repeater1.DataSource = seasonLogic.search(txtSeasonName.Text, loggeduser.AccountID);
            Repeater1.DataBind();
        }
    }
}