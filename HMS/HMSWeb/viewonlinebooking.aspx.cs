using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using WebUtility;

public partial class viewonlinebooking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        if (loggedUser == null)
        {
            Response.Redirect("login.aspx?url=" + Request.Url);
        }

        if (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff" && loggedUser.UserType != "Reception Staff")
        {
            Response.Redirect("home.aspx");
        }

        if (!IsPostBack)
        {
            DataTable dt = new OnlineBookingLogic().search("", loggedUser.AccountID);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

            if (dt.Rows.Count == 0)
            {
                resultPH.Visible = false;
                noOnlineBookingPH.Visible = true;
            }
        }
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        OnlineBookingLogic onlinebookingLogic = new OnlineBookingLogic();
        Staff loggedUser = (Staff)Session["LoggedUser"];            

        if (e.CommandName == "Remove")
        {           
            onlinebookingLogic.delete(Convert.ToInt32(e.CommandArgument));
            Repeater1.DataSource = onlinebookingLogic.search("", loggedUser.AccountID);
            Repeater1.DataBind();
        }
        if (e.CommandName == "Convert")
        {
            OnlineBooking onlinebooking = new OnlineBookingLogic().selectById(Convert.ToInt32(e.CommandArgument));
            onlinebooking.Status = "Converted";
            onlinebooking.ConverterID = loggedUser.StaffID;

            if (onlinebookingLogic.update(onlinebooking) == 1)
            {
                Response.Redirect("createbooking.aspx?ID=" + e.CommandArgument);
            }
        }
    }
}