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

        if (loggedUser == null || (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff"))
        {
            Response.Redirect("login.aspx");
        }
        StaffLogic staffLogic = new StaffLogic(); 

        Repeater1.DataSource = staffLogic.searchManager(loggedUser.AccountID);
        Repeater1.DataBind();

        if (!IsPostBack)
        {
            btnUpdate.Enabled = false;
            Department departmentobj = new DepartmentLogic().selectById(Convert.ToInt32(Request.QueryString["ID"]));
            txtName.Text = departmentobj.Name;
            txtManagerName.Text = staffLogic.selectById(departmentobj.ManagerID).Name;
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

        if (new DepartmentLogic().update(departmentobj) == 1)
        {
            Response.Redirect("searchdepartment.aspx");
        }
        else
        {
            Response.Redirect("ErrorPage500.html");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["LoggedUser"];
        StaffLogic staffLogic = new StaffLogic();
        String OriginalManagerName = staffLogic.selectById(new DepartmentLogic().selectById(Convert.ToInt32(Request.QueryString["ID"])).ManagerID).Name;
        if (txtManagerName.Text.Equals( OriginalManagerName ) )
        {
            Response.Redirect("Home.aspx");
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
        }
    }

}