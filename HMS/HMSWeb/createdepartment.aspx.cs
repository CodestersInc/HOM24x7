using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class adddepartment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Staff loggedUser = (Staff)Session["LoggedUser"];
            if (Session["UserType"] != "HotelAdmin")
            {
                Response.Redirect("login.aspx");
            }

            if (Request.QueryString["ID"] == null && Request.QueryString["Name"] == null)
            {
                StaffLogic stafflogicobj = new StaffLogic();
                GridView1.DataSource = stafflogicobj.getStaffNames(loggedUser.AccountID);
                GridView1.DataBind();
            }
            else
            {
                /*
                txtName.Text = (String)Request.QueryString["Name"];
                StaffLogic stafflogicobj = new StaffLogic();
                Staff staffobj = stafflogicobj.selectById(Convert.ToInt32((String)Request.QueryString["ID"]));
                AppUserLogic appuserlogicobj = new AppUserLogic();
                AppUser appuserobj = appuserlogicobj.selectById(staffobj.AppUserID);
                txtManagerName.Text = appuserobj.Name;
                Session.Add("DepartmentManager", staffobj);
                */
            }
        }
        catch (Exception ex)
        {

        }
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Staff loggedUser = (Staff)Session["LoggedUser"];
            Department departmentobj = new Department();
            DepartmentLogic departmentlogicobj = new DepartmentLogic();
            //AppUser LoggedAppUser = (AppUser)Session["AppUser"];
            Staff DepartmentManager = (Staff)Session["DepartmentManager"];

            departmentobj.AccountID = loggedUser.AccountID;
            departmentobj.Name = txtName.Text;
            if (txtManagerName.Text != "")
            {
                departmentobj.ManagerID = DepartmentManager.StaffID;
            }
            departmentlogicobj.create(departmentobj);
        }
        catch (Exception ex)
        {

        }
        
    }
}