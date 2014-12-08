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
        Staff loggedUser = (Staff)Session["LoggedUser"];
        if (Session["StaffUserType"].ToString() != "HotelAdmin")
        {
            Response.Redirect("login.aspx");
        }
        if (Request.QueryString["ID"] == null && Request.QueryString["Name"] == null)
        {
            StaffLogic stafflogicobj = new StaffLogic();
            GridView1.DataSource = stafflogicobj.getStaffNames(loggedUser.AccountID);
            GridView1.DataBind();
        }

        if (!IsPostBack)
        {
            btnSubmit.Enabled = false;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //try
        //{
            Staff loggedUser = (Staff)Session["LoggedUser"];
            Department departmentobj = new Department();
            DepartmentLogic departmentlogicobj = new DepartmentLogic();

            departmentobj.AccountID = loggedUser.AccountID;
            departmentobj.Name = txtName.Text;
            departmentobj.ManagerID = Convert.ToInt32(ViewState["staffid"]);
            
            Department department = departmentlogicobj.create(departmentobj);

            if(department!=null)
            {
                Response.Redirect("home.aspx");
            }
        //}
        //catch (Exception ex)
        //{
        //    Response.Redirect("ErrorPage500.html");
        //}

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int staffid = Convert.ToInt32(e.CommandArgument);
            txtManagerName.Text = new StaffLogic().selectById(staffid).Name;
            GridView1.Visible = false;

            ViewState["staffid"] = staffid;
            btnSubmit.Enabled = true;
        }
    }
}