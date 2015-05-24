using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using WebUtility;
using System.Threading;
using System.Data;

public partial class checkout : System.Web.UI.Page
{
    public static double totalServiceCharge = 0;
    public static double totalRoomCharge = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        var User = Session["loggedUser"];
        Staff loggedUser = null;
        if (!(User is Staff))
            Response.Redirect("login.aspx");

        if (!IsPostBack)
        {
            Booking booking = null;

            if (Convert.ToInt32(Request.QueryString["ID"]) != 0)
            {
                booking = new BookingLogic().selectById(Convert.ToInt32(Request.QueryString["ID"]));

                if (booking.Status != "Checked In")
                {
                    Utility.MsgBox("The user has never checked in", this.Page, this, "searchbooking.aspx");
                }
            }
            else
            {
                Response.Redirect("searchbooking.aspx");
            }

            Customer customer = new CustomerLogic().selectById(booking.CustomerID);
            Room room = new RoomLogic().selectById(booking.RoomID);
            RoomType roomType = new RoomTypeLogic().selectById(room.RoomTypeID);

            lblName.Text = customer.Name;
            lblRoomNumber.Text = room.RoomNumber;
            lblRoomType.Text = roomType.Name;
            lblCheckInDate.Text = booking.CheckInDate.ToString();
            lblCheckOutDate.Text = booking.CheckOutDate.ToString();

            lblBasicRoomCharge.Text = Convert.ToInt32(booking.RoomRate * ((DateTime.Now - booking.CheckInDate).TotalDays)).ToString();
            
            DataTable dt = new ServiceLogic().getServiceTotalForBooking(booking.BookingID);
            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add("Service Charge", "0");
            }
            serviceRepeater.DataSource = dt;
            serviceRepeater.DataBind();

            totalRoomCharge = (Convert.ToDouble(lblBasicRoomCharge.Text) + Convert.ToDouble(txtOtherCharges.Text));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                totalServiceCharge += Convert.ToDouble(dt.Rows[i]["ServiceCharge"].ToString());
            }
            lblTotalAmount.Text = (totalRoomCharge + totalServiceCharge).ToString();
            lblAdvancePaid.Text = booking.PaidAmount.ToString();
            lblPayableAmount.Text = (Convert.ToDouble(lblTotalAmount.Text) - booking.PaidAmount - Convert.ToDouble(txtDiscountedAmount.Text)).ToString();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        totalRoomCharge = (Convert.ToDouble(lblBasicRoomCharge.Text) + Convert.ToDouble(txtOtherCharges.Text));

        lblPayableAmount.Text = (totalRoomCharge
            + totalServiceCharge 
            - Convert.ToDouble(lblAdvancePaid.Text) 
            - Convert.ToDouble(txtDiscountedAmount.Text)).ToString();
        txtOtherCharges.Enabled = false;
        txtDiscountedAmount.Enabled = false;
        btnSubmit.Visible = false;
        btnEdit.Visible = true;
        btnCheckout.Visible = true;
    }
    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        btnEdit.Visible = false;
        btnCheckout.Visible = false;
        btnPrint.Visible = true;

        billSummaryPH.Visible = true;

        bName.Text = lblName.Text;
        bRoomNumber.Text = lblRoomNumber.Text;
        bRoomType.Text = lblRoomType.Text;
        bCheckInDate.Text = lblCheckInDate.Text;
        bCheckOutDate.Text = lblCheckOutDate.Text;
        bRoomCharges.Text = totalRoomCharge.ToString();
        bServiceCharges.Text = totalServiceCharge.ToString();
        bTotalAmount.Text = lblTotalAmount.Text;
        bAmountPaid.Text = lblAdvancePaid.Text;
        bDiscountedAmount.Text = txtDiscountedAmount.Text;
        bPayableAmount.Text = lblPayableAmount.Text;

        checkOutPH.Visible = false;

        BookingLogic bookingLogic = new BookingLogic();
        Booking booking = bookingLogic.selectById(Convert.ToInt32(Request.QueryString["ID"]));
        booking.Status = "Checked Out";
        booking.CheckOutDate = DateTime.Now;

        if (bookingLogic.update(booking) == 1)
        {
            new BillLogic().create(new Bill(0,
                booking.BookingID,
                totalRoomCharge,
                totalServiceCharge,
                Convert.ToDouble(bTotalAmount.Text),
                Convert.ToDouble(bDiscountedAmount.Text),
                Convert.ToDouble(bPayableAmount.Text),
                ddlPaymentMode.SelectedValue,
                txtPaymentDetails.Text));
        }        
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        txtOtherCharges.Enabled = true;
        txtDiscountedAmount.Enabled = true;
        btnSubmit.Visible = true;
        btnEdit.Visible = false;
        btnCheckout.Visible = false;
    }
}