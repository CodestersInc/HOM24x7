using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using WebUtility;

public partial class cart : System.Web.UI.Page
{
    public static String[] Services = null;
    public static String[] Units = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        var User = Session["loggedUser"];
        Customer loggedUser = null;

        if (!(User is Customer))
            Response.Redirect("login.aspx");

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

        if (!IsPostBack)
        {
            ServiceLogic serviceLogic = new ServiceLogic();
            ServiceTypeLogic serviceTypeLogic = new ServiceTypeLogic();

            double total = 0;
            int productcount = 0;

            DataTable dt = new DataTable();

            if (Request.Cookies["Service"] != null && Request.Cookies["Unit"] != null)
            {
                String ServiceCookie = Request.Cookies["Service"].Value;
                String UnitCookie = Request.Cookies["Unit"].Value;

                Services = ServiceCookie.Split(',');
                Units = UnitCookie.Split(',');

                productcount = Services.Length;

                Service service = new Service();

                dt.Columns.Add("ServiceID");
                dt.Columns.Add("Image");
                dt.Columns.Add("ProductName");
                dt.Columns.Add("Rate");
                dt.Columns.Add("Unit");
                dt.Columns.Add("Total");

                for (int i = 0; i < Services.Length; i++)
                {
                    service = serviceLogic.selectById(Convert.ToInt32(Services[i]));
                    dt.Rows.Add(service.ServiceID.ToString(), service.Image, service.Name, service.Rate, Units[i], (Convert.ToInt32(Units[i]) * Convert.ToDouble(service.Rate)));
                    total += service.Rate * Convert.ToInt32(Units[i]);
                }
            }
            lblProductCount.Text = productcount.ToString();

            CartItemRepeater.DataSource = dt;
            CartItemRepeater.DataBind();
        }
    }

    protected void btnOrder_Click(object sender, EventArgs e)
    {
        btnOrder.Visible = false;
        btnConfirmOrder.Visible = true;
        cartTotalPlaceHolder.Visible = true;
        String newUnits = "";
        double total = 0;

        for (int i = 0; i < CartItemRepeater.Items.Count; i++)
        {
            Label price = (Label)CartItemRepeater.Items[i].FindControl("lblProductPrice");
            TextBox quantity = (TextBox)CartItemRepeater.Items[i].FindControl("txtQuantity");
            Label subtotal = (Label)CartItemRepeater.Items[i].FindControl("lblProductSubtotal");

            subtotal.Text = (Convert.ToDouble(price.Text) * Convert.ToDouble(quantity.Text)).ToString();
            total += Convert.ToDouble(subtotal.Text);

            if (newUnits == "")
            {
                newUnits = quantity.Text;
            }
            else
            {
                newUnits += "," + quantity.Text;
            }
            quantity.Enabled = false;
        }
        Response.Cookies["Unit"].Value = newUnits;
        lblTotal.Text = total.ToString();
    }

    protected void btnConfirmOrder_Click(object sender, EventArgs e)
    {
        Booking booking = (Booking)Session["Booking"];
        ServiceRequestLogic servicerequestlogic = new ServiceRequestLogic();

        for (int i = 0; i < CartItemRepeater.Items.Count; i++)
        {
            if (servicerequestlogic.create(new ServiceRequest(0,
                Convert.ToInt32(((HiddenField)CartItemRepeater.Items[i].FindControl("HiddenFieldServiceID")).Value),
                booking.BookingID,
                DateTime.Now,
                DateTime.Now,
                "Pending",
                "No Comments",
                "",
                0,
                Convert.ToInt32(((TextBox)CartItemRepeater.Items[i].FindControl("txtQuantity")).Text))) != null)
            {
                Response.Cookies["Service"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Unit"].Expires = DateTime.Now.AddDays(-1);
                Utility.MsgBox("Service order successfully placed...!!",this.Page,this,"servicehome.aspx");
            }
            else
            {
                Utility.MsgBox("Error: Service order failed...!!", this.Page, this, "cart.aspx.aspx");
            }
        }
    }

    protected void CartItemRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            String newServices = "";
            String newUnits = "";
            int id = Convert.ToInt32(e.CommandArgument);

            for (int i = 0; i < Services.Length; i++)
            {
                if (Convert.ToInt32(Services[i]) != id)
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
            }

            if (newServices == "" || newUnits == "")
            {
                Response.Cookies["Service"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Unit"].Expires = DateTime.Now.AddDays(-1);
                Services = null;
                Units = null;
            }
            else
            {
                Response.Cookies["Service"].Value = newServices;
                Response.Cookies["Unit"].Value = newUnits;

                String ServiceCookie = Request.Cookies["Service"].Value;
                String UnitCookie = Request.Cookies["Unit"].Value;

                Services = ServiceCookie.Split(',');
                Units = UnitCookie.Split(',');
            }
            Response.Redirect("cart.aspx");
        }
    }
}