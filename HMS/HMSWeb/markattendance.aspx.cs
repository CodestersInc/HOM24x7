using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using WebUtility;

public partial class markattendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var User = Session["loggedUser"];
        if (!(User is Staff))
            Response.Redirect("login.aspx");

        Staff loggedUser = (Staff)User;

        if (loggedUser == null)
        {
            Response.Redirect("login.aspx?url=" + Request.Url);
        }
        if (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff")
        {
            Response.Redirect("home.aspx");
        }

        if (!IsPostBack && loggedUser.UserType == "Hotel Admin")
        {
            DataTable staff = new AttendanceLogic().getStaffForAttendance(0, loggedUser.AccountID);

            if (staff.Rows.Count > 0)
            {
                Repeater1.DataSource = staff;
                Repeater1.DataBind();
            }
            else
            {
                Response.Redirect("viewattendance.aspx");
            }

            ddlDepartmentPlaceHolder.Visible = true;
            //Fill Department List
            DataTable dt = new DepartmentLogic().selectDistinctDepartment(loggedUser.AccountID);
            dt.Rows.Add("All", 0);
            ddlDepartment.DataSource = dt;
            ddlDepartment.DataValueField = "DepartmentID";
            ddlDepartment.DataTextField = "DepartmentChoices";
            ddlDepartment.DataBind();

            ddlDepartment.SelectedValue = "0";
        }

        if (!IsPostBack && loggedUser.UserType == "Managerial Staff")
        {
            DataTable staff = new AttendanceLogic().getStaffForAttendance(loggedUser.DepartmentID, loggedUser.AccountID);

            if (staff.Rows.Count > 0)
            {
                Repeater1.DataSource = staff;
                Repeater1.DataBind();
            }
            else
            {
                Response.Redirect("viewattendance.aspx");
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["LoggedUser"];
        AttendanceLogic attendanceLogic = new AttendanceLogic();
        Attendance attendance = new Attendance();

        for (int i = 0; i < Repeater1.Items.Count; i++)
        {
            attendance = attendanceLogic.create(new Attendance(0,
                Convert.ToInt32(((HiddenField)Repeater1.Items[i].FindControl("HiddenFieldStaffID")).Value),
                DateTime.Now,
                DateTime.Now,
                DateTime.Now,
                ((CheckBox)Repeater1.Items[i].FindControl("cbxPresence")).Checked));
        }
        Utility.MsgBox("Attendance for " + DateTime.Now.ToString("dd-MM-yyyy") + " saved successully...!!", this.Page, this, "home.aspx");
    }
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["LoggedUser"];

        DataTable staff = new AttendanceLogic().getStaffForAttendance(Convert.ToInt32(ddlDepartment.SelectedValue), loggedUser.AccountID);
        if (staff.Rows.Count > 0)
        {
            lblMarked.Visible = false;
            staffRecordPlaceHolder.Visible = true;
            Repeater1.DataSource = staff;
            Repeater1.DataBind();
        }
        else
        {
            lblMarked.Visible = true;
            staffRecordPlaceHolder.Visible = false;
        }
    }
}