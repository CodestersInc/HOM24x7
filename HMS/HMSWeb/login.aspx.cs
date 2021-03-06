﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using WebUtility;
using System.Net.Mail;
using System.Data;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
        }
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
                Response.Redirect("systemadminhome.aspx");
            }
            else
            {
                StaffLogic staffLogic = new StaffLogic();
                Staff staffLogger = staffLogic.login(HashedUsername, HashedPassword);
                if (staffLogger != null)
                {
                    Account caccount = new AccountLogic().selectById(staffLogger.AccountID);
                    String features = caccount.Features;
                    Session.Add("OnlineBooking", (features.Contains("#Online Booking#")) ? true : false);
                    Session.Add("Payroll", (features.Contains("#Payroll#")) ? true : false);
                    Session.Add("Service", (features.Contains("#Service#")) ? true : false);
                    Session.Add("LoggedUser", staffLogger);
                    Session.Add("UserType", "Staff");

                    if (staffLogger.UserType == "Reception Staff")
                    {
                        Response.Redirect("receptionisthome.aspx");
                    }
                    else
                    {
                        redirectAsNeeded();
                    }                    
                }
                else
                {
                    CustomerLogic customerlogic = new CustomerLogic();
                    Customer customerLogger = customerlogic.login(HashedUsername, HashedPassword);

                    if (customerLogger != null)
                    {
                        Session.Add("LoggedUser", customerLogger);
                        Session.Add("UserType", "Customer");

                        Booking booking = customerlogic.hasBookingNow(customerLogger.CustomerID, customerLogger.AccountID);
                        if (booking!=null)
                        {
                            Session.Add("Booking",booking);
                            Response.Redirect("servicehome.aspx");
                        }
                        else
                        {
                            Utility.MsgBox("Error: You do not have any bookings as of now...!!", this.Page, this, "login.aspx");
                        }
                    }
                    else
                    {
                        Utility.MsgBox("Error: Invalid username or password", this.Page, this, "login.aspx");
                    }
                }
            }
        }
        else
        {
            Utility.MsgBox("Error: Invalid username or password", this.Page, this, "login.aspx");
        }
    }

    private void redirectAsNeeded()
    {
        String redirectionUrl = Request["url"];

        if (redirectionUrl.Equals("/login.aspx"))
        {
            redirectionUrl = "home.aspx";
        }
        Response.Redirect(redirectionUrl);
    }
}