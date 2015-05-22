using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class placeorder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Customer loggedUser = null;
        int ServiceID = 0;
        try
        {
            loggedUser = (Customer)Session["loggedUser"];
            if (loggedUser == null)
            {
                Response.Redirect("login.aspx?url=servicehome.aspx");
            }
            ServiceID = Convert.ToInt32(Request["ID"]);
        }
        catch (InvalidCastException)
        {
            Response.Redirect("login.aspx");
        }
        if (ServiceID == 0) Response.Redirect("servicehome.aspx");

        Service RequestedService = new ServiceLogic().selectById(ServiceID);
        lblPrice.Text = RequestedService.Rate.ToString();
        lblProductName.Text = RequestedService.Name;
        lblServiceName.Text = RequestedService.Name;
        lblServiceType.Text = new ServiceTypeLogic().selectById(RequestedService.ServiceTypeID).Name;
        imgService.ImageUrl = RequestedService.Image;
    }

    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        
    }
    
    protected void btnOrderNow_Click(object sender, EventArgs e)
    {
        new ServiceRequestLogic().create(new ServiceRequest(0,
            Convert.ToInt32(Request["ID"]),
            new CustomerLogic().getCurruntBooking((((Customer)Session["loggedUser"]).CustomerID)).BookingID,
            DateTime.Now,
            DateTime.Now,
            "Pending",
            txtCustomerRemarks.Text,
            "",
            0,
            Convert.ToInt32(txtQuantity.Text)));
        Response.Redirect("services.aspx?ID=" + Request["Type"]);
    }
}