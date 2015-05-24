using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;

public partial class viewroomtype : System.Web.UI.Page
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
            RoomType roomtypeobj = new RoomTypeLogic().selectById(Convert.ToInt32(Request.QueryString["ID"]));
            txtRoomTypeName.Text = roomtypeobj.Name;
            txtDescription.Text = roomtypeobj.Description;
            Image1.ImageUrl = roomtypeobj.Photo;

            DataTable dt = new SeasonRoomLogic().getAllSeasonRooms(roomtypeobj.RoomTypeID, loggedUser.AccountID);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        RoomTypeLogic roomTypeLogic = new RoomTypeLogic();

        String ticks = DateTime.Now.Ticks.ToString();
        String staleImagePath = roomTypeLogic.selectById(Convert.ToInt32(Request.QueryString["ID"])).Photo;
        
        RoomType roomtypeobj = new RoomType();
        roomtypeobj.RoomTypeID=Convert.ToInt32(Request.QueryString["ID"]);
        roomtypeobj.Name=txtRoomTypeName.Text;
        roomtypeobj.Description=txtDescription.Text;
        if(FileUpload1.HasFile)
        {
            roomtypeobj.Photo="img/roomtype/" + ticks + FileUpload1.FileName;
        }
        else
        {
            roomtypeobj.Photo = staleImagePath;
        }
        roomtypeobj.AccountID = loggedUser.AccountID;

        if (new RoomTypeLogic().update(roomtypeobj) == 1)
        {
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("img/roomtype/" + ticks + FileUpload1.FileName));
                try
                {
                    File.Delete(staleImagePath);
                }
                catch (Exception)
                {
                    //for now just do nothing this case may come in place if therre is 
                    //no file to be deleted or the path is ""
                }
            }

            SeasonRoomLogic seasonRoomLogic = new SeasonRoomLogic();

            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                seasonRoomLogic.update(new SeasonRoom(Convert.ToInt32(((HiddenField)Repeater1.Items[i].FindControl("HiddenFieldSeasonRoomID")).Value),
                        Convert.ToInt32(((HiddenField)Repeater1.Items[i].FindControl("HiddenFieldSeasonID")).Value),
                        roomtypeobj.RoomTypeID,
                        Convert.ToSingle(((TextBox)Repeater1.Items[i].FindControl("txtRate")).Text),
                        Convert.ToSingle(((TextBox)Repeater1.Items[i].FindControl("txtAgentDiscount")).Text),
                        Convert.ToSingle(((TextBox)Repeater1.Items[i].FindControl("txtMaxDiscount")).Text),
                        Convert.ToSingle(((TextBox)Repeater1.Items[i].FindControl("txtWebsiteRate")).Text)));
            }

            Response.Redirect("searchroomtype.aspx");
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