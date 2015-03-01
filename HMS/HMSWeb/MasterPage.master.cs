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

                    if (userType == "Hotel Admin" || userType == "Managerial Staff")
                    {
                        Session["StaffUserType"] = "Hotel Admin";                        
                        departmentPlaceHolder.Visible = true;
                        planbuilderPlaceHolder.Visible = true;
                        roomPlaceHolder.Visible = true;
                        staffPlaceHolder.Visible = true;
                        seasonPlaceHolder.Visible = true;

                        if (Convert.ToBoolean(Session["OnlineBooking"]) == true)
                        {

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

                        lblUsername.Text = staffObj.Name;
                    }
                    if (userType == "Reception")
                    {

                    }
                    if (userType == "Service")
                    {

                    }
                    if (userType == "DepartmentManager")
                    {

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
}