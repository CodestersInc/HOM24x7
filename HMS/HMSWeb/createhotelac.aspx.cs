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
using WebUtility;

public partial class hacregister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var User = Session["loggedUser"];

        if (!(User is SystemAdmin))
            Response.Redirect("login.aspx");
        SystemAdmin loggedUser = (SystemAdmin)Session["LoggedUser"];
        if (loggedUser == null)
        {
            Response.Redirect("login.aspx?url=" + Request.Url);
        }
        if (Session["UserType"].ToString() != "SystemAdmin")
        {
            Response.Redirect("home.aspx");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        AccountLogic accountLogic = new AccountLogic();
        StaffLogic staffLogic = new StaffLogic();
        SeasonLogic seasonLogic = new SeasonLogic();
        DepartmentLogic departmentLogic = new DepartmentLogic();

        String features = ((cbxOnlineBooking.Checked) ? "#Online Booking#" : "") +
            ((cbxPayroll.Checked) ? "#Payroll#" : "") +
            ((cbxService.Checked) ? "#Service#" : "");

        Account newAccount = accountLogic.create(new Account(0,
            txtCompany.Text,
            txtContact.Text,
            txtAccountEmail.Text,
            txtAccountPhone.Text,
            txtAddress.Text,
            txtWebsite.Text,
            features));

        if (newAccount != null)
        {
            Department newDepartment = departmentLogic.create(new Department(0,
            "Admin",
            newAccount.AccountID,
            0));

            if (newDepartment != null)
            {
                Staff newstaff = staffLogic.create(new Staff(0,
                txtStaffCode.Text,
                txtName.Text,
                txtEmail.Text,
                Convert.ToString(newAccount.Phone),
                Utility.GetSHA512Hash(txtUsername.Text),                           //to be modified in future to email id
                Utility.GetSHA512Hash(txtPassword.Text),
                "Hotel Admin",
                "Hotel Admin",
                Convert.ToDateTime(txtDOB.Text),
                DateTime.Now,
                Convert.ToInt32(txtSalary.Text),
                true,
                txtBankACNumber.Text,
                newDepartment.DepartmentID,
                newAccount.AccountID));

                newDepartment.ManagerID = newstaff.StaffID;
                departmentLogic.update(newDepartment);

                //START Add a regular season so the hotel can be managed using it on the regular basis
                Season RegularSeason = seasonLogic.create(new Season(0,
                    "Regular Season",
                    DateTime.Now,
                    DateTime.MaxValue,
                    newAccount.AccountID));

                //END Add a regular season so the hotel can be managed using it on the regular basis
                if (newstaff != null)
                {
                    if (RegularSeason != null)
                    {
                        Utility.MsgBox("Hotel Account successfuly created...!!", this.Page, this, "sytemadminhome.aspx");
                    }
                    else
                    {
                        departmentLogic.delete(newDepartment.DepartmentID);
                        staffLogic.delete(newstaff.StaffID);
                        accountLogic.delete(newAccount.AccountID);
                    }
                }
            }
            else
            {
                accountLogic.delete(newAccount.AccountID);
            }
        }
        else
        {
            Utility.MsgBox("Account creation failed...!!", this.Page, this, "sytemadminhome.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("systemadminhome.aspx");
    }
}