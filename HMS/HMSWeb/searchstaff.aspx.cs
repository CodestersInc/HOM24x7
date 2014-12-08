﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class searchstaff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];
        if (loggedUser == null || loggedUser.UserType != "HotelAdmin")
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];
        GridView1.DataSource = new StaffLogic().search(txtName.Text, loggedUser.AccountID);
        GridView1.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.commandname == "remove")
        {
            new stafflogic().delete(convert.toint32(e.commandargument));
            staff loggeduser = (staff)session["loggeduser"];
            gridview1.datasource = new stafflogic().search(txtname.text, loggeduser.accountid);
            gridview1.databind();
        }
    }
}