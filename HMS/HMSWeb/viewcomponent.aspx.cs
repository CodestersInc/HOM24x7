using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class viewcomponent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        if (loggedUser == null || loggedUser.UserType != "HotelAdmin")
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            int componentID = Convert.ToInt32(Request.QueryString["ID"]);
            Component component = new ComponentLogic().selectById(componentID);
            txtComponentName.Text = component.Name;
            txtDescription.Text = component.Description;
            if (component.Type == "Room") radioYes.Checked = true; else radioNo.Checked = true;
        }
        

        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        String ticks = DateTime.Now.Ticks.ToString();
        int componentID = Convert.ToInt32(Request.QueryString["ID"]);

        String Type = (radioYes.Checked) ? "Room" : "Other";

        int res = new ComponentLogic().update(new Component(componentID,
            txtComponentName.Text,
            Type,
            txtDescription.Text,
            "img/component/" + ticks + FileUpload1.FileName,
            loggedUser.AccountID));

        if (res != 0)
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