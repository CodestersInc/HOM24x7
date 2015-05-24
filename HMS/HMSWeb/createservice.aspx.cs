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

public partial class createservice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var User = Session["loggedUser"];
        if (!(User is Staff))
            Response.Redirect("login.aspx");
        Staff loggedUser = (Staff)User;

        if (loggedUser == null)
        {
            Response.Redirect("login.aspx?url=" + Request.Url);
        }
        if (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff")
        {
            Response.Redirect("home.aspx");
        }
        if(!IsPostBack)
        {
            DataTable dt = new DepartmentLogic().selectDistinctDepartment(loggedUser.AccountID);
            ddlDepartment.DataSource = dt;
            ddlDepartment.DataValueField = "DepartmentID";
            ddlDepartment.DataTextField = "DepartmentChoices";
            ddlDepartment.DataBind();

            DataTable dt1 = new ServiceTypeLogic().selectAll(loggedUser.AccountID);
            ddlServiceType.DataSource = dt1;
            ddlServiceType.DataValueField = "ServiceTypeID";
            ddlServiceType.DataTextField = "Name";
            ddlServiceType.DataBind();
        }        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        String ticks = DateTime.Now.Ticks.ToString();

        Service createdservice = new ServiceLogic().create(new Service(0,
             txtName.Text,
             Convert.ToInt32(ddlDepartment.SelectedValue),
             Convert.ToDouble(txtRate.Text),
             "img/service/" + ticks + FileUpload1.FileName,
             Convert.ToInt32(ddlServiceType.SelectedValue)));

        if (createdservice != null)
        {
            FileUpload1.SaveAs(Server.MapPath("img/service/" + ticks + FileUpload1.FileName));
            Response.Redirect("home.aspx");
        }
        else
        {
            Server.TransferRequest("ErrorPage500.html");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}