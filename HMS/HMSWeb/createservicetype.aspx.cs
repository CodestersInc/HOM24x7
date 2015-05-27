using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using WebUtility;

public partial class createServiceType : System.Web.UI.Page
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

        if (loggedUser.UserType != "Hotel Admin")
        {
            Response.Redirect("home.aspx");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        String ticks = DateTime.Now.Ticks.ToString();

        ServiceType serviceTypeObj = new ServiceTypeLogic().create(new ServiceType(0,
            txtServiceTypeName.Text,
            txtDescription.Text,
            "img/servicetype/" + ticks + FileUpload1.FileName,
            loggedUser.AccountID));

        if (serviceTypeObj != null)
        {
            FileUpload1.SaveAs(Server.MapPath("img/ServiceType/" + ticks + FileUpload1.FileName));
            Utility.MsgBox("Service type created successfully...!!", this.Page, this, "home.aspx");
        }
        else
        {
            Utility.MsgBox("Error: Service type creation failed...!!", this.Page, this, "createservicetype.aspx");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}