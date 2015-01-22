using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class viewroomtype : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];
        if (loggedUser == null || loggedUser.UserType != "HotelAdmin")
        {
            Response.Redirect("login.aspx");
        }

        if (!IsPostBack)
        {
            RoomType roomtypeobj = new RoomTypeLogic().selectById(Convert.ToInt32(Request.QueryString["ID"]));
            txtRoomTypeName.Text = roomtypeobj.Name;
            txtDescription.Text = roomtypeobj.Description;
            Image1.ImageUrl = roomtypeobj.Photo;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        String ticks = DateTime.Now.Ticks.ToString();
        
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
            roomtypeobj.Photo = new RoomTypeLogic().selectById(Convert.ToInt32(Request.QueryString["ID"])).Photo;
        }
        roomtypeobj.AccountID = loggedUser.AccountID;
            
        if (new RoomTypeLogic().update(roomtypeobj) == 1)
        {
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("img/roomtype/" + ticks + FileUpload1.FileName));
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