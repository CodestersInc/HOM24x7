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

public partial class home : System.Web.UI.Page
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

        if (loggedUser.UserType == "Reception Staff")
        {
            Response.Redirect("receptionisthome.aspx");
        }

        if (!IsPostBack)
        {
            statisticsPlaceHolder.Visible = true;

            Account account = new AccountLogic().selectById(loggedUser.AccountID);
            lblHotelName.Text = account.Company;

            DataTable dt1 = new OnlineBookingLogic().selectAll(loggedUser.AccountID);
            lblBookings.Text = dt1.Rows.Count.ToString();

            DataTable dt2 = new CustomerLogic().selectAll(loggedUser.AccountID);
            lblCustomer.Text = dt2.Rows.Count.ToString();

            DataTable dt3 = new StaffLogic().selectAll(loggedUser.AccountID);
            lblStaffMembers.Text = dt3.Rows.Count.ToString();

            DataTable dt4 = new DepartmentLogic().selectAll(loggedUser.AccountID);
            lblDepartments.Text = dt4.Rows.Count.ToString();

            DataTable dt5 = new RoomLogic().selectAll(loggedUser.AccountID);
            lblRooms.Text = dt5.Rows.Count.ToString();

            DataTable dt6 = new ServiceLogic().getAllServices(loggedUser.AccountID);
            lblServices.Text = dt6.Rows.Count.ToString();            
        }        
    }
}