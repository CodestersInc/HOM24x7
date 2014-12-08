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
        Staff loggedUser = (Staff)Session["loggedUser"];
        if (loggedUser == null || loggedUser.UserType != "HotelAdmin")
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            ////Fill ddlDesignation
            //StaffLogic staffLogic = new StaffLogic();
            //ddlDesignation.DataSource = staffLogic.selectDistinctDesignation(loggedUser.AccountID);
            //ddlDesignation.DataValueField = "DesignationChoices";
            //ddlDesignation.DataTextField = "DesignationChoices";
            //ddlDesignation.DataBind();

            //Fill ddlDepartment
            DepartmentLogic departmentLogic = new DepartmentLogic();
            ddlDepartment.DataSource = departmentLogic.selectDistinctDepartment(loggedUser.AccountID);
            ddlDepartment.DataValueField = "DepartmentID";
            ddlDepartment.DataTextField = "DepartmentChoices";
            ddlDepartment.DataBind();

            Staff staffobj = new StaffLogic().selectById(Convert.ToInt32(Request.QueryString["ID"]));
            txtName.Text = staffobj.Name;
            txtEmail.Text = staffobj.Email;
            txtPhone.Text = staffobj.Phone;
            ddlUserType.SelectedValue = staffobj.UserType;
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
            ddlDepartment.SelectedValue = new DepartmentLogic().selectById(staffobj.DepartmentID).Name.ToString();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        Staff staffobj = new Staff();
        staffobj.StaffID = Convert.ToInt32(Request.QueryString["ID"]);
        staffobj.Name = txtName.Text;
        staffobj.Email = txtEmail.Text;
        staffobj.Phone = txtPhone.Text;
        staffobj.UserType = ddlUserType.SelectedValue;
        staffobj.Designation = ddlDesignation.SelectedValue;
        staffobj.DOB = Convert.ToDateTime(txtDOB.Text);
        staffobj.DOJ = Convert.ToDateTime(txtDOJ.Text);
        staffobj.Salary = Convert.ToInt64(txtSalary.Text);
        staffobj.IsActive = Convert.ToBoolean(radioYes.Checked);
        staffobj.DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);
        staffobj.AccountID = loggedUser.AccountID;

        if (new StaffLogic().update(staffobj) == 1)
        {
            Response.Redirect("searchstaff.aspx");
        }
        else
        {
            Response.Redirect("ErrorPage500.html");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}