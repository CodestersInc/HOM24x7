﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.IO;
using WebUtility;

public partial class viewcomponent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var User = Session["loggedUser"];
        if (!(User is Staff))
            Response.Redirect("login.aspx");

        Staff loggedUser = (Staff)User;

        if (loggedUser == null || loggedUser.UserType != "Hotel Admin")
        {
            Response.Redirect("login.aspx");
        }

        if (!IsPostBack)
        {
            int componentID = Convert.ToInt32(Request.QueryString["ID"]);
            Component component = new ComponentLogic().selectById(componentID);
            txtComponentName.Text = component.Name;
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

        ComponentLogic componentLogic = new ComponentLogic();
        
        String staleImagePath = componentLogic.selectById(Convert.ToInt32(Request.QueryString["ID"])).Image;
        String ticks = DateTime.Now.Ticks.ToString();

        Component component = new Component();
        component.ComponentID = Convert.ToInt32(Request.QueryString["ID"]);
        component.Name = txtComponentName.Text;
        component.Description = txtDescription.Text;
        if (FileUpload1.HasFile)
        {
            component.Image = "img/component/" + ticks + FileUpload1.FileName;
        }
        else
        {
            component.Image = staleImagePath;
        }
        component.AccountID = loggedUser.AccountID;

        if (componentLogic.update(component)==1)
        {
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("img/component/" + ticks + FileUpload1.FileName));
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
            Utility.MsgBox("Component details updated successfully...!!",this.Page,this,"searchcomponent.aspx");
        }
        else
        {
            Utility.MsgBox("Error: Component updation failed...!!", this.Page, this, "searchcomponent.aspx");
        }
    }
}