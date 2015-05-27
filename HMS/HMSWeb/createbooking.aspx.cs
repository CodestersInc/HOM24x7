using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using System.Runtime.Serialization.Json;
using WebUtility;

public partial class createbooking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var User = Session["loggedUser"];

        if (!(User is Staff))
            Response.Redirect("login.aspx");

        Staff loggedUser = (Staff)User;

        if (loggedUser == null)
        {
            Response.Redirect("login.aspx?url=" + Request.Url);
        }
        if (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff" && loggedUser.UserType != "Reception Staff")
        {
            Response.Redirect("home.aspx");
        }

        if (!IsPostBack)
        {
            StaffLogic staffLogic = new StaffLogic();
            RoomTypeLogic roomTypeLogic = new RoomTypeLogic();

            //Handle online booking conversion request
            if (Convert.ToInt32(Request.QueryString["ID"]) > 0)
            {
                OnlineBookingLogic onlinebookingLogic = new OnlineBookingLogic();
                OnlineBooking onlinebooking = onlinebookingLogic.selectById(Convert.ToInt32(Request.QueryString["ID"]));

                txtCheckInDate.Text = onlinebooking.CheckInDate.ToString("dd-MM-yyyy");
                txtPlannedCheckoutDate.Text = onlinebooking.PlannedCheckOutDate.ToString("dd-MM-yyyy");
                txtNoOfPersons.Text = onlinebooking.NumberOfPersons.ToString();
                txtNoOfPersons.Enabled = false;
                txtCustomerName.Text = new CustomerLogic().selectById(onlinebooking.CustomerID).Name;
                ViewState["CustomerID"] = onlinebooking.CustomerID;
                txtCustomerName.Enabled = false;
                txtRoomRates.Text = onlinebooking.WebsiteRate.ToString();
                txtRoomRates.Enabled = false;
            }
            else //Handle regular booking requests
            {
                txtCheckInDate.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
                txtPlannedCheckoutDate.Text = DateTime.Now.Date.AddDays(1).ToString("dd-MM-yyyy");
            }

            //Handle plan based booking requests
            if (Convert.ToInt32(Request.QueryString["RID"]) > 0)
            {
                Room room = new RoomLogic().selectById(Convert.ToInt32(Request.QueryString["RID"]));

                if (room.Status != "Empty")
                {
                    Utility.MsgBox("Room is currently unavailable...!!", this.Page, this, "receptionisthome.aspx");
                }

                txtRoomType.Text = new RoomTypeLogic().selectById(room.RoomTypeID).Name;
                txtRoomType.Enabled = false;
                txtFloor.Text = new FloorLogic().selectById(room.FloorID).FloorNumber.ToString();
                txtFloor.Enabled = false;
                txtRoomNumber.Text = room.RoomNumber.ToString();
                txtRoomNumber.Enabled = false;

                txtRoomRates.Text = (new SeasonRoomLogic().fetchCurrentRoomRate(room.RoomTypeID, loggedUser.AccountID)).ToString();
                txtRoomRates.Enabled = false;

                ddlDataPH.Visible = false;
                txtDataPH.Visible = true;
            }
            else
            {
                //Fill ddlRoomType
                ddlRoomType.DataSource = roomTypeLogic.selectAll(loggedUser.AccountID);
                ddlRoomType.DataValueField = "RoomTypeID";
                ddlRoomType.DataTextField = "Name";
                ddlRoomType.DataBind();
                ddlRoomType_SelectedIndexChange(sender, null);
            }

            //Fill ddlApprover
            ddlApprover.DataSource = staffLogic.getReceptionManager(loggedUser.AccountID);
            ddlApprover.DataValueField = "StaffID";
            ddlApprover.DataTextField = "Name";
            ddlApprover.DataBind();

            //Fill ddlReeiver
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
        DataTable dt = new RoomLogic().getFilteredRooms(Convert.ToInt32(ddlRoomType.SelectedValue), Convert.ToInt32(ddlFloor.SelectedValue), Convert.ToDateTime(txtCheckInDate.Text), Convert.ToDateTime(txtPlannedCheckoutDate.Text));
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

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

        if (bookingObj != null)
        {
            if (ddlStatus.SelectedValue == "Approved" || ddlStatus.SelectedValue == "Checked In")
            {
                RoomLogic roomlogic = new RoomLogic();
                Room room = roomlogic.selectById(Convert.ToInt32(ddlRoom.SelectedValue));
                if (ddlStatus.SelectedValue == "Approved")
                {
                    room.Status = "Booked";
                }
                if (ddlStatus.SelectedValue == "Checked In")
                {
                    room.Status = "Occupied";
                }
                roomlogic.update(room);
            }

            if (loggedUser.UserType == "Hotel Admin" || loggedUser.UserType == "Managerial Staff")
            {
                Utility.MsgBox("Booking created successfully...!!", this.Page, this, "home.aspx");
            }
            if (loggedUser.UserType == "Reception Staff")
            {
                Utility.MsgBox("Booking created successfully...!!", this.Page, this, "receptionisthome.aspx");
            }
        }
        else
        {
            if (createNewCustomerPlaceHolder.Visible == true)
            {
                new CustomerLogic().delete(Convert.ToInt32(ViewState["CustomerID"]));
            }
            Utility.MsgBox("Error: Booking creation failed...!!", this.Page, this, "createbooking.aspx");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        if (loggedUser.UserType == "Hotel Admin" || loggedUser.UserType == "Managerial Staff")
        {
            Response.Redirect("home.aspx");
        }
        if (loggedUser.UserType == "Reception Staff")
        {
            Response.Redirect("receptionisthome.aspx");
        }
    }
}