using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;


public partial class request_a_service : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Customer loggedUser = null;
        try
        {
            loggedUser = (Customer)Session["loggedUser"];
            if (loggedUser == null)
            {
                Response.Redirect("login.aspx");
            }
        }
        catch(InvalidCastException)
        {
            Response.Redirect("login.aspx");
        }
        
        ServiceTypeLogic serviceTypeLogic = new ServiceTypeLogic();
        ServiceLogic serviceLogic = new ServiceLogic();

        DataTable ServiceTypeDataTable = serviceTypeLogic.selectAll(loggedUser.AccountID);
        ServiceTypeRepeater.DataSource = ServiceTypeDataTable;
        ServiceTypeRepeater.DataBind();
    }
    protected void ServiceLinkButton_Click(object sender, EventArgs e)
    {
        
    }

    protected void ServiceTypeRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Repeater ServiceRepeater = (Repeater)e.Item.FindControl("ServiceRepeater");
            ServiceRepeater.DataSource = new ServiceLogic().selectAll(Convert.ToInt32(((DataRowView)e.Item.DataItem)["ServiceTypeID"]));
            ServiceRepeater.DataBind();
        }
    }
}