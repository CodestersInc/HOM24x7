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
        if (Session["StaffUserType"].ToString() != "HotelAdmin")
        {
            Response.Redirect("login.aspx");
        }
        if (loggedUser == null)
        {
            Response.Redirect("login.aspx");
        }
        else if (loggedUser.UserType != "HotelAdmin")
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //try
        //{
        Staff loggedUser = (Staff)Session["LoggedUser"];
        DepartmentLogic departmentLogicObj = new DepartmentLogic();
        GridView1.DataSource = departmentLogicObj.search(txtName.Text, loggedUser.AccountID);
        GridView1.DataBind();
        //}
        //catch (Exception ex)
        //{
        //    Response.Redirect("ErrorPage500.html");
        //}

    }
}