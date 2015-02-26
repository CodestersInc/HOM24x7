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

public partial class viewservice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        if (loggedUser == null || loggedUser.UserType != "Hotel Admin")
        {
            Response.Redirect("login.aspx");
        }

        if (!IsPostBack)
        {
            //Fill ddlDepartment
            DepartmentLogic departmentlogicobj = new DepartmentLogic();
            DataTable dt = departmentlogicobj.selectDistinctDepartment(loggedUser.AccountID);
            ddlDepartment.DataSource = dt;
            ddlDepartment.DataValueField = "DepartmentID";
            ddlDepartment.DataTextField = "DepartmentChoices";
            ddlDepartment.DataBind();

            Service serviceobj = new ServiceLogic().selectById(Convert.ToInt32(Request.QueryString["ID"]));
            txtName.Text = serviceobj.Name;
            ddlDepartment.SelectedValue = departmentlogicobj.selectById(serviceobj.DepartmentID).Name;
            txtRate.Text = serviceobj.Rate.ToString();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        Service serviceobj = new Service(Convert.ToInt32(Request.QueryString["ID"]),
            txtName.Text,
            Convert.ToInt32(ddlDepartment.SelectedValue),
            Convert.ToDouble(txtRate.Text),
            loggedUser.AccountID);

        if (new ServiceLogic().update(serviceobj) == 1)
        {
            Response.Redirect("searchservice.aspx");
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