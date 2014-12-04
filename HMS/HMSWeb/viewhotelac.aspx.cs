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
        AppUser LoggedAppUser = (AppUser)Session["AppUser"];
        if (LoggedAppUser == null)
        {
            Response.Redirect("login.aspx");
        }
        else if (LoggedAppUser.UserType != "SystemAdmin")
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack) { 
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
        AccountLogic accountlogicobj = new AccountLogic();

        accountobj.AccountID = Convert.ToInt32(Request.QueryString["ID"]);
        accountobj.Company = txtCompany.Text;
        accountobj.ContactPerson = txtContact.Text;
        accountobj.Email = txtEmail.Text;
        accountobj.Phone = Convert.ToInt64(txtPhone.Text);
        accountobj.Address = txtAddress.Text;
        accountobj.Website = txtWebsite.Text;
        accountobj.Features = cbxFeatures.Checked;

        if(accountlogicobj.update(accountobj)==1)
        {
            Response.Redirect("searchhotelac.aspx");
        }
        else
        {
            Response.Redirect("500.html");
        }

    }
}