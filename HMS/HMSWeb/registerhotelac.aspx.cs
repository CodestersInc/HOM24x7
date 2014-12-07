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
        Staff loggedUser = (Staff)Session["LoggedUser"];
        if (loggedUser !=null || Session["UserType"] != "HotelAdmin")
        {
            Response.Redirect("login.aspx");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        Account accountobj = new Account(0,
            txtCompany.Text,
            txtContact.Text,
            txtAccountEmail.Text,
            Convert.ToInt64(txtAccountPhone.Text),
            txtAddress.Text,
            txtWebsite.Text,
            cbxFeatures.Checked);

        AccountLogic accountlogic = new AccountLogic();
        int createAccountSuccess = accountlogic.create(accountobj);

        if (createAccountSuccess == 1)
        {
            Account fetchedNewAccount = accountlogic.fetchFromModel(accountobj);

            AppUser appuserobj = new AppUser(0, txtName.Text,
               txtEmail.Text,
               txtPhone.Text,
               fetchedNewAccount.AccountID,
               txtUsername.Text,
               txtPassword.Text,
               "AccountAdmin");

            AppUserLogic appuserlogic = new AppUserLogic();
            int createAppUserSuccess = appuserlogic.create(appuserobj);
            AppUser fetchedAppUser = appuserlogic.getUserFromUsername(txtUsername.Text);
            if (createAppUserSuccess == 1)
            {

                Staff staffobj = new Staff(0,
                    fetchedAppUser.AppUserID,
                    "AccountAdmin",
                    Convert.ToDateTime(txtDOB.Text),
                    System.DateTime.Now,
                    Convert.ToInt32(txtSalary.Text),
                    ddlSalaryFrequency.SelectedValue.ToString(),
                    true,
                    0);

                StaffLogic stafflogic = new StaffLogic();
                stafflogic.create(staffobj);
                Response.Redirect("hahome.aspx");
            }
            else
            {
                appuserlogic.delete(fetchedAppUser.AppUserID);
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("sahome.aspx");
    }
}