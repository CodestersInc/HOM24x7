using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class markattendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Staff loggedUser = (Staff)Session["LoggedUser"];
        if (loggedUser == null || loggedUser.UserType != "HotelAdmin")
        {
            Response.Redirect("login.aspx");
        }

        Repeater1.DataSource = new AttendanceLogic().getStaffByDepartment(loggedUser.DepartmentID, loggedUser.AccountID);
        Repeater1.DataBind();

    }
}