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
using WebUtility;

public partial class createroom : System.Web.UI.Page
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

        if(!IsPostBack)
        {
            //Fill ddlRoomType
            DataTable dt1 = new RoomTypeLogic().selectAll(loggedUser.AccountID);
            ddlRoomType.DataSource = dt1;
            ddlRoomType.DataValueField = "RoomTypeID";
            ddlRoomType.DataTextField = "Name";
            ddlRoomType.DataBind();

            //Fill ddlFloor
            DataTable dt2 = new FloorLogic().selectAll(loggedUser.AccountID);
            ddlFloor.DataSource = dt2;
            ddlFloor.DataValueField = "FloorID";
            ddlFloor.DataTextField = "FloorNumber";
            ddlFloor.DataBind();
        }       
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if(new RoomLogic().create(new Room(0,
            Convert.ToInt32(ddlRoomType.SelectedValue),
            txtRoomNumber.Text,
            Convert.ToInt32(ddlFloor.SelectedValue),
            ddlStatus.SelectedValue))!=null)
        {
            Utility.MsgBox("Room created successfully...!!", this.Page, this, "home.aspx");
        }
        else
        {
            Utility.MsgBox("Error: Room creation failed...!!", this.Page, this, "createroom.aspx");
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
    protected void btnNewFloor_Click(object sender, EventArgs e)
    {
        Response.Redirect("createfloor.aspx");
    }
}