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

public partial class registrestaff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        if (loggedUser == null || loggedUser.UserType != "Hotel Admin")
        {
            Response.Redirect("login.aspx");
        }
        if(!IsPostBack)
        {
            DataTable dt = new DepartmentLogic().selectDistinctDepartment(loggedUser.AccountID);
            dt.Rows.Add(new object[] { "No Department", 0 });
            ddlDepartment.DataSource = dt;
            ddlDepartment.DataValueField = "DepartmentID";
            ddlDepartment.DataTextField = "DepartmentChoices";
            ddlDepartment.DataBind();
        }        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Staff loggedInStaff = (Staff)Session["LoggedUser"];

        DateTime dt = new DateTime();
        if (!DateTime.TryParseExact(txtDOB.Text, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out dt)) 
        {
            dt = DateTime.Today;
        }
        Staff staffobject = new Staff(0,
            txtStaffCode.Text,
            txtName.Text,
            txtEmail.Text,
            txtPhone.Text,
            Utility.GetSHA512Hash(txtUsername.Text),
            Utility.GetSHA512Hash(txtPassword.Text),
            ddlUserType.SelectedValue,
            txtDesignation.Text,
            dt,
            //Convert.ToDateTime(txtDOB.Text),
            System.DateTime.Now,
            Convert.ToInt32(txtSalary.Text),
            cbxIsActive.Checked,
            Convert.ToInt32(ddlDepartment.SelectedValue),
            loggedInStaff.AccountID);

        Staff createdstaff = new StaffLogic().create(staffobject);

        if (createdstaff != null)
        {
            Response.Redirect("home.aspx");
        }
        else
        {
            Response.Redirect("ErrorPage500.html");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}