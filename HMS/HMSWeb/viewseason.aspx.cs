﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using WebUtility;

public partial class viewseason : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var User = Session["loggedUser"];
        if (!(User is Staff))
            Response.Redirect("login.aspx");

        Staff loggedUser = (Staff)Session["loggedUser"];
        if (loggedUser == null || loggedUser.UserType != "Hotel Admin")
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            Season seasonobject = new SeasonLogic().selectById(Convert.ToInt32(Request.QueryString["ID"]));
            txtSeasonName.Text = seasonobject.Name;
            txtFromDate.Text = (seasonobject.FromDate).Date.ToString("dd-MM-yyyy");
            txtToDate.Text = (seasonobject.ToDate).Date.ToString("dd-MM-yyyy");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        Season seasonobject = new Season(Convert.ToInt32(Request.QueryString["ID"]),
            txtSeasonName.Text,
            Convert.ToDateTime(txtFromDate.Text),
            Convert.ToDateTime(txtToDate.Text),
            loggedUser.AccountID);

        if (new SeasonLogic().update(seasonobject) == 1)
        {
            Utility.MsgBox("Season details updated successfully...!!", this.Page, this, "searchseason.aspx");
        }
        else
        {
            Utility.MsgBox("Error: Season updation failed...!!", this.Page, this, "searchseason.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}