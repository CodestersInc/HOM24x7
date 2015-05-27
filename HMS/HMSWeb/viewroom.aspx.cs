using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using WebUtility;

public partial class viewroom : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var User = Session["loggedUser"];
        if (!(User is Staff))
            Response.Redirect("login.aspx");

        Staff loggedUser = (Staff)Session["LoggedUser"];
        if (loggedUser == null || loggedUser.UserType != "Hotel Admin")
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
            Utility.MsgBox("Room details updated successfully...!!", this.Page, this, "searchroom.aspx");
        }
        else
        {
            Utility.MsgBox("Error: Room updation failed...!!", this.Page, this, "searchroom.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}