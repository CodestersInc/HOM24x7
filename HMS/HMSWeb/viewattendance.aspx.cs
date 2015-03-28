using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class viewattendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["LoggedUser"];
        if (loggedUser == null)
        {
            Response.Redirect("login.aspx");
        }
        if (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff")
        {
            Response.Redirect("home.aspx");
        }

        if (!IsPostBack && loggedUser.UserType == "Hotel Admin")
        {
            ddlDepartmentPlaceHolder.Visible = true;
            //Fill Department List
            DataTable dt = new DepartmentLogic().selectDistinctDepartment(loggedUser.AccountID);
            dt.Rows.Add("All", 0);
            ddlDepartment.DataSource = dt;
            ddlDepartment.DataValueField = "DepartmentID";
            ddlDepartment.DataTextField = "DepartmentChoices";
            ddlDepartment.DataBind();

            ddlDepartment.SelectedValue = "0";
            Repeater1.DataSource = new AttendanceLogic().getAttendanceRange(DateTime.Now.Date,
                DateTime.Now.Date,
                loggedUser.AccountID);
            Repeater1.DataBind();

            txtFromDate.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
            txtToDate.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");

        }

        if (!IsPostBack && loggedUser.UserType == "Managerial Staff")
        {
            Repeater1.DataSource = new AttendanceLogic().getAttendanceRange(DateTime.Now.Date,
                DateTime.Now.Date,
                loggedUser.DepartmentID,
                loggedUser.AccountID);
            Repeater1.DataBind();

            txtFromDate.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
            txtToDate.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
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
            Convert.ToInt32(ddlDepartment.SelectedValue),
            loggedUser.AccountID);

        Repeater1.DataBind();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        AttendanceLogic attendanceLogic = new AttendanceLogic();
        Attendance attendanceObj = new Attendance();

        for(int i=0; i<Repeater1.Items.Count; i++)
        {
            attendanceObj.AttendanceID = Convert.ToInt32(((HiddenField)Repeater1.Items[i].FindControl("HiddenFieldAttendanceID")).Value);
            attendanceObj.StaffID = Convert.ToInt32(((HiddenField)Repeater1.Items[i].FindControl("HiddenFieldStaffID")).Value);
            attendanceObj.AttendanceDate = Convert.ToDateTime(((HiddenField)Repeater1.Items[i].FindControl("HiddenFieldAttendanceDate")).Value);
            attendanceObj.InTime = Convert.ToDateTime(((HiddenField)Repeater1.Items[i].FindControl("HiddenFieldInTime")).Value);
            attendanceObj.OutTime = Convert.ToDateTime(((HiddenField)Repeater1.Items[i].FindControl("HiddenFieldOutTime")).Value);
            attendanceObj.AttendanceStatus = ((CheckBox)Repeater1.Items[i].FindControl("cbxPresence")).Checked;

            attendanceLogic.update(attendanceObj);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}