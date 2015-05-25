using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class myservicerequest : System.Web.UI.Page
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
        if (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff" &&  loggedUser.UserType != "Regular Staff")
        {
            Response.Redirect("home.aspx");
        }

        if (!IsPostBack)
        {
            RequestListRepeater.DataSource = new ServiceRequestLogic().getAssignedRequestsOfStaff(loggedUser);
            RequestListRepeater.DataBind();
        }
    }

    protected void RequestListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Done")
        {
            Staff loggedUser = (Staff)Session["loggedUser"];

            ServiceRequestLogic serviceRequestLogic = new ServiceRequestLogic();
            ServiceRequest obj = serviceRequestLogic.selectById(Convert.ToInt32(e.CommandArgument));
            obj.Status = "Delivered";
            serviceRequestLogic.update(obj);

            RequestListRepeater.DataSource = new ServiceRequestLogic().getAssignedRequestsOfStaff(loggedUser);
            RequestListRepeater.DataBind();
        }
    }
}