using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using WebUtility;

public partial class viewdepartment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var User = Session["loggedUser"];
        if (!(User is Staff))
            Response.Redirect("login.aspx");

        Staff loggedUser = (Staff)User;

        if (loggedUser == null || (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff"))
        {
            Response.Redirect("login.aspx");
        }
        StaffLogic staffLogic = new StaffLogic(); 

        if (!IsPostBack)
        {
            Repeater1.DataSource = new StaffLogic().getStaffNames(loggedUser.AccountID);
            Repeater1.DataBind();
            Department departmentobj = new DepartmentLogic().selectById(Convert.ToInt32(Request.QueryString["ID"]));
            txtDepartmentName.Text = departmentobj.Name;
            txtManagerName.Text = new StaffLogic().selectById(departmentobj.ManagerID).Name;

            managerChoicePlaceHolder.Visible = true;
            btnUpdate.Enabled = false;
            newManagerPlaceHolder.Visible = false;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["LoggedUser"];
        Department departmentobj = new Department();
        Department createdDepartment = new Department();
        StaffLogic staffLogicObj = new StaffLogic();
        DepartmentLogic departmentLogicObj = new DepartmentLogic();

        if (newManagerPlaceHolder.Visible == true)
        {
            Staff newmanager = new StaffLogic().create(new Staff(0,
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
                txtBankACNumber.Text,
                Convert.ToInt32(Request.QueryString["ID"]),
                loggedUser.AccountID));

            if (newmanager != null)
            {
                int oldmanagerID = departmentLogicObj.selectById(Convert.ToInt32(Request.QueryString["ID"])).ManagerID;

                departmentobj = new Department(Convert.ToInt32(Request.QueryString["ID"]),
                                txtDepartmentName.Text,
                                loggedUser.AccountID,
                                newmanager.StaffID);

                if (departmentLogicObj.update(departmentobj) == 1)
                {
                    Staff oldmanager = staffLogicObj.selectById(oldmanagerID);
                    oldmanager.UserType = "Regular Staff";
                    staffLogicObj.update(oldmanager);

                    Utility.MsgBox("Department details updated successfully...!!", this.Page, this, "searchdepartment.aspx");
                }
                else
                {
                    staffLogicObj.delete(newmanager.StaffID);
                    Utility.MsgBox("Error: Department updation failed...!!", this.Page, this, "searchdepartment.aspx");
                }
            }
            else
            {
                Utility.MsgBox("Error: Department updation failed...!!", this.Page, this, "searchdepartment.aspx");
            }
        }
        else
        {
            int oldmanagerID = departmentLogicObj.selectById(Convert.ToInt32(Request.QueryString["ID"])).ManagerID;

            Staff newmanager = staffLogicObj.selectById(Convert.ToInt32(ViewState["staffid"]));
            newmanager.UserType = "Managerial Staff";

            if (staffLogicObj.update(newmanager) == 1)
            {
                departmentobj = new Department(Convert.ToInt32(Request.QueryString["ID"]),
                                            txtDepartmentName.Text,
                                            loggedUser.AccountID,
                                            Convert.ToInt32(ViewState["staffid"]));

                if (departmentLogicObj.update(departmentobj) == 1)
                {
                    Staff oldmanager = staffLogicObj.selectById(oldmanagerID);
                    oldmanager.UserType = "Regular Staff";
                    staffLogicObj.update(oldmanager);

                    Utility.MsgBox("Department details updated successfully...!!", this.Page, this, "searchdepartment.aspx");
                }
                else
                {
                    Utility.MsgBox("Error: Department updation failed...!!", this.Page, this, "searchdepartment.aspx");
                }
            }
            else
            {
                Utility.MsgBox("Error: Department updation failed...!!", this.Page, this, "searchdepartment.aspx");
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["LoggedUser"];
        StaffLogic staffLogic = new StaffLogic();
        String OriginalManagerName = staffLogic.selectById(new DepartmentLogic().selectById(Convert.ToInt32(Request.QueryString["ID"])).ManagerID).Name;
        
        if (txtManagerName.Text.Equals(OriginalManagerName))
        {
            Response.Redirect("searchdepartment.aspx");
        }
        else
        {
            txtManagerName.Text = OriginalManagerName;
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int staffid = Convert.ToInt32(e.CommandArgument);
            ViewState["staffid"] = staffid;
            txtManagerName.Text = new StaffLogic().selectById(staffid).Name;
            Repeater1.Visible = false;
            managerChoicePlaceHolder.Visible = false;
            btnUpdate.Enabled = true;
            btnNewManager.Visible = false;
        }
    }

    protected void btnNewManager_Click(object sender, EventArgs e)
    {
        ViewState["deptName"] = txtDepartmentName.Text;
        managerChoicePlaceHolder.Visible = false;
        newManagerPlaceHolder.Visible = true;
        btnUpdate.Enabled = true;
        btnNewManager.Visible = false;
        ddlUserType.Enabled = false;
        managerNamePlaceHolder.Visible = false;
    }
}