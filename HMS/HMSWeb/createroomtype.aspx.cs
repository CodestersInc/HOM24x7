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
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Staff loggedInStaff = (Staff)Session["LoggedUser"];
        String ticks = DateTime.Now.Ticks.ToString();
        
        RoomType roomtypeobj = new RoomTypeLogic().create(new RoomType(0,
            txtRoomTypeName.Text,
            txtDescription.Text,
            "img/roomtype/" + ticks + FileUpload1.FileName,
            loggedInStaff.AccountID));

        if (roomtypeobj != null)
        {
            FileUpload1.SaveAs(Server.MapPath("img/roomtype/" + ticks + FileUpload1.FileName));
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