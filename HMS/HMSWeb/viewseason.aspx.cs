using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class viewseason : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];
        if (loggedUser == null || loggedUser.UserType != "Hotel Admin")
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            Season seasonobject = new SeasonLogic().selectById(Convert.ToInt32(Request.QueryString["ID"]));
            txtSeasonName.Text = seasonobject.Name;
            txtFromDate.Text = (seasonobject.FromDate).Date.ToString("dd-MM-yyyy");
            txtToDate.Text = (seasonobject.ToDate).Date.ToString("dd-MM-yyyy");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        Season seasonobject = new Season(Convert.ToInt32(Request.QueryString["ID"]),
            txtSeasonName.Text,
            Convert.ToDateTime(txtFromDate.Text),
            Convert.ToDateTime(txtToDate.Text),
            loggedUser.AccountID);

        if (new SeasonLogic().update(seasonobject) == 1)
        {
            Response.Redirect("searchseason.aspx");
        }
        else
        {
            Response.Redirect("ErrorPage500.html");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}