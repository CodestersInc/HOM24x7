﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using WebUtility;

public partial class resetpassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtPassword.Text.Equals(txtConfirmPassword.Text))
        {
            String HashedPassword = Utility.GetSHA512Hash(txtPassword.Text);

            if (new StaffLogic().resetPassword(Convert.ToString(Request.QueryString["attr1"]), Convert.ToString(Request.QueryString["attr2"]), HashedPassword) == 1)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Utility.MsgBox("Error: Password reset failed...!!",this.Page,this,"login.aspx");
            }
        }
        else
        {
            errorMessagePlaceHolder.Visible = true;
        }
    }
}