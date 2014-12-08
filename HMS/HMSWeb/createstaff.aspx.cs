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
        Staff loggedUser = (Staff)Session["loggedUser"];

        if (loggedUser == null || loggedUser.UserType != "HotelAdmin")
        {
            Response.Redirect("login.aspx");
        }

        DepartmentLogic departmentLogic = new DepartmentLogic();
        ddlDepartment.DataSource = departmentLogic.selectDistinctDept(loggedUser.AccountID);
        ddlDepartment.DataValueField = "DepartmentID";
        ddlDepartment.DataTextField = "DepartmentName";
        ddlDepartment.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Staff loggedInStaff = (Staff)Session["LoggedUser"];

        Staff staffobject = new Staff(0,
            txtName.Text,
            txtEmail.Text,
            txtPhone.Text,
            txtUsername.Text,
            txtPassword.Text,
            ddlUserType.SelectedValue,
            ddlDesignation.SelectedValue,
            Convert.ToDateTime(txtDOB.Text),
            System.DateTime.Now,
            Convert.ToInt32(txtSalary.Text),
            radioYes.Checked,
            Convert.ToInt32(ddlDepartment.SelectedValue),
            loggedInStaff.AccountID);

        Staff createdstaff = new StaffLogic().create(staffobject);

        if (createdstaff != null)
        {
            Response.Redirect("home.aspx");
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