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
        var User = Session["loggedUser"];

        if (!(User is Customer))
            Response.Redirect("login.aspx");
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

        ServiceLogic serviceLogic = new ServiceLogic();

        Service RequestedService = serviceLogic.selectById(ServiceID);
        lblPrice.Text = RequestedService.Rate.ToString();
        lblProductName.Text = RequestedService.Name;
        lblServiceName.Text = RequestedService.Name;
        lblServiceType.Text = new ServiceTypeLogic().selectById(RequestedService.ServiceTypeID).Name;
        imgService.ImageUrl = RequestedService.Image;


        double total = 0;
        lblProductCount.Text = "0";

        if (Request.Cookies["Service"] != null)
        {
            String ServiceCookie = Server.HtmlEncode(Request.Cookies["Service"].Value);
            String UnitCookie = Server.HtmlEncode(Request.Cookies["Unit"].Value);
        
            String[] Services = ServiceCookie.Split(',');
            String[] Units = UnitCookie.Split(',');
            lblProductCount.Text = ServiceCookie.Length.ToString();
            for (int i = 0; i < Services.Length; i++)
            {
                total += serviceLogic.selectById(Convert.ToInt32(Services[i])).Rate * Convert.ToInt32(Units);
            }
        }
        lblCartTotal.Text = total.ToString();
        
    }

    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        if (Server.HtmlEncode(Request.Cookies["Service"].Value) == null)
        {
            Response.Cookies["Service"].Value = Request["ID"];
            Response.Cookies["Unit"].Value = txtQuantity.Text;
        }
        else
        {
            Response.Cookies["Service"].Value = Server.HtmlEncode(Request.Cookies["Service"].Value) + "," + Request["ID"];
            Response.Cookies["Unit"].Value = Server.HtmlEncode(Request.Cookies["Unit"].Value) + "," + txtQuantity.Text;
        }
        Response.Cookies["Service"].Expires = DateTime.Now.AddDays(5);
        Response.Cookies["Unit"].Expires = DateTime.Now.AddDays(5);
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