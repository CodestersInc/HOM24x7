﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class receptionbooking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void rptrRooms_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        HiddenField x = (HiddenField)e.Item.FindControl("hdnRoomID");
        //x.Value

        Repeater rptrBookings = (Repeater)e.Item.FindControl("rptrBookings");

        //rptrBookings.DataSource = 

    }
}