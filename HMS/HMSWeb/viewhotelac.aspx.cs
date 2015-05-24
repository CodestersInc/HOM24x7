using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class viewhotelac : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var User = Session["loggedUser"];
        if (!(User is SystemAdmin))
            Response.Redirect("login.aspx");
        SystemAdmin loggedUser = (SystemAdmin)User;
        if (loggedUser == null || Session["UserType"].ToString() != "SystemAdmin")
        {
            Response.Redirect("login.aspx");           
        }

        if (!IsPostBack)
        {
            Account accountobj = new AccountLogic().selectById(Convert.ToInt32(Request.QueryString["ID"]));
            txtCompany.Text = accountobj.Company;
            txtContact.Text = accountobj.ContactPerson;
            txtEmail.Text = accountobj.Email;
            txtPhone.Text = accountobj.Phone.ToString();
            txtAddress.Text = accountobj.Address;
            txtWebsite.Text = accountobj.Website;
            String features = accountobj.Features;

            cbxOnlineBooking.Checked = (features.Contains("#Online Booking#")) ? true : false;
            cbxPayroll.Checked = (features.Contains("#Payroll#")) ? true : false;
            cbxService.Checked = (features.Contains("#Service#")) ? true : false;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        String features = ((cbxOnlineBooking.Checked) ? "#Online Booking#" : "") +
            ((cbxPayroll.Checked) ? "#Payroll#" : "") +
            ((cbxService.Checked) ? "#Service#" : "");

        Account accountobj = new Account(Convert.ToInt32(Request.QueryString["ID"]),
            txtCompany.Text,
            txtContact.Text,
            txtEmail.Text,
            txtPhone.Text,
            txtAddress.Text,
            txtWebsite.Text,
            features);

        if (new AccountLogic().update(accountobj) == 1)
        {
            Response.Redirect("searchhotelac.aspx");
        }
        else
        {
            Response.Redirect("ErrorPage500.html");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("searchhotelac.aspx");
    }
}