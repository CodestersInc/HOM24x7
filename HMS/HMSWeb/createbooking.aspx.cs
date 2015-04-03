using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using System.Runtime.Serialization.Json;

public partial class createbooking : System.Web.UI.Page
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

        StaffLogic staffLogic = new StaffLogic();
        RoomTypeLogic roomTypeLogic = new RoomTypeLogic();
        if (!IsPostBack)
        {
            txtCheckInDate.Text = DateTime.Now.Date.ToString();
            txtPlannedCheckoutDate.Text = DateTime.Now.Date.AddDays(1).ToString();
            ddlRoomType.DataSource = roomTypeLogic.selectAll(loggedUser.AccountID);
            ddlRoomType.DataValueField = "RoomTypeID";
            ddlRoomType.DataTextField = "Name";
            ddlRoomType.DataBind();
            ddlRoomType_SelectedIndexChange(sender, null);

            ddlApprover.DataSource = staffLogic.getReceptionManager(loggedUser.AccountID);
            ddlApprover.DataValueField = "StaffID";
            ddlApprover.DataTextField = "Name";
            ddlApprover.DataBind();

            ddlReceiver.DataSource = staffLogic.getReceptionStaff(loggedUser.AccountID);
            ddlReceiver.DataValueField = "StaffID";
            ddlReceiver.DataTextField = "Name";
            ddlReceiver.DataBind();
        }
    }

    protected void ddlRoomType_SelectedIndexChange(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];
        try
        {
            ddlFloor.DataSource = new FloorLogic().getFloorsForRoomType(Convert.ToInt32(ddlRoomType.SelectedValue), ((Staff)Session["loggedUser"]).AccountID);
            ddlFloor.DataValueField = "FloorID";
            ddlFloor.DataTextField = "FloorNumber";
            ddlFloor.DataBind();
            ddlFloor_SelectedIndexChanged(sender, null);

            txtRoomRates.Text = (new SeasonRoomLogic().fetchCurrentRoomRate(Convert.ToInt32(ddlRoomType.SelectedValue), loggedUser.AccountID)).ToString();                 
        }
        catch (FormatException)
        {
            noRoomPlaceHolder.Visible = true;
            createBookingPlaceHolder.Visible = false;
        }

    }

    protected void ddlFloor_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRoom.DataSource = new RoomLogic().getFilteredRooms(Convert.ToInt32(ddlRoomType.SelectedValue), Convert.ToInt32(ddlFloor.SelectedValue));
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

    protected void btnSubmit_Click(object sender, EventArgs e)
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

        Booking bookingObj = new BookingLogic().create(new Booking(0,
            Convert.ToInt32(ddlRoom.SelectedValue),
            Convert.ToInt32(txtNoOfPersons.Text),
            Convert.ToDateTime(txtCheckInDate.Text),
            Convert.ToDateTime(txtPlannedCheckoutDate.Text),
            Convert.ToDateTime(txtPlannedCheckoutDate.Text),
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
            0));

        if (bookingObj == null)
        {
            Response.Redirect("ErrorPage.htm;");
        }
        Response.Redirect("Home.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}