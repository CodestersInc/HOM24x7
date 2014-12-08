using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class searchdepartment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["LoggedUser"];
        if (loggedUser == null || loggedUser.UserType != "HotelAdmin")
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["LoggedUser"];
        GridView1.DataSource = new DepartmentLogic().search(txtName.Text, loggedUser.AccountID);
        GridView1.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            new DepartmentLogic().delete(Convert.ToInt32(e.CommandArgument));
            Staff loggedUser = (Staff)Session["LoggedUser"];
            GridView1.DataSource = new DepartmentLogic().search(txtName.Text, loggedUser.AccountID);
            GridView1.DataBind();
        }
    }
}