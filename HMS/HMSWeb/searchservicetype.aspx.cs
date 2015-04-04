﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class searchservicetype : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];
        if (loggedUser == null)
        {
            Response.Redirect("login.aspx?url=" + Request.Url);
        }
        if (loggedUser.UserType != "Hotel Admin")
        {
            Response.Redirect("home.aspx");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];
        searchResultArea.Visible = true;

        Repeater1.DataSource = new ServiceTypeLogic().search(txtName.Text, loggedUser.AccountID);
        Repeater1.DataBind();
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            ServiceTypeLogic serviceTypeLogic = new ServiceTypeLogic();
            serviceTypeLogic.delete(Convert.ToInt32(e.CommandArgument));
            Staff loggedUser = (Staff)Session["loggeduser"];

            searchResultArea.Visible = true;
            Repeater1.DataSource = serviceTypeLogic.search(txtName.Text, loggedUser.AccountID);
            Repeater1.DataBind();
        }
    }
}