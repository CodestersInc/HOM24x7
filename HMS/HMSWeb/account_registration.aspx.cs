using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class AccountRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        AccountLogic accountLogic = new AccountLogic();

        long phone = Convert.ToInt64(txtPhone.Text);
        Boolean feature = chkBoxFullPackage.Checked;
        
        int addComplete = accountLogic.create(new Account(0, txtCompany.Text,txtContactPerson.Text, txtEmail.Text, phone, txtAdress.Text, txtWebsite.Text, feature));
        
        if (addComplete == 1)
        {
            /*on successfull addition of Account*/
            Response.Redirect("account_register_success.aspx");
        }
        else
        {
            /*on failure of adding Account*/
            Response.Redirect("account_register_error.aspx");
        }
    }
}