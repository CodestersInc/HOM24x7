using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using WebUtility;

public partial class UserProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserType"] == "SystemAdmin")
            {
                SystemAdmin sa = (SystemAdmin)Session["loggedUser"];
                txtName.Text = sa.Name;
                txtEmail.Text = sa.Email;
                txtPhone.Text = sa.Phone;
            }
            else if (Session["UserType"] == "Staff")
            {
                Staff staff = (Staff)Session["loggedUser"];
                txtName.Text = staff.Name;
                txtEmail.Text = staff.Email;
                txtPhone.Text = staff.Phone;
            }
            else
            {
                Response.Redirect("home.aspx");
            }
        }        
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Session["UserType"] == "SystemAdmin")
        {
            SystemAdmin sa = (SystemAdmin)Session["loggedUser"];
            sa.Email = txtEmail.Text;
            sa.Phone = txtPhone.Text;

            if (changePwdPH.Visible == true)
            {
                if (Utility.CompareSHA512Hash(Utility.GetSHA512Hash(txtCurrentPwd.Text), sa.Password))
                {
                    sa.Password = Utility.GetSHA512Hash(txtNewPwd.Text);
                    new SystemAdminLogic().update(sa);
                    Response.Redirect("userprofile.aspx");
                }
                else
                {
                    Utility.MsgBox("Current password is invalid...!!", this.Page, this);
                }
            }
            else
            {
                new SystemAdminLogic().update(sa);
            }
        }
        
        if (Session["UserType"] == "Staff")
        {
            Staff staff = (Staff)Session["loggedUser"];
            staff.Email = txtEmail.Text;
            staff.Phone = txtPhone.Text;

            if (changePwdPH.Visible == true)
            {
                if (Utility.CompareSHA512Hash(Utility.GetSHA512Hash(txtCurrentPwd.Text), staff.Password))
                {
                    staff.Password = Utility.GetSHA512Hash(txtNewPwd.Text);
                    new StaffLogic().update(staff);
                    Response.Redirect("userprofile.aspx");
                }
                else
                {
                    Utility.MsgBox("Current password is invalid...!!", this.Page, this);
                }
            }
            else
            {
                new StaffLogic().update(staff);
            }
        }        
    }
    protected void btnchangepwd_Click(object sender, EventArgs e)
    {
        changePwdPH.Visible = true;
        pwdPH.Visible = false;
        btnEdit.Visible = false;
        btnUpdate.Visible = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Session["UserType"] == "SystemAdmin")
        {
            Response.Redirect("systemadminhome.aspx");
        }

        if (Session["UserType"] == "Staff")
        {
            Response.Redirect("home.aspx");
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        txtEmail.Enabled = true;
        txtPhone.Enabled = true;
        btnEdit.Visible = false;
        btnUpdate.Visible = true;
    }
}