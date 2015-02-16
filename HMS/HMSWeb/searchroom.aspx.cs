using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class searchroom : System.Web.UI.Page
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

        searchResultArea.Visible = true;
        Repeater1.DataSource = new RoomLogic().search(txtName.Text, loggedUser.AccountID);
        Repeater1.DataBind();

    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            DepartmentLogic departmentLogic = new DepartmentLogic();
            departmentLogic.delete(Convert.ToInt32(e.CommandArgument));
            Staff loggedUser = (Staff)Session["LoggedUser"];

            searchResultArea.Visible = true;
            Repeater1.DataSource = departmentLogic.search(txtName.Text, loggedUser.AccountID);
            Repeater1.DataBind();
        }
    }
}