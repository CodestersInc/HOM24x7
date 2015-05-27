using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using WebUtility;

public partial class viewattendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var User = Session["loggedUser"];
        if (!(User is Staff))
            Response.Redirect("login.aspx");
        Staff loggedUser = (Staff)User;
        if (loggedUser == null)
        {
            Response.Redirect("login.aspx");
        }
        if (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff" && loggedUser.UserType != "Regular Staff" && loggedUser.UserType != "Reception Staff")
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
            editableAttendanceRepeater.DataSource = new AttendanceLogic().getAttendanceForRange(DateTime.Now.Date,
                DateTime.Now.Date,
                loggedUser.AccountID);
            editableAttendanceRepeater.DataBind();

            txtFromDate.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
            txtToDate.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
        }

        if (!IsPostBack && loggedUser.UserType == "Managerial Staff")
        {
            editableAttendanceRepeater.DataSource = new AttendanceLogic().getAttendanceForRange(DateTime.Now.Date,
                DateTime.Now.Date,
                loggedUser.DepartmentID,
                loggedUser.AccountID);
            editableAttendanceRepeater.DataBind();

            txtFromDate.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
            txtToDate.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
        }

        if (!IsPostBack && (loggedUser.UserType == "Regular Staff" || loggedUser.UserType == "Reception Staff"))
        {
            nonEditableAttendanceRepeater.DataSource = new AttendanceLogic().getAttendanceForRange(DateTime.Now.Date,
                DateTime.Now.Date,
                loggedUser.StaffID,
                "Staff");
            editableAttendanceRepeater.DataBind();

            txtFromDate.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
            txtToDate.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
            editableAttendancePH.Visible = false;
            nonEditableAttendancePH.Visible = true;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["LoggedUser"];

        if (loggedUser.UserType == "Hotel Admin" || loggedUser.UserType == "Managerial Staff")
        {
            editableAttendanceRepeater.DataSource = (loggedUser.UserType == "Managerial Staff") ? new AttendanceLogic().getAttendanceForRange(Convert.ToDateTime(txtFromDate.Text),
                Convert.ToDateTime(txtToDate.Text),
                loggedUser.DepartmentID,
                loggedUser.AccountID) : new AttendanceLogic().getAttendanceForRange(Convert.ToDateTime(txtFromDate.Text),
                Convert.ToDateTime(txtToDate.Text),
                Convert.ToInt32(ddlDepartment.SelectedValue),
                loggedUser.AccountID);

            editableAttendanceRepeater.DataBind();
        }
        if (loggedUser.UserType == "Regular Staff" || loggedUser.UserType == "Reception Staff")
        {
            nonEditableAttendanceRepeater.DataSource = new AttendanceLogic().getAttendanceForRange(Convert.ToDateTime(txtFromDate.Text),
                Convert.ToDateTime(txtToDate.Text),
                loggedUser.StaffID,
                "Staff");

            nonEditableAttendanceRepeater.DataBind();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        AttendanceLogic attendanceLogic = new AttendanceLogic();
        Attendance attendanceObj = new Attendance();

        for (int i = 0; i < editableAttendanceRepeater.Items.Count; i++)
        {
            attendanceObj.AttendanceID = Convert.ToInt32(((HiddenField)editableAttendanceRepeater.Items[i].FindControl("HiddenFieldAttendanceID")).Value);
            attendanceObj.StaffID = Convert.ToInt32(((HiddenField)editableAttendanceRepeater.Items[i].FindControl("HiddenFieldStaffID")).Value);
            attendanceObj.AttendanceDate = Convert.ToDateTime(((HiddenField)editableAttendanceRepeater.Items[i].FindControl("HiddenFieldAttendanceDate")).Value);
            attendanceObj.InTime = Convert.ToDateTime(((HiddenField)editableAttendanceRepeater.Items[i].FindControl("HiddenFieldInTime")).Value);
            attendanceObj.OutTime = Convert.ToDateTime(((HiddenField)editableAttendanceRepeater.Items[i].FindControl("HiddenFieldOutTime")).Value);
            attendanceObj.AttendanceStatus = ((CheckBox)editableAttendanceRepeater.Items[i].FindControl("cbxPresence")).Checked;

            if (attendanceLogic.update(attendanceObj) != 1)
            {
                Utility.MsgBox("Attendance details updated successfully...!!", this.Page, this, "viewattendance.aspx");
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}