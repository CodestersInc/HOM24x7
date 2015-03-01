﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using WebUtility;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        errorMessagePlaceHolder.Visible = false;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtUsername.Text != null && txtPassword != null)
        {
            String HashedUsername = Utility.GetSHA512Hash(txtUsername.Text);
            String HashedPassword = Utility.GetSHA512Hash(txtPassword.Text);

            SystemAdmin systemAdminLogger = new SystemAdminLogic().login(HashedUsername, HashedPassword);
            if (systemAdminLogger != null)
            {
                Session.Add("LoggedUser", systemAdminLogger);
                Session.Add("UserType", "SystemAdmin");
                Response.Redirect("home.aspx");
            }
            else
            {
                StaffLogic staffLogic = new StaffLogic();
                Staff staffLogger = staffLogic.login(HashedUsername, HashedPassword);
                if (staffLogger != null)
                {
                    Account caccount = new AccountLogic().selectById(staffLogger.AccountID);
                    String features = caccount.Features;
                    Session.Add("OnlineBooking",(features.Contains("#Online Booking#")) ? true : false);
                    Session.Add("Payroll", (features.Contains("#Payroll#")) ? true : false);
                    Session.Add("Service", (features.Contains("#Service#")) ? true : false);
                    Session.Add("LoggedUser", staffLogger);
                    Session.Add("UserType", "Staff");
                    Response.Redirect("home.aspx");
                }
                else
                {
                    Customer customerLogger = new CustomerLogic().login(HashedUsername, HashedPassword);
                    if (customerLogger != null)
                    {
                        Session.Add("LoggedUser", customerLogger);
                        Session.Add("UserType", "Customer");
                        Response.Redirect("home.aspx");
                    }
                    else
                    {
                        errorMessagePlaceHolder.Visible = true;
                    }
                }
            }
        }
        else
        {
            errorMessagePlaceHolder.Visible = true;
        }
    }

    protected void forgotPassword(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
}