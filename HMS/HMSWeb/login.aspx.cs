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

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtUsername.Text != null && txtPassword != null)
        {
            SystemAdmin systemAdminLogger = new SystemAdminLogic().login(txtUsername.Text, txtPassword.Text);
            if (systemAdminLogger != null)
            {
                Session.Add("LoggedUser", systemAdminLogger);
                Session.Add("UserType", "SystemAdmin");
                Response.Redirect("home.aspx");
            }
            else
            {
                StaffLogic staffLogic = new StaffLogic();
                Staff staffLogger = staffLogic.login(txtUsername.Text, txtPassword.Text);
                if (staffLogger != null)
                {
                    Session.Add("LoggedUser", staffLogger);
                    Session.Add("UserType", "Staff");
                    Response.Redirect("home.aspx");
                }
                else
                {
                    Customer customerLogger = new CustomerLogic().login(txtUsername.Text, txtPassword.Text);
                    if (customerLogger != null)
                    {
                        Session.Add("LoggedUser", customerLogger);
                        Session.Add("UserType", "Customer");
                        Response.Redirect("home.aspx");
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