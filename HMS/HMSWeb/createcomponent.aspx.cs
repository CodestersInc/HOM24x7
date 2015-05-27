using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using WebUtility;

public partial class createcomponent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var User = Session["loggedUser"];
        if (!(User is Staff))
            Response.Redirect("login.aspx");
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

        Component componentObj = new ComponentLogic().create(new Component(0,
            txtComponentName.Text,
            txtDescription.Text,
            "img/component/" + ticks + FileUpload1.FileName,
            loggedUser.AccountID));

        if (componentObj != null)
        {
            FileUpload1.SaveAs(Server.MapPath("img/component/" + ticks + FileUpload1.FileName));

            Utility.MsgBox("Component created successfully...!!", this.Page, this, "home.aspx");
        }
        else
        {
            Utility.MsgBox("Error: Component creation failed...!!", this.Page, this, "createcomponent.aspx");
        }            
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}