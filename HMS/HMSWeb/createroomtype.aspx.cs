using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class createroomtype : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        if (loggedUser == null || loggedUser.UserType != "HotelAdmin")
        {
            Response.Redirect("login.aspx");
        }
        Repeater1.DataSource = new SeasonLogic().selectAll(loggedUser.AccountID);
        Repeater1.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Staff loggedInStaff = (Staff)Session["LoggedUser"];
        String ticks = DateTime.Now.Ticks.ToString();
        RoomTypeLogic roomTypeLogic = new RoomTypeLogic();

        RoomType roomtypeobj = roomTypeLogic.create(new RoomType(0,
            txtRoomTypeName.Text,
            txtDescription.Text,
            "img/roomtype/" + ticks + FileUpload1.FileName,
            loggedInStaff.AccountID));

        if (roomtypeobj != null)
        {
            FileUpload1.SaveAs(Server.MapPath("img/roomtype/" + ticks + FileUpload1.FileName));
            SeasonRoomLogic seasonroomlogic = new SeasonRoomLogic();

            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                seasonroomlogic.create(new SeasonRoom(0,
                    Convert.ToInt32(((HiddenField)Repeater1.Items[i].FindControl("HiddenFieldSeasonID")).Value),
                    roomtypeobj.RoomTypeID,
                    Convert.ToSingle(((TextBox)Repeater1.Items[i].FindControl("txtRate")).Text),
                    Convert.ToSingle(((TextBox)Repeater1.Items[i].FindControl("txtAgentDiscount")).Text),
                    Convert.ToSingle(((TextBox)Repeater1.Items[i].FindControl("txtMaxDiscount")).Text),
                    Convert.ToSingle(((TextBox)Repeater1.Items[i].FindControl("txtWebsiteRate")).Text)));
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
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //if(e.CommandName=)
    }
}