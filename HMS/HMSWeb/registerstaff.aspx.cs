using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using BusinessLogic;

public partial class registrestaff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        {
            AppUser LoggedAppUser = (AppUser)Session["AppUser"];
            if (LoggedAppUser == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (LoggedAppUser.UserType != "HotelAdmin")
            {
                Response.Redirect("login.aspx");
            }
            DepartmentLogic departmentLogic = new DepartmentLogic();
            ddlDepartment.DataSource = departmentLogic.selectDistinctDept(LoggedAppUser.AccountID);
            ddlDepartment.DataBind();
            ddlDepartment.DataValueField = "DepartmentID";
            ddlDepartment.DataTextField = "DepartmentName";
        }
        catch (Exception)
        {
            Response.Redirect("ErrorPage500.html");
        }
        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            DepartmentLogic DL = new DepartmentLogic();
            AppUserLogic AL = new AppUserLogic();
            StaffLogic SL = new StaffLogic();

            AppUser loggedInAppUser = (AppUser)Session["AppUser"];
            Staff loggedInStaff = (Staff)Session["Staff"];

            int successfullAdditionOfAppUser = AL.create(new AppUser(0,
                txtName.Text,
                txtEmail.Text,
                txtPhone.Text,
                loggedInAppUser.AccountID,
                txtUsername.Text,
                txtPassword.Text,
                "Staff"));
            if (successfullAdditionOfAppUser == 1)
            {
                AppUser registeringAppUser = AL.login(txtUsername.Text, txtPassword.Text);

                int successfullAdditionOfStaff = SL.create(new Staff(0,
                        loggedInAppUser.AppUserID,
                        ddlDesignation.SelectedValue.ToString(),
                        Convert.ToDateTime(txtDOB.Text),
                        System.DateTime.Now,
                        Convert.ToInt32(txtSalary.Text),
                        ddlSalaryFrequency.SelectedValue.ToString(),
                        radioYes.Checked,
                        Convert.ToInt32(ddlDepartment.DataValueField)));
                if (successfullAdditionOfStaff == 1)
                {
                    Response.Redirect("hahome.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("ErrorPage500.html");
        }
        
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("hahome.aspx");
    }
}