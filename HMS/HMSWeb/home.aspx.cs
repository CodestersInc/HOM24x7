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

        Staff loggedUser = (Staff)Session["loggedUser"];

        if (loggedUser == null)
        {
            Response.Redirect("login.aspx?url=" + Request.Url);
        }
        if (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff")
        {
            Response.Redirect("home.aspx");
        }

        if (!IsPostBack)
        {
            statisticsPlaceHolder.Visible = true;

            DataTable dt = new StaffLogic().selectAll(loggedUser.AccountID);
            lblStaffMembers.Text = dt.Rows.Count.ToString();

            DataTable dt1 = new DepartmentLogic().selectAll(loggedUser.AccountID);
            lblDepartments.Text = dt1.Rows.Count.ToString();

            DataTable dt2 = new RoomLogic().selectAll(loggedUser.AccountID);
            lblRooms.Text = dt2.Rows.Count.ToString();      
        }        
    }
}