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

public partial class ServiceHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var User = Session["loggedUser"];
        if (!(User is Customer))
            Response.Redirect("login.aspx");
        Customer loggedUser = null;
        try
        {
            loggedUser = (Customer)Session["loggedUser"];
            if (loggedUser == null)
            {
                Response.Redirect("login.aspx?url=servicehome.aspx");
            }
        }
        catch (InvalidCastException)
        {
            Response.Redirect("login.aspx");
        }     
       
        ServiceTypeRepeater.DataSource = new ServiceTypeLogic().selectAll(loggedUser.AccountID);
        ServiceTypeRepeater.DataBind();
    }
}