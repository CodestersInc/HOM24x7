using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Globalization;
using WebUtility;

public partial class onlinebooking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int AccountID = Convert.ToInt32(Request["AccountID"]);
        ddlRoomType.DataSource = new RoomTypeLogic().selectAll(AccountID);
        ddlRoomType.DataTextField = "Name";
        ddlRoomType.DataValueField = "RoomTypeID";
        ddlRoomType.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int AccountID = Convert.ToInt32(Request["AccountID"]);
        int RoomTypeID = Convert.ToInt32(ddlRoomType.SelectedValue);
        string[] formats = {"M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt", 
                         "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss", 
                         "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt", 
                         "M/d/yyyy h:mm", "M/d/yyyy h:mm", 
                         "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm"};

        Customer newCustomer = new CustomerLogic().create(new Customer(0,
            DateTime.Now,
            txtName.Text,
            txtEmail.Text,
            txtPhone.Text,
            WebUtility.Utility.GetSHA512Hash(txtEmail.Text),
            WebUtility.Utility.GetSHA512Hash("123"),
            true,
            AccountID));

        if (newCustomer != null)
        {
            DateTime checkInDate = Convert.ToDateTime((DateTime.ParseExact(txtCheckInDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture)).ToString("dd-MM-yyyy"));
            DateTime checkOutDate = Convert.ToDateTime((DateTime.ParseExact(txtCheckOutDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture)).ToString("dd-MM-yyyy"));

            if (new OnlineBookingLogic().create(new OnlineBooking(0,
                RoomTypeID,
                Convert.ToInt32(txtNumberOfPerson.Text),
                checkInDate,
                checkOutDate,
                "Pending",
                newCustomer.CustomerID,
                0,
                new RoomTypeLogic().getWebsiteRate(RoomTypeID, DateTime.Now.Date, AccountID),
                AccountID)) != null)
            {
                txtName.Text = "";
                txtEmail.Text = "";
                txtPhone.Text = "";
                txtNumberOfPerson.Text = "";
                ddlRoomType.SelectedIndex = 0;
                txtCheckInDate.Text = "";
                txtCheckOutDate.Text = "";

                Utility.MsgBox("Reservation Successful...!!", this.Page, this);
            }
        }
    }
}