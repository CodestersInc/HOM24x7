using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class viewattendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["LoggedUser"];
        
        
        if (loggedUser != null && (loggedUser.UserType == "Managerial Staff" || loggedUser.UserType != "Hotel Admin"))
        {
            //Do work if the logged user is a hotel admin or department manager

        }
        else
        {
            Response.Redirect("login.aspx");
        }

        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["LoggedUser"];

        Repeater1.DataSource = (loggedUser.UserType == "Managerial Staff") ? new AttendanceLogic().getAttendanceRange(Convert.ToDateTime(txtFromDate.Text),
            Convert.ToDateTime(txtToDate.Text),
            loggedUser.DepartmentID,
            loggedUser.AccountID) : new AttendanceLogic().getAttendanceRange(Convert.ToDateTime(txtFromDate.Text),
            Convert.ToDateTime(txtToDate.Text),
            loggedUser.AccountID);

        Repeater1.DataBind();
    }
}