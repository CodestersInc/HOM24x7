using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoggedUser"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            if (Session["UserType"].ToString() == "SystemAdmin")
            {
                homePlaceHolder.Visible = true;
                accountsPlaceHolder.Visible = true;
                SystemAdmin systemAdminObj = (SystemAdmin)Session["LoggedUser"];
                lblUsername.Text = systemAdminObj.Name;
            }
            else
            {
                if (Session["UserType"].ToString() == "Staff")
                {
                    homePlaceHolder.Visible = true;
                    Staff staffObj = (Staff)Session["LoggedUser"];
                    lblUsername.Text = staffObj.Name;
                    String userType = staffObj.UserType;

                    if (userType == "Hotel Admin")
                    {                      
                        departmentPlaceHolder.Visible = true;
                        planbuilderPlaceHolder.Visible = true;                        
                        roomPlaceHolder.Visible = true;
                        staffPlaceHolder.Visible = true;
                        seasonPlaceHolder.Visible = true;
                        bookingPlaceHolder.Visible = true;

                        if (Convert.ToBoolean(Session["OnlineBooking"]) == true)
                        {
                            onlineBookingPlaceHolder.Visible = true;
                        }

                        if(Convert.ToBoolean(Session["Payroll"])==true)
                        {
                            attendancePlaceHolder.Visible = true;
                            payrollPlaceHolder.Visible = true;
                        }

                        if (Convert.ToBoolean(Session["Service"]) == true)
                        {
                            servicePlaceHolder.Visible = true;
                            serviceRequestPlaceHolder.Visible = true;
                        }
                        
                    }

                    if (userType == "Managerial Staff")
                    {
                        Session["StaffUserType"] = "Managerial Staff";
                        departmentPlaceHolder.Visible = true;
                        staffPlaceHolder.Visible = true;

                        if (Convert.ToBoolean(Session["OnlineBooking"]) == true)
                        {
                            onlineBookingPlaceHolder.Visible = true;
                        }

                        if (Convert.ToBoolean(Session["Payroll"]) == true)
                        {
                            attendancePlaceHolder.Visible = true;
                            payrollPlaceHolder.Visible = true;
                        }

                        if (Convert.ToBoolean(Session["Service"]) == true)
                        {
                            servicePlaceHolder.Visible = true;
                            serviceRequestPlaceHolder.Visible = true;
                        }
                        lblUsername.Text = staffObj.Name;
                    }

                    if (userType == "Reception Staff")
                    {
                        attendancePlaceHolder.Visible = true;
                        markAttendancePlaceHolder.Visible = false;
                        payrollPlaceHolder.Visible = true;
                        generatePayslipPlaceHolder.Visible = false;
                        bookingPlaceHolder.Visible = true;
                        if (Convert.ToBoolean(Session["OnlineBooking"]) == true)
                        {
                            onlineBookingPlaceHolder.Visible = true;
                        }
                    }

                    if (userType == "Regular Staff")
                    {
                        attendancePlaceHolder.Visible = true;
                        markAttendancePlaceHolder.Visible = false;                        
                        payrollPlaceHolder.Visible = true;
                        generatePayslipPlaceHolder.Visible = false;

                        if (Convert.ToBoolean(Session["Service"]) == true)
                        {                            
                            serviceRequestPlaceHolder.Visible = true;
                            delegateRequestPlaceHolder.Visible = false;
                        }
                    }
                }
                else
                {
                    if (Session["UserType"].ToString() == "Customer")
                    {
                        Customer customerObj = (Customer)Session["LoggedUser"];
                        lblUsername.Text = customerObj.Name;
                    }
                }
            }
        }
    }

    protected void btnMyProfile_Click(object sender, EventArgs e)
    {
        Response.Redirect("userprofile.aspx");
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session["LoggedUser"] = null;
        Session["UserType"] = null;
        Session["jid"] = null;
        Session["rid"] = null;
        Session["sid"] = null;
        Response.Redirect("login.aspx");
    }
}