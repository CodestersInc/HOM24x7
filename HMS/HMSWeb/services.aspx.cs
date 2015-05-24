using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class services : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var User = Session["loggedUser"];
        if (!(User is Customer))
            Response.Redirect("login.aspx");
        Customer loggedUser = null;
        int ServiceTypeID = 0;
        try
        {
            loggedUser = (Customer)Session["loggedUser"];
            if (loggedUser == null)
            {
                Response.Redirect("login.aspx?url=servicehome.aspx");
            }
            ServiceTypeID = Convert.ToInt32(Request["ID"]);
        }
        catch (InvalidCastException)
        {
            Response.Redirect("login.aspx");
        }
        
        ServiceLogic serviceLogic = new ServiceLogic();       
        ServiceRepeater.DataSource = (ServiceTypeID != 0)?serviceLogic.selectAll(ServiceTypeID):serviceLogic.selectAll();
        ServiceRepeater.DataBind();
    }
}