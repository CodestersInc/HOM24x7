using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class viewstaff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
            Staff loggedUser = (Staff)Session["loggedUser"];
            if (loggedUser == null || loggedUser.UserType != "HotelAdmin")
            {
                Response.Redirect("login.aspx");
            }

            //Fill ddlDesignation
            StaffLogic staffLogic = new StaffLogic();
            ddlDesignation.DataSource = staffLogic.selectDistinctDesignation(loggedUser.AccountID);
            ddlDesignation.DataValueField = "DepartmentID";
            ddlDesignation.DataTextField = "DesignationChoices";
            ddlDesignation.DataBind();


            //Fill ddlDepartment
            DepartmentLogic departmentLogic = new DepartmentLogic();
            ddlDepartment.DataSource = departmentLogic.selectDistinctDept(loggedUser.AccountID);
            ddlDepartment.DataValueField = "DepartmentID";
            ddlDepartment.DataTextField = "DepartmentChoices";
            ddlDepartment.DataBind();

            AppUser appuserobj = new AppUser();
            AppUserLogic appuserlogicobj = new AppUserLogic();
            appuserobj = appuserlogicobj.selectByStaffId(Convert.ToInt32(Request.QueryString["ID"]));

            txtName.Text = appuserobj.Name;
            txtEmail.Text = appuserobj.Email;
            txtPhone.Text = appuserobj.Phone;

            StaffLogic stafflogicobj = new StaffLogic();
            Staff staffobj = stafflogicobj.selectById(Convert.ToInt32(Request.QueryString["ID"]));
            ddlDesignation.SelectedValue = staffobj.Designation;
            txtDOB.Text = (staffobj.DOB).Date.ToString();
            txtDOJ.Text = (staffobj.DOJ).Date.ToString();
            txtSalary.Text = staffobj.Salary.ToString();
            if (staffobj.IsActive == true)
            {
                radioYes.Checked = true;

            }
            else
                radioNo.Checked = true;

            DepartmentLogic departmentlogicobj = new DepartmentLogic();
            ddlDepartment.SelectedValue = departmentlogicobj.selectById(staffobj.DepartmentID).Name.ToString();
        //}
        //catch (Exception ex)
        //{
        //    Response.Redirect("ErrorPage500");
        //}
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch
        {
            Response.Redirect("ErrorPage500.html");
        }
    }
}