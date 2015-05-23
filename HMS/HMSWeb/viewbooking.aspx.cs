using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class viewbooking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        if (loggedUser == null)
        {
            Response.Redirect("login.aspx?url=" + Request.Url);
        }
        if (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff")
        {
            Response.Redirect("home.aspx");
        }

        if (!IsPostBack)
        {
            StaffLogic staffLogic = new StaffLogic();
            RoomTypeLogic roomTypeLogic = new RoomTypeLogic();

            //Fill ddlRoomType
            ddlRoomType.DataSource = roomTypeLogic.selectAll(loggedUser.AccountID);
            ddlRoomType.DataValueField = "RoomTypeID";
            ddlRoomType.DataTextField = "Name";
            ddlRoomType.DataBind();
            //ddlRoomType_SelectedIndexChange(sender, null);

            //Fill ddlApprover
            ddlApprover.DataSource = staffLogic.getReceptionManager(loggedUser.AccountID);
            ddlApprover.DataValueField = "StaffID";
            ddlApprover.DataTextField = "Name";
            ddlApprover.DataBind();

            //Fill ddlReceiver
            ddlReceiver.DataSource = staffLogic.getReceptionStaff(loggedUser.AccountID);
            ddlReceiver.DataValueField = "StaffID";
            ddlReceiver.DataTextField = "Name";
            ddlReceiver.DataBind();

            Booking booking = new BookingLogic().selectById(Convert.ToInt32(Request.QueryString["ID"]));
            Room room = new RoomLogic().selectById(booking.RoomID);

            ddlRoomType.SelectedValue = room.RoomTypeID.ToString();            
            txtNoOfPersons.Text = booking.NumberOfPersons.ToString();
            txtCheckInDate.Text = booking.CheckInDate.ToString("dd-MM-yyyy");
            txtPlannedCheckoutDate.Text = booking.PlannedCheckOutDate.ToString("dd-MM-yyyy");
            txtCheckoutDate.Text = booking.CheckOutDate.ToString("dd-MM-yyyy");
            ddlStatus.SelectedValue = booking.Status;
            txtCustomerName.Text = new CustomerLogic().selectById(booking.CustomerID).Name;
            ddlApprover.SelectedValue = booking.ApproverID.ToString();
            ddlReceiver.SelectedValue = booking.ReceiverID.ToString();
            txtStaffRemarks.Text = booking.StaffRemarks;
            txtCustomerRemarks.Text = booking.CustomerRemarks;
            txtRoomRates.Text = booking.RoomRate.ToString();
            txtPaidAmount.Text = booking.PaidAmount.ToString();
            ddlPaymentMode.SelectedValue = booking.PaymentMode.ToString();
            txtChequeNumber.Text = booking.ChequeNo.ToString();
            txtBankName.Text = booking.BankName;
            ViewState["CustomerID"] = booking.CustomerID;

            //Fill ddlFloor and ddlRoom
            ddlRoomType_SelectedIndexChange(sender, null);
            ddlRoom.SelectedValue = booking.RoomID.ToString();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (createNewCustomerPlaceHolder.Visible == true)
        {
            Customer newCustomer = new CustomerLogic().create(new Customer(0,
            DateTime.Now.Date,
            txtCustomerName.Text,
            txtCustomerEmail.Text,
            txtCustomerPhone.Text,
            WebUtility.Utility.GetSHA512Hash(txtCustomerEmail.Text),
            WebUtility.Utility.GetSHA512Hash(txtCustomerPassword.Text),
            true,
            ((Staff)Session["loggedUser"]).AccountID));
            if (newCustomer == null)
            {
                Response.Redirect("ErrorPage500");
            }
            ViewState["CustomerID"] = newCustomer.CustomerID;
        }

        Booking booking = new Booking(Convert.ToInt32(Request.QueryString["ID"]),
            Convert.ToInt32(ddlRoom.SelectedValue),
            Convert.ToInt32(txtNoOfPersons.Text),
            Convert.ToDateTime(txtCheckInDate.Text),
            Convert.ToDateTime(txtPlannedCheckoutDate.Text),
            Convert.ToDateTime(txtCheckoutDate.Text),
            ddlStatus.SelectedValue,
            Convert.ToDouble(txtPaidAmount.Text),
            Convert.ToInt32(ViewState["CustomerID"]),
            Convert.ToInt32(ddlApprover.SelectedValue),
            Convert.ToInt32(ddlReceiver.SelectedValue),
            txtStaffRemarks.Text,
            txtCustomerRemarks.Text,
            Convert.ToDouble(txtRoomRates.Text),
            ddlPaymentMode.SelectedValue,
            (txtChequeNumber.Text.Equals("")) ? 0 : Convert.ToInt32(txtChequeNumber.Text),
            txtBankName.Text,
            0);

        if (new BookingLogic().update(booking) == 1)
        {
            Response.Redirect("searchbooking.aspx");
        }
        else
        {
            Response.Redirect("ErrorPage500.html");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("searchbooking.aspx");
    }

    protected void ddlRoomType_SelectedIndexChange(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        ddlFloor.DataSource = new FloorLogic().getFloorsForRoomType(Convert.ToInt32(ddlRoomType.SelectedValue), ((Staff)Session["loggedUser"]).AccountID);
        ddlFloor.DataValueField = "FloorID";
        ddlFloor.DataTextField = "FloorNumber";
        ddlFloor.DataBind();
        ddlFloor_SelectedIndexChanged(sender, null);

        txtRoomRates.Text = (new SeasonRoomLogic().fetchCurrentRoomRate(Convert.ToInt32(ddlRoomType.SelectedValue), loggedUser.AccountID)).ToString();
    }

    protected void ddlFloor_SelectedIndexChanged(object sender, EventArgs e)
    {
        Booking booking = new BookingLogic().selectById(Convert.ToInt32(Request.QueryString["ID"]));
        Room room = new RoomLogic().selectById(booking.RoomID);

        DataTable dt = new RoomLogic().getFilteredRooms(Convert.ToInt32(ddlRoomType.SelectedValue), Convert.ToInt32(ddlFloor.SelectedValue), Convert.ToDateTime(txtCheckInDate.Text), Convert.ToDateTime(txtPlannedCheckoutDate.Text));
        dt.Rows.Add(room.RoomID, room.RoomNumber);
        ddlRoom.DataSource = dt;
        ddlRoom.DataValueField = "RoomID";
        ddlRoom.DataTextField = "RoomNumber";
        ddlRoom.DataBind();        
    }

    protected void btnCustomerCreate_Click(object sender, EventArgs e)
    {
        createNewCustomerPlaceHolder.Visible = true;
        customerNameButtonsPlaceHolder.Visible = false;
    }

    protected void btnCustomerSearch_Click(object sender, EventArgs e)
    {
        customerNameButtonsPlaceHolder.Visible = false;

        Staff loggedUser = (Staff)Session["loggedUser"];

        customerSearchResultPlaceHolder.Visible = true;
        CustomerSearchResult.DataSource = new CustomerLogic().search(txtCustomerName.Text, loggedUser.AccountID);
        CustomerSearchResult.DataBind();
    }

    protected void CustomerSearchResult_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int CustomerID = Convert.ToInt32(e.CommandArgument.ToString());
        ViewState["CustomerID"] = CustomerID;

        txtCustomerName.Text = new CustomerLogic().selectById(CustomerID).Name;
        customerSearchResultPlaceHolder.Visible = false;
    }
}