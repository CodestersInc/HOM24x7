using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class searchdepartment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["LoggedUser"];
        if (loggedUser == null)
        {
            Response.Redirect("login.aspx?url=" + Request.Url);
        }
        if (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff")
        {
            Response.Redirect("home.aspx");
        }
        if (!IsPostBack)
        {
            Repeater1.DataSource = new DepartmentLogic().search("", loggedUser.AccountID);
            Repeater1.DataBind();
        }
    }
    
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            DepartmentLogic departmentLogic = new DepartmentLogic();
            departmentLogic.delete(Convert.ToInt32(e.CommandArgument));
            Staff loggedUser = (Staff)Session["LoggedUser"];

            searchResultArea.Visible = true;
            Repeater1.DataSource = departmentLogic.search("", loggedUser.AccountID);
            Repeater1.DataBind();
        }
    }
}