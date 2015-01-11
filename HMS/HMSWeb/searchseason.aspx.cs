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
        GridView1.DataSource = new SeasonLogic().search(txtSeasonName.Text, loggedUser.AccountID);
        GridView1.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            new SeasonLogic().delete(Convert.ToInt32(e.CommandArgument));
            Staff loggeduser = (Staff)Session["loggeduser"];
            GridView1.DataSource = new SeasonLogic().search(txtSeasonName.Text, loggeduser.AccountID);
            GridView1.DataBind();
        }
    }
}