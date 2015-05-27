using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class receptionisthome : System.Web.UI.Page
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

        if (!IsPostBack)
        {
            //Generate Statistics
            statisticsPlaceHolder.Visible = true;

            Account account = new AccountLogic().selectById(loggedUser.AccountID);
            lblHotelName.Text = account.Company;

            DataTable dt1 = new OnlineBookingLogic().selectAll(loggedUser.AccountID);
            lblBookings.Text = dt1.Rows.Count.ToString();

            DataTable dt2 = new CustomerLogic().selectAll(loggedUser.AccountID);
            lblCustomer.Text = dt2.Rows.Count.ToString();

            DataTable dt3 = new StaffLogic().selectAll(loggedUser.AccountID);
            lblStaffMembers.Text = dt3.Rows.Count.ToString();

            DataTable dt4 = new DepartmentLogic().selectAll(loggedUser.AccountID);
            lblDepartments.Text = dt4.Rows.Count.ToString();

            DataTable dt5 = new RoomLogic().selectAll(loggedUser.AccountID);
            lblRooms.Text = dt5.Rows.Count.ToString();

            DataTable dt6 = new ServiceLogic().getAllServices(loggedUser.AccountID);
            lblServices.Text = dt6.Rows.Count.ToString();

            DataTable dt = new FloorLogic().getFloorsWithPlan(loggedUser.AccountID);
            if (dt.Rows.Count == 0)
            {
                floorNumberPlaceHolder.Visible = false;
                noFloorPlansPH.Visible = true;
            }
            else
            {
                //Fill ddlFloors
                ddlFloor.DataSource = dt;
                ddlFloor.DataValueField = "PlanID";
                ddlFloor.DataTextField = "FloorNumber";
                ddlFloor.DataBind();
            }
        }
    }

    protected void viewPlan_Click(object sender, EventArgs e)
    {
        int planid = Convert.ToInt32(ddlFloor.SelectedValue);

        planCanvasRepeater.DataSource = new FloorPlanLogic().getPlan(planid);
        planCanvasRepeater.DataBind();

        DataTable dt = new PlanComponentLogic().selectAllRoomComponents(planid);

        RoomLogic roomLogic = new RoomLogic();

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string status = roomLogic.selectById(Convert.ToInt32(dt.Rows[i]["RoomID"])).Status;
            string color = null;
            switch (status)
            {
                case "Booked": color = "#607D8B";
                    break;
                case "Empty": color = "#4CAF50";
                    break;
                case "Occupied": color = "#C0CA33";
                    break;
                case "Under Maintenance": color = "#795548";
                    break;
            }
            dt.Rows[i]["PlanComponentStyle"] = dt.Rows[i]["PlanComponentStyle"].ToString().Replace("gray", color);
        }

        roomComponentRepeater.DataSource = dt;
        roomComponentRepeater.DataBind();

        otherComponentRepeater.DataSource = new PlanComponentLogic().selectAllOtherComponents(planid);
        otherComponentRepeater.DataBind();

        statisticsPlaceHolder.Visible = false;
        planPlaceHolder.Visible = true;
    }
}