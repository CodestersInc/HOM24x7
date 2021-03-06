﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using BusinessLogic;
using WebUtility;

partial class registerstaff : System.Web.UI.Page
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
        if(!IsPostBack)
        {
            txtDOB.Text = DateTime.Now.Date.AddYears(-18).ToString("dd-MM-yyyy");            
            //Fill Department List
            DataTable dt = new DepartmentLogic().selectDistinctDepartment(loggedUser.AccountID);
            ddlDepartment.DataSource = dt;
            ddlDepartment.DataValueField = "DepartmentID";
            ddlDepartment.DataTextField = "DepartmentChoices";
            ddlDepartment.DataBind();
        }        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Staff loggedInStaff = (Staff)Session["loggedUser"];

        Staff staffobject = new Staff(0,
            txtStaffCode.Text,
            txtName.Text,
            txtEmail.Text,
            txtPhone.Text,
            Utility.GetSHA512Hash(txtUsername.Text),
            Utility.GetSHA512Hash(txtPassword.Text),
            ddlUserType.SelectedValue,
            txtDesignation.Text,
            Convert.ToDateTime(txtDOB.Text),
            DateTime.Now,
            Convert.ToInt32(txtSalary.Text),
            cbxIsActive.Checked,
            txtBankACNumber.Text,
            Convert.ToInt32(ddlDepartment.SelectedValue),
            loggedInStaff.AccountID);

        Staff createdstaff = new StaffLogic().create(staffobject);

        if (createdstaff != null)
        {
            Utility.MsgBox("Staff created successfully...!!", this.Page, this, "home.aspx");
        }
        else
        {
            Utility.MsgBox("Error: Staff creation failed...!!", this.Page, this, "createstaff.aspx");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
    protected void btnNewDepartment_Click(object sender, EventArgs e)
    {
        Response.Redirect("createdepartment.aspx");
    }
}