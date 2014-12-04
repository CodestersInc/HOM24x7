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
        AppUser LoggedAppUser = (AppUser)Session["AppUser"];
        if (LoggedAppUser == null)
        {
            Response.Redirect("login.aspx");
        }
        else if (LoggedAppUser.UserType != "AccountAdmin")
        {
            Response.Redirect("login.aspx");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        AppUser LoggedAppUser = (AppUser)Session["AppUser"];
        DepartmentLogic departmentLogicObj = new DepartmentLogic();
        GridView1.DataSource = departmentLogicObj.search(txtName.Text, LoggedAppUser.AccountID);
        GridView1.DataBind();
    }
}