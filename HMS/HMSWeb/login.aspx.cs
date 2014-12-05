using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            errorMessagePlaceHolder.Visible = false;
        
    }

    protected void staffLogger(AppUser logger)
    {
        StaffLogic staffLogic = new StaffLogic();
        Staff loggerStaff = staffLogic.selectByAppUserId(logger.AppUserID);
        Session.Add("Staff", loggerStaff);
        switch (loggerStaff.Designation)
        {
            case "Maintainance Staff":
                Response.Redirect("hahome.aspx");
                break;
            case "Department Manager":
                Response.Redirect("hahome.aspx");
                break;
            case "House keeping":
                Response.Redirect("hkhome.aspx");
                break;
            case "Receptionist":
                Response.Redirect("rehome.aspx");
                break;
            case "AccountAdmin":
                Response.Redirect("hahome.aspx");
                break;
            default:
                Response.Redirect("ErrorPage500.html");
                break;
        }
    }

    protected void customerLogger(AppUser logger)
    {
        CustomerLogic customerLogic = new CustomerLogic();
        Customer loggerCustomer = customerLogic.selectByAppuserID(logger.AppUserID);
        Session.Add("Customer", loggerCustomer);
        Response.Redirect("regcusthome.aspx");
    }

    protected void systemAdminLogger(AppUser logger)
    {
        Response.Redirect("sahome.aspx");
    }

    protected void accounAdminLogger(AppUser logger)
    {
        staffLogger(logger);
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        AppUserLogic appUserLogic = new AppUserLogic();        
        AppUser logger = appUserLogic.login(txtUsername.Text, txtPassword.Text);
        
        if ( logger!= null)
        {
            Session.Add("AppUser", logger);
            switch(logger.UserType)
            {
                case "Customer":
                    customerLogger(logger);
                    break;
                case "Staff":
                    staffLogger(logger);
                    break;
                case "SystemAdmin":
                    systemAdminLogger(logger);
                    break;
                case "AccountAdmin":
                    accounAdminLogger(logger);
                    break;
                default: Response.Redirect("ErrorPage500.html");
                    break;
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