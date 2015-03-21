using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class createcomponent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        if (loggedUser == null || loggedUser.UserType != "Hotel Admin")
        {
            Response.Redirect("login.aspx?url=" + Request.Url);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        String ticks = DateTime.Now.Ticks.ToString();
        

        String Type = (cbxIsRoom.Checked)?"Room":"Other";

        Component componentObj = new ComponentLogic().create(new Component(0,
            txtComponentName.Text,
            Type,
            txtDescription.Text,
            "img/component/" + ticks + FileUpload1.FileName,
            loggedUser.AccountID));

        if (componentObj != null)
        {
            FileUpload1.SaveAs(Server.MapPath("img/component/" + ticks + FileUpload1.FileName));
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