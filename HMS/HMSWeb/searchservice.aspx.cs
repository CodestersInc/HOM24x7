﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class searchservice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var User = Session["loggedUser"];
        if (!(User is Staff))
            Response.Redirect("login.aspx");
        Staff loggedUser = (Staff)User;

        if (loggedUser == null)
        {
            Response.Redirect("login.aspx?url=" + Request.Url);
        }
        if (loggedUser.UserType != "Hotel Admin")
        {
            Response.Redirect("home.aspx");
        }
        if (!IsPostBack)
        {
            Repeater1.DataSource = new ServiceLogic().search("", loggedUser.AccountID);
            Repeater1.DataBind();
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            ServiceLogic serviceLogic = new ServiceLogic();
            serviceLogic.delete(Convert.ToInt32(e.CommandArgument));
            Staff loggeduser = (Staff)Session["loggeduser"];

            searchResultArea.Visible = true;
            Repeater1.DataSource = serviceLogic.search("", loggeduser.AccountID);
            Repeater1.DataBind();
        }
    }
}