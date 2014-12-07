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
        AppUser LoggedAppUser = (AppUser)Session["AppUser"];

        if (LoggedAppUser == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            if(Session["UserType"].ToString()=="SystemAdmin")
            {
                homePlaceHolder.Visible = true;
                accountsPlaceHolder.Visible = true;
            }
            else
            {
                if (Session["UserType"].ToString() == "Staff")
                {
                    homePlaceHolder.Visible = true;
                    if(Session["Staff"]!=null)
                    {
                        Staff staffObj = (Staff)Session["Staff"];
                        String userType = staffObj.UserType;

                        if(userType=="HotelAdmin")
                        {
                            attendancePlaceHolder.Visible = true;
                            departmentPlaceHolder.Visible = true;
                            payrollPlaceHolder.Visible = true;
                            roomPlaceHolder.Visible = true;
                            staffPlaceHolder.Visible = true;
                            seasonPlaceHolder.Visible = true;
                            servicePlaceHolder.Visible = true;
                            serviceRequestPlaceHolder.Visible = true;
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
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        AppUser LoggedAppUser = (AppUser)Session["AppUser"];
        Session["AppUser"] = null;
        Response.Redirect("login.aspx");
    }
}
