using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;
using WebUtility;

public partial class adddepartment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["LoggedUser"];

        if (loggedUser == null || (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff"))
        {
            Response.Redirect("login.aspx");
        }

        if (!IsPostBack)
        {
            Repeater1.DataSource = new StaffLogic().searchManager(loggedUser.AccountID);
            Repeater1.DataBind();

            managerNamePlaceHolder.Visible = false;
            newManagerPlaceHolder.Visible = false;
            managerChoicePlaceHolder.Visible = true;
            btnSubmit.Enabled = false;
            ddlUserType.Enabled = false;

            if (ViewState["deptName"] != null)
                txtDepartmentName.Text = ViewState["deptName"].ToString();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["LoggedUser"];
        Department departmentobj = new Department();
        Department createdDepartment = new Department();
        DepartmentLogic departmentLogicObj = new DepartmentLogic();

        if (newManagerPlaceHolder.Visible == true)
        {
            int departmentID = departmentLogicObj.fetchLastRecordId();

            Staff createdstaff = new StaffLogic().create(new Staff(0,
                txtStaffCode.Text,
                txtName.Text,
                txtEmail.Text,
                txtPhone.Text,
                Utility.GetSHA512Hash(txtUsername.Text),
                Utility.GetSHA512Hash(txtPassword.Text),
                ddlUserType.SelectedValue,
                txtDesignation.Text,
                Convert.ToDateTime(txtDOB.Text),
                DateTime.Now,
                Convert.ToInt32(txtSalary.Text),
                cbxIsActive.Checked,
                departmentID + 1,
                loggedUser.AccountID));

            if (createdstaff != null)
            {
                departmentobj.AccountID = loggedUser.AccountID;
                departmentobj.Name = txtDepartmentName.Text;
                departmentobj.ManagerID = createdstaff.StaffID;
                createdDepartment = departmentLogicObj.create(departmentobj);
            }
        }
        else
        {
            departmentobj.AccountID = loggedUser.AccountID;
            departmentobj.Name = txtDepartmentName.Text;
            departmentobj.ManagerID = Convert.ToInt32(ViewState["staffid"]);
            createdDepartment = departmentLogicObj.create(departmentobj);
        }

        if (createdDepartment != null)
        {
            Response.Redirect("home.aspx");
        }
        else
        {
            Response.Redirect("ErrorPage500.html");
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int staffid = Convert.ToInt32(e.CommandArgument);
            ViewState["staffid"] = staffid;
            txtManagerName.Text = new StaffLogic().selectById(staffid).Name;
            managerNamePlaceHolder.Visible = true;
            Repeater1.Visible = false;
            managerChoicePlaceHolder.Visible = false;
            btnNewManager.Visible = false;
            btnSubmit.Enabled = true;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("createdepartment.aspx");
    }

    protected void btnNewManager_Click(object sender, EventArgs e)
    {
        ViewState["deptName"] = txtDepartmentName.Text;
        managerChoicePlaceHolder.Visible = false;
        newManagerPlaceHolder.Visible = true;
        btnSubmit.Enabled = true;
        btnNewManager.Visible = false;
    }
}