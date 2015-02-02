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

public partial class createseason : System.Web.UI.Page
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
            DataTable roomTypes = roomTypeLogic.selectAll(loggedUser.AccountID);

            for (int i = 0; i < roomTypes.Rows.Count; i++)
            {
                seasonRoomLogic.create(new SeasonRoom(0,
                    seasonobject.SeasonID, Convert.ToInt32(roomTypes.Rows[i]["RoomTypeID"]),
                    0, 0, 0, 0));
            }

            Response.Redirect("home.aspx");
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