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
        SystemAdmin loggedUser = (SystemAdmin)Session["LoggedUser"];
        if (loggedUser == null || Session["UserType"] != "SystemAdmin")
        {
            Response.Redirect("login.aspx");
        }

        if (!IsPostBack)
        {
            AccountLogic accountlogicobj = new AccountLogic();
            Account accountobj = accountlogicobj.selectById(Convert.ToInt32(Request.QueryString["ID"]));
            txtCompany.Text = accountobj.Company;
            txtContact.Text = accountobj.ContactPerson;
            txtEmail.Text = accountobj.Email;
            txtPhone.Text = accountobj.Phone.ToString();
            txtAddress.Text = accountobj.Address;
            txtWebsite.Text = accountobj.Website;
            cbxFeatures.Checked = accountobj.Features;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Account accountobj = new Account();

        accountobj.AccountID = Convert.ToInt32(Request.QueryString["ID"]);
        accountobj.Company = txtCompany.Text;
        accountobj.ContactPerson = txtContact.Text;
        accountobj.Email = txtEmail.Text;
        accountobj.Phone = Convert.ToInt64(txtPhone.Text);
        accountobj.Address = txtAddress.Text;
        accountobj.Website = txtWebsite.Text;
        accountobj.Features = cbxFeatures.Checked;

        if (new AccountLogic().update(accountobj) == 1)
        {
            Response.Redirect("searchhotelac.aspx");
        }
        else
        {
            Response.Redirect("ErrorPage500.html");
        }
    }
}