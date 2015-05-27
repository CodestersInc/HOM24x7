using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using WebUtility;

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

        if (Request.Cookies["Service"] != null && Request.Cookies["Service"] != null)
        {
            String ServiceCookie = Server.HtmlEncode(Request.Cookies["Service"].Value);
            String UnitCookie = Server.HtmlEncode(Request.Cookies["Unit"].Value);

            String[] Services = ServiceCookie.Split(',');
            String[] Units = UnitCookie.Split(',');
            lblProductCount.Text = Services.Length.ToString();
        }
    }

    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["Service"] == null)
        {
            Response.Cookies["Service"].Value = Request["ID"];
            Response.Cookies["Unit"].Value = txtQuantity.Text;
        }
        else
        {
            String[] Services = Request.Cookies["Service"].Value.Split(',');
            String[] Units = Request.Cookies["Unit"].Value.Split(',');
            Boolean flag = false;

            for (int i = 0; i < Services.Length; i++)
            {
                if (Convert.ToInt32(Services[i]) == Convert.ToInt32(Request["ID"]))
                {
                    Units[i] = (Convert.ToInt32(Units[i]) + Convert.ToInt32(txtQuantity.Text)).ToString();
                    flag = true;
                }
            }

            if (flag)
            {
                String newServices = "";
                String newUnits = "";

                for (int i = 0; i < Services.Length; i++)
                {
                    if (newServices == "" || newUnits == "")
                    {
                        newServices = Services[i];
                        newUnits = Units[i];
                    }
                    else
                    {
                        newServices += "," + Services[i];
                        newUnits += "," + Units[i];
                    }
                }
                Response.Cookies["Service"].Value = newServices;
                Response.Cookies["Unit"].Value = newUnits;
            }
            else
            {
                Response.Cookies["Service"].Value = Request.Cookies["Service"].Value + "," + Request["ID"];
                Response.Cookies["Unit"].Value = Request.Cookies["Unit"].Value + "," + txtQuantity.Text;
            }
        }
        Response.Cookies["Service"].Expires = DateTime.Now.AddDays(1);
        Response.Cookies["Unit"].Expires = DateTime.Now.AddDays(1);
        Response.Redirect("services.aspx?ID=" + Request["Type"]);
    }

    protected void btnOrderNow_Click(object sender, EventArgs e)
    {
        new ServiceRequestLogic().create(new ServiceRequest(0,
            Convert.ToInt32(Request["ID"]),
            new CustomerLogic().getCurrentBooking((((Customer)Session["loggedUser"]).CustomerID)).BookingID,
            DateTime.Now,
            DateTime.Now,
            "Pending",
            txtCustomerRemarks.Text,
            "",
            0,
            Convert.ToInt32(txtQuantity.Text)));

        Utility.MsgBox("Service ordered successfully...!!", this.Page, this, "services.aspx?ID=" + Request["Type"]);
    }
}