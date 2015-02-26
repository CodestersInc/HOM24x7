using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;

public partial class adddepartment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["LoggedUser"];
        if (loggedUser == null || Session["StaffUserType"].ToString() != "Hotel Admin")
        {
            Response.Redirect("login.aspx");
        }

        if (Request.QueryString["ID"] == null && Request.QueryString["Name"] == null)
        {
            searchResultTable.Visible = true;
            Repeater1.DataSource = new StaffLogic().searchManager(loggedUser.AccountID);
            Repeater1.DataBind();
        }

        if (!IsPostBack)
        {
            btnSubmit.Enabled = false;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["LoggedUser"];

        Department departmentobj = new Department();
        departmentobj.AccountID = loggedUser.AccountID;
        departmentobj.Name = txtName.Text;
        departmentobj.ManagerID = Convert.ToInt32(ViewState["staffid"]);

        Department department = new DepartmentLogic().create(departmentobj);

        if (department != null)
        {
            Response.Redirect("home.aspx");
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int staffid = Convert.ToInt32(e.CommandArgument);
            txtManagerName.Text = new StaffLogic().selectById(staffid).Name;
            Repeater1.Visible = false;
            //Repeater1.DataSource = new StaffLogic().search("", loggedUser.AccountID);
            //Repeater1.DataBind();
            searchResultTable.Visible = false;

            ViewState["staffid"] = staffid;
            btnSubmit.Enabled = true;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (txtManagerName.Text.Length!=0)
        {
            Response.Redirect("createdepartment.aspx");
        }
        else
        {
            Response.Redirect("home.aspx");
        }
        
    }
}