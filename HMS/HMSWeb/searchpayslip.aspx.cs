using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using WebUtility;

public partial class searchpayslip : System.Web.UI.Page
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

        if (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff" && loggedUser.UserType != "Regular Staff" && loggedUser.UserType != "Reception Staff")
        {
            Response.Redirect("home.aspx");
        }

        if (!IsPostBack)
        {
            txtFromDate.Text = DateTime.Now.Date.AddMonths(-1).ToString("dd-MM-yyyy");
            txtToDate.Text = DateTime.Now.Date.AddDays(1).ToString("dd-MM-yyyy");

            DataTable dt = new DepartmentLogic().selectDistinctDepartment(loggedUser.AccountID);

            if (loggedUser.UserType == "Hotel Admin")
            {
                dt.Rows.Add("All", 0);
                ddlDepartment.DataSource = dt;
                ddlDepartment.DataValueField = "DepartmentID";
                ddlDepartment.DataTextField = "DepartmentChoices";
                ddlDepartment.DataBind();
                ddlDepartment.SelectedValue = "0";
            }
            if (loggedUser.UserType == "Managerial Staff")
            {
                ddlDepartment.DataSource = dt;
                ddlDepartment.DataValueField = "DepartmentID";
                ddlDepartment.DataTextField = "DepartmentChoices";
                ddlDepartment.DataBind();
                ddlDepartment.SelectedValue = loggedUser.DepartmentID.ToString();
                ddlDepartment.Enabled = false;
            }
            if (loggedUser.UserType == "Regular Staff" || loggedUser.UserType == "Reception Staff")
            {
                ddlDepartmentPlaceHolder.Visible = false;                
            }

            payslipRecordPlaceHolder.Visible = false;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        DataTable data = null;

        if (loggedUser.UserType == "Hotel Admin" || loggedUser.UserType == "Managerial Staff")
        {
            data = new PaySlipLogic().search(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text), Convert.ToInt32(ddlDepartment.SelectedValue), loggedUser.AccountID);
        }

        if (loggedUser.UserType == "Regular Staff" || loggedUser.UserType == "Reception Staff")
        {
            data = new PaySlipLogic().search(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text), Convert.ToInt32(loggedUser.StaffID), "Staff");
        }

        if (data.Rows.Count > 0)
        {
            lblNoPayslips.Visible = false;
            payslipRecordPlaceHolder.Visible = true;

            Repeater1.DataSource = data;
            Repeater1.DataBind();
        }
        else
        {
            lblNoPayslips.Visible = true;
            payslipRecordPlaceHolder.Visible = false;
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        if (e.CommandName == "Remove")
        {
            if (loggedUser.UserType == "Regular Staff" || loggedUser.UserType == "Reception Staff")
            {
                Utility.MsgBox("You do not have the required rights...!!", this.Page, this, "searchpayslip.aspx");
            }
            else
            {
                PaySlipLogic payslipLogic = new PaySlipLogic();
                payslipLogic.delete(Convert.ToInt32(e.CommandArgument));

                Repeater1.DataSource = payslipLogic.search(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text), Convert.ToInt32(ddlDepartment.SelectedValue), loggedUser.AccountID);
                Repeater1.DataBind();
            }            
        }
    }
}