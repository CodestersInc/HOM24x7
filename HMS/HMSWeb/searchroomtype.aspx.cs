using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class searchroomtype : System.Web.UI.Page
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
        Repeater1.DataSource = new RoomTypeLogic().search(txtRoomTypeName.Text, loggedUser.AccountID);
        Repeater1.DataBind();
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            RoomTypeLogic roomTypeLogic = new RoomTypeLogic();
            roomTypeLogic.delete(Convert.ToInt32(e.CommandArgument));
            Staff loggedUser = (Staff)Session["loggeduser"];
            Repeater1.DataSource = roomTypeLogic.search(txtRoomTypeName.Text, loggedUser.AccountID);
            Repeater1.DataBind();
        }
    }
}