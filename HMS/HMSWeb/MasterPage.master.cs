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
        try
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
                        String userType = staffObj.UserType;

                        if (userType == "HotelAdmin")
                        {
                            Session["StaffUserType"] = "HotelAdmin";
                            attendancePlaceHolder.Visible = true;
                            departmentPlaceHolder.Visible = true;
                            payrollPlaceHolder.Visible = true;
                            roomPlaceHolder.Visible = true;
                            staffPlaceHolder.Visible = true;
                            seasonPlaceHolder.Visible = true;
                            servicePlaceHolder.Visible = true;
                            serviceRequestPlaceHolder.Visible = true;
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

                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("ErrorPage500.html");
        }

    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        try
        {
            Session["LoggedUser"] = null;
            Session["UserType"] = null;
            Session["StaffUserType"] = null;
            Response.Redirect("login.aspx");
        }
        catch (Exception ex)
        {
            Console.Out.Write(ex.StackTrace);
            Response.Redirect("ErrorPage500.html");
        }

    }
}