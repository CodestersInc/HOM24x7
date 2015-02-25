﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class viewroom : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["LoggedUser"];
        if (loggedUser == null || loggedUser.UserType != "HotelAdmin")
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            DataTable roomTypeList = new RoomTypeLogic().selectAll(loggedUser.AccountID);
            ddlRoomType.DataSource = roomTypeList;
            ddlRoomType.DataValueField = "RoomTypeID";
            ddlRoomType.DataTextField = "Name";
            ddlRoomType.DataBind();

            DataTable floorList = new FloorLogic().selectAll(loggedUser.AccountID);
            ddlFloor.DataSource = floorList;
            ddlFloor.DataValueField = "FloorID";
            ddlFloor.DataTextField = "FloorNumber";
            ddlFloor.DataBind();

            Room roomObj = new RoomLogic().selectById(Convert.ToInt32(Request.QueryString["ID"]));
            txtRoomNumber.Text = roomObj.RoomNumber;
            ddlRoomType.SelectedValue = roomObj.RoomTypeID.ToString();
            ddlFloor.SelectedValue = roomObj.FloorID.ToString();
            ddlStatus.SelectedValue = roomObj.Status;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (new RoomLogic().update(new Room(Convert.ToInt32(Request.QueryString["ID"]),
            Convert.ToInt32(ddlRoomType.SelectedValue),
            txtRoomNumber.Text,
            Convert.ToInt32(ddlFloor.SelectedValue),
            ddlStatus.SelectedValue)) == 1)
        {
            Response.Redirect("searchroom.aspx");
        }
        else
        {
            Response.Redirect("ErrorPage500.html");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}