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
        try
        {
            errorMessagePlaceHolder.Visible = false;
    }
        catch (Exception ex)
        {
            Response.Redirect("ErrorPage500");
        }

    }

    /*

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
    */

    protected void btnLogin_Click(object sender, EventArgs e)
    {     
        if (txtUsername.Text!=null && txtPassword!=null)
        {
            SystemAdminLogic systemAdminLogic = new SystemAdminLogic();
            SystemAdmin systemAdminLogger = systemAdminLogic.login(txtUsername.Text, txtPassword.Text);
            if(systemAdminLogger!=null)
            {
                Session.Add("LoggedUser", systemAdminLogger);
                //Session.Add("SystemAdmin", systemAdminLogger);
                Session.Add("UserType", "SystemAdmin");
                return;
            }
            else
            {
                StaffLogic staffLogic = new StaffLogic();
                Staff staffLogger = staffLogic.login(txtUsername.Text, txtPassword.Text);
                if (staffLogger != null)
                {
                    Session.Add("LoggedUser", staffLogger);
                    //Session.Add("Staff", staffLogger);
                    Session.Add("UserType", "Staff");
                    return;
                }
                else
                {
                    CustomerLogic customerLogic = new CustomerLogic();
                    Customer customerLogger = customerLogic.login(txtUsername.Text, txtPassword.Text);
                    if (customerLogger != null)
                    {
                        Session.Add("LoggedUser", customerLogger);
                        //Session.Add("Customer", customerLogger);
                        Session.Add("UserType", "Customer");
                        return;
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