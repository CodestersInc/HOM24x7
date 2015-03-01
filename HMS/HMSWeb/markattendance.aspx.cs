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

        if (loggedUser == null || (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff"))
        {
            Response.Redirect("login.aspx");
        }

        AttendanceLogic attendanceLogic = new AttendanceLogic();

        if (attendanceLogic.isMarked(loggedUser.DepartmentID, loggedUser.AccountID))
        {
            Response.Redirect("viewattendance.aspx");
        }

        if (!IsPostBack)
        {
            Repeater1.DataSource = attendanceLogic.getStaffByDepartment(loggedUser.DepartmentID, loggedUser.AccountID);
            Repeater1.DataBind();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        AttendanceLogic attendanceLogic = new AttendanceLogic();

        for (int i = 0; i < Repeater1.Items.Count; i++)
        {
            attendanceLogic.create(new Attendance(0,
                Convert.ToInt32(((HiddenField)Repeater1.Items[i].FindControl("HiddenFieldStaffID")).Value),
                DateTime.Now,
                DateTime.Now,
                DateTime.Now,
                ((CheckBox)Repeater1.Items[i].FindControl("cbxPresence")).Checked));
        }
        Response.Redirect("viewattendance.aspx");
    }
}