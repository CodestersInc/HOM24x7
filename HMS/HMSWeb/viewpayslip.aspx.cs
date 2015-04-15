using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class viewpayslip : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];
        if (loggedUser == null || (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff"))
        {
            Response.Redirect("login.aspx?url=" + Request.Url);
        }
        if (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff")
        {
            Response.Redirect("home.aspx");
        }
        if (!IsPostBack)
        {
            staffInfoRepeater.DataSource = new StaffLogic().getStaffMember(Convert.ToInt32(Request.QueryString["ID"]));
            staffInfoRepeater.DataBind();

            payrollInfoRepeater.DataSource = new StaffLogic().getStaffMember(Convert.ToInt32(Request.QueryString["ID"]));
            payrollInfoRepeater.DataBind();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("createpayslip.aspx");
    }
}