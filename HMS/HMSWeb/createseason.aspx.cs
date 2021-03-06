﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using BusinessLogic;
using WebUtility;

public partial class createseason : System.Web.UI.Page
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
        if (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff")
        {
            Response.Redirect("home.aspx");
        }

        if (!IsPostBack)
        {
            txtFromDate.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
            txtToDate.Text = DateTime.Now.Date.AddDays(1).ToString("dd-MM-yyyy");
            Repeater1.DataSource = new RoomTypeLogic().selectAll(loggedUser.AccountID);
            Repeater1.DataBind();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        SeasonLogic seasonLogic = new SeasonLogic();
        RoomTypeLogic roomTypeLogic = new RoomTypeLogic();
        SeasonRoomLogic seasonRoomLogic = new SeasonRoomLogic();

        Season seasonobject = seasonLogic.create(new Season(0,
            txtSeasonName.Text,
            Convert.ToDateTime(txtFromDate.Text),
            Convert.ToDateTime(txtToDate.Text),
            loggedUser.AccountID));

        if (seasonobject != null)
        {
            SeasonRoomLogic seasonroomlogic = new SeasonRoomLogic();
            
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                seasonroomlogic.create(new SeasonRoom(0,
                    seasonobject.SeasonID,
                    Convert.ToInt32(((HiddenField)Repeater1.Items[i].FindControl("HiddenFieldSeasonID")).Value),
                    Convert.ToSingle(((TextBox)Repeater1.Items[i].FindControl("txtRate")).Text),
                    Convert.ToSingle(((TextBox)Repeater1.Items[i].FindControl("txtAgentDiscount")).Text),
                    Convert.ToSingle(((TextBox)Repeater1.Items[i].FindControl("txtMaxDiscount")).Text),
                    Convert.ToSingle(((TextBox)Repeater1.Items[i].FindControl("txtWebsiteRate")).Text)));
            }
            Utility.MsgBox("Season created successfully...!!", this.Page, this, "home.aspx");            
        }
        else
        {
            Utility.MsgBox("Error: Season creation failed...!!", this.Page, this, "createseason.aspx");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}