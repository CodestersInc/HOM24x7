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

        if (loggedUser == null || loggedUser.UserType != "Hotel Admin")
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            int componentID = Convert.ToInt32(Request.QueryString["ID"]);
            Component component = new ComponentLogic().selectById(componentID);
            txtComponentName.Text = component.Name;
            if (component.Type == "Room") cbxIsRoom.Checked = true; else cbxIsRoom.Checked = false;
            txtDescription.Text = component.Description;
            Image1.ImageUrl = component.Image;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];
        String ticks = DateTime.Now.Ticks.ToString();

        Component component = new Component();
        component.ComponentID = Convert.ToInt32(Request.QueryString["ID"]);
        component.Name = txtComponentName.Text;
        component.Type = (cbxIsRoom.Checked) ? "Room" : "Other";
        component.Description = txtDescription.Text;
        if (FileUpload1.HasFile)
        {
            component.Image = "img/component/" + ticks + FileUpload1.FileName;
        }
        else
        {
            component.Image = new ComponentLogic().selectById(Convert.ToInt32(Request.QueryString["ID"])).Image;
        }
        component.AccountID = loggedUser.AccountID;

        int res = new ComponentLogic().update(component);

        if (res != 0)
        {
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("img/component/" + ticks + FileUpload1.FileName));
            }
            Response.Redirect("searchcomponent.aspx");
        }
        else
        {
            Server.TransferRequest("ErrorPage500.html");
        }
    }
}