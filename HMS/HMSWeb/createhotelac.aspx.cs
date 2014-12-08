using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using BusinessLogic;

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

        AccountLogic accountlogic = new AccountLogic();
        Account accountobject = accountlogic.create(newaccount);

        if (accountobject != null)
        {
            Staff staffobj = new Staff(0,
                txtName.Text,
                txtEmail.Text,
                Convert.ToString(accountobject.Phone),
                txtUsername.Text,                           //to be modified in future to email id
                txtPassword.Text,
                "HotelAdmin",
                "Admin",
                Convert.ToDateTime(txtDOB.Text),
                System.DateTime.Now,
                Convert.ToInt32(txtSalary.Text),
                true,
                0,
                accountobject.AccountID);

            StaffLogic stafflogic = new StaffLogic();
            Staff staffobject = stafflogic.create(staffobj);

            if(staffobject!=null)
            {
                Response.Redirect("home.aspx");
            }
            else
            {
                accountlogic.delete(accountobject.AccountID);
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}