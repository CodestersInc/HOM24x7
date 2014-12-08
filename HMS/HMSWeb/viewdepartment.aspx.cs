using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class viewdepartment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["LoggedUser"];

        if (Session["StaffUserType"].ToString() != "HotelAdmin")
        {
            Response.Redirect("login.aspx");
        }

        StaffLogic stafflogicobj = new StaffLogic();
        GridView1.DataSource = stafflogicobj.getStaffNames(loggedUser.AccountID);
        GridView1.DataBind();

        if (!IsPostBack)
        {
            btnUpdate.Enabled = false;
            Department departmentobj = new DepartmentLogic().selectById(Convert.ToInt32(Request.QueryString["ID"]));
            txtName.Text = departmentobj.Name;
            txtManagerName.Text = new StaffLogic().selectById(departmentobj.ManagerID).Name;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["LoggedUser"];

        Department departmentobj = new Department();
        departmentobj.DepartmentID = Convert.ToInt32(Request.QueryString["ID"]);
        departmentobj.Name = txtName.Text;
        departmentobj.AccountID = loggedUser.AccountID;
        departmentobj.ManagerID = Convert.ToInt32(ViewState["staffid"]);

        int res = new DepartmentLogic().update(departmentobj);

        if (res == 1)
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

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int staffid = Convert.ToInt32(e.CommandArgument);
            txtManagerName.Text = new StaffLogic().selectById(staffid).Name;
            GridView1.Visible = false;

            ViewState["staffid"] = staffid;
            btnUpdate.Enabled = true;
        }
    }
}