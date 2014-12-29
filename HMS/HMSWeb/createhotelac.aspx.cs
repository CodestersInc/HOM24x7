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

public partial class hacregister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SystemAdmin loggedUser = (SystemAdmin)Session["LoggedUser"];
        if (loggedUser == null || Session["UserType"] != "SystemAdmin")
        {
            Response.Redirect("login.aspx");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Account newaccount = new Account(0,
            txtCompany.Text,
            txtContact.Text,
            txtAccountEmail.Text,
            Convert.ToInt64(txtAccountPhone.Text),
            txtAddress.Text,
            txtWebsite.Text,
            cbxFeatures.Checked);

        Account accountobject = new AccountLogic().create(newaccount);

        if (accountobject != null)
        {
            Staff staffobj = new Staff(0,
                txtName.Text,
                txtEmail.Text,
                Convert.ToString(accountobject.Phone),
                Utility.GetSHA512Hash(txtUsername.Text),                           //to be modified in future to email id
                Utility.GetSHA512Hash(txtPassword.Text),
                "HotelAdmin",
                "Admin",
                Convert.ToDateTime(txtDOB.Text),
                System.DateTime.Now,
                Convert.ToInt32(txtSalary.Text),
                true,
                0,
                accountobject.AccountID);

            Staff staffobject = new StaffLogic().create(staffobj);

            if(staffobject!=null)
            {
                Response.Redirect("home.aspx");
            }
            else
            {
                new AccountLogic().delete(accountobject.AccountID);
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}