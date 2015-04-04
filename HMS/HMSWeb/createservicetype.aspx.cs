using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class createServiceType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];
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
            "img/ServiceType/" + ticks + FileUpload1.FileName,
            loggedUser.AccountID));

        if (serviceTypeObj != null)
        {
            FileUpload1.SaveAs(Server.MapPath("img/ServiceType/" + ticks + FileUpload1.FileName));
            Response.Redirect("home.aspx");
        }
        else
        {
            Server.TransferRequest("ErrorPage500.html");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}