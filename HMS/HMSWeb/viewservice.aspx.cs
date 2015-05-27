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
using System.IO;
using WebUtility;

public partial class viewservice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var User = Session["loggedUser"];
        if (!(User is Staff))
            Response.Redirect("login.aspx");
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

            DataTable dt1 = new ServiceTypeLogic().selectAll(loggedUser.AccountID);
            ddlServiceType.DataSource = dt1;
            ddlServiceType.DataValueField = "ServiceTypeID";
            ddlServiceType.DataTextField = "Name";
            ddlServiceType.DataBind();

            Service serviceobj = new ServiceLogic().selectById(Convert.ToInt32(Request.QueryString["ID"]));
            txtName.Text = serviceobj.Name;
            ddlDepartment.SelectedValue = departmentlogicobj.selectById(serviceobj.DepartmentID).Name;
            txtRate.Text = serviceobj.Rate.ToString();
            Image1.ImageUrl = serviceobj.Image;
            ddlServiceType.SelectedValue = serviceobj.ServiceTypeID.ToString();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];
        String ticks = DateTime.Now.Ticks.ToString();

        ServiceLogic serviceLogic = new ServiceLogic();
        String staleImagePath = serviceLogic.selectById(Convert.ToInt32(Request.QueryString["ID"])).Image;

        Service serviceobj = new Service(Convert.ToInt32(Request.QueryString["ID"]),
            txtName.Text,
            Convert.ToInt32(ddlDepartment.SelectedValue),
            Convert.ToDouble(txtRate.Text),
            (FileUpload1.HasFile)? "img/service/" + ticks + FileUpload1.FileName : staleImagePath,
            Convert.ToInt32(ddlServiceType.SelectedValue));


        if (serviceLogic.update(serviceobj) == 1)
        {
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("img/service/" + ticks + FileUpload1.FileName));
                try
                {
                    File.Delete(staleImagePath);
                }
                catch (Exception)
                {
                    //for now just do nothing this case may come in place if there is 
                    //no file to be deleted or the path is ""
                }
            }
            Utility.MsgBox("Service details updated successfully...!!", this.Page, this, "searchservice.aspx");
        }
        else
        {
            Utility.MsgBox("Error: Service updation failed...!!", this.Page, this, "searchservice.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}