﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.IO;
using WebUtility;

public partial class viewservicetype : System.Web.UI.Page
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
            int ServiceTypeID = Convert.ToInt32(Request.QueryString["ID"]);
            ServiceType component = new ServiceTypeLogic().selectById(ServiceTypeID);
            txtServiceTypeName.Text = component.Name;
            txtDescription.Text = component.Description;
            Image1.ImageUrl = component.Image;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];
        String ticks = DateTime.Now.Ticks.ToString();

        ServiceTypeLogic serviceTypeLogic = new ServiceTypeLogic();

        String staleImagePath = serviceTypeLogic.selectById(Convert.ToInt32(Request.QueryString["ID"])).Image;

        ServiceType serviceTypeObj = new ServiceType();
        serviceTypeObj.ServiceTypeID = Convert.ToInt32(Request.QueryString["ID"]);
        serviceTypeObj.Name = txtServiceTypeName.Text;
        serviceTypeObj.Description = txtDescription.Text;
        if (FileUpload1.HasFile)
        {
            serviceTypeObj.Image = "img/servicetype/" + ticks + FileUpload1.FileName;
        }
        else
        {
            serviceTypeObj.Image = staleImagePath;
        }
        serviceTypeObj.AccountID = loggedUser.AccountID;

        int res = serviceTypeLogic.update(serviceTypeObj);

        if (res != 0)
        {
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("img/ServiceType/" + ticks + FileUpload1.FileName));
            }
            try
            {
                File.Delete(staleImagePath);
            }
            catch (Exception)
            {
                //for now just do nothing this case may come in place if therre is 
                //no file to be deleted or the path is ""
            }
            Utility.MsgBox("Service type details updated successfully...!!", this.Page, this, "searchservicetype.aspx");
        }
        else
        {
            Utility.MsgBox("Error: Service type updation failed...!!", this.Page, this, "searchservicetype.aspx");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}