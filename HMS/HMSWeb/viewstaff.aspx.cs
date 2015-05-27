using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;
using WebUtility;

public partial class viewstaff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var User = Session["loggedUser"];
        if (!(User is Staff))
            Response.Redirect("login.aspx");
        Staff loggedUser = (Staff)Session["loggedUser"];
        if (loggedUser == null || (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff"))
        {
            Response.Redirect("login.aspx");
        }

        if (!IsPostBack)
        {
            //Fill ddlDepartment
            DataTable dt = new DepartmentLogic().selectDistinctDepartment(loggedUser.AccountID);
            ddlDepartment.DataSource = dt;
            ddlDepartment.DataValueField = "DepartmentID";
            ddlDepartment.DataTextField = "DepartmentChoices";
            ddlDepartment.DataBind();

            Staff staffobj = new StaffLogic().selectById(Convert.ToInt32(Request.QueryString["ID"]));
            txtName.Text = staffobj.Name;
            txtStaffCode.Text = staffobj.StaffCode;
            txtEmail.Text = staffobj.Email;
            txtPhone.Text = staffobj.Phone;
            ddlUserType.SelectedValue = staffobj.UserType;
            txtDesignation.Text = staffobj.Designation;
            txtDOB.Text = (staffobj.DOB).ToShortDateString();
            txtDOJ.Text = (staffobj.DOJ).ToShortDateString();
            txtSalary.Text = staffobj.Salary.ToString();
            txtBankACNumber.Text = staffobj.BankACNumber.ToString();
            cbxIsActive.Checked = staffobj.IsActive;
            ddlDepartment.SelectedValue = staffobj.DepartmentID.ToString();
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        Staff staffobj = new Staff();
        staffobj.StaffID = Convert.ToInt32(Request.QueryString["ID"]);
        staffobj.StaffCode = txtStaffCode.Text;
        staffobj.Name = txtName.Text;
        staffobj.Email = txtEmail.Text;
        staffobj.Phone = txtPhone.Text;
        staffobj.UserType = ddlUserType.SelectedValue;
        staffobj.Designation = txtDesignation.Text;
        staffobj.DOB = Convert.ToDateTime(txtDOB.Text);
        staffobj.DOJ = Convert.ToDateTime(txtDOJ.Text);
        staffobj.Salary = Convert.ToInt64(txtSalary.Text);
        staffobj.IsActive = Convert.ToBoolean(cbxIsActive.Checked);
        staffobj.BankACNumber = txtBankACNumber.Text;
        staffobj.DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);
        staffobj.AccountID = loggedUser.AccountID;
        staffobj.Password = loggedUser.Password;

        if(new StaffLogic().update(staffobj)==1)
        {
            Utility.MsgBox("Staff details updated successfully...!!", this.Page, this, "searchstaff.aspx");
        }
        else
        {
            Utility.MsgBox("Error: Staff updation failed...!!", this.Page, this, "searchstaff.aspx");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}