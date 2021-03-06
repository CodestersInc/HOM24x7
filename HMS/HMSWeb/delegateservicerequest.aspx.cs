﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class delegaterequest : System.Web.UI.Page
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

        if (!IsPostBack)
        {
            DataTable dt = new ServiceRequestLogic().getPendingRequests(loggedUser.AccountID);
            if (dt.Rows.Count == 0)
            {
                RequestListPlaceHolder.Visible = false;
                noRequestsPlaceHolder.Visible = true;
            }
            else
            {
                RequestListRepeater.DataSource = dt;
                RequestListRepeater.DataBind();
            }
        }
    }

    protected void RequestListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delegate")
        {
            Staff loggedUser = (Staff)Session["loggedUser"];

            StaffListPlaceHolder.Visible = true;
            RequestListPlaceHolder.Visible = false;
            ViewState["ServiceRequestID"] = e.CommandArgument;

            StaffListRepeater.DataSource = new StaffLogic().searchManager(loggedUser.AccountID);
            StaffListRepeater.DataBind();
        }

        if (e.CommandName == "Remove")
        {
            ServiceRequestLogic servicerequestlogic = new ServiceRequestLogic();
            servicerequestlogic.delete(Convert.ToInt32(e.CommandArgument));

            Staff loggedUser = (Staff)Session["LoggedUser"];

            RequestListRepeater.DataSource = servicerequestlogic.getPendingRequests(loggedUser.AccountID);
            RequestListRepeater.DataBind();
        }
    }

    protected void StaffListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Assign")
        {
            Staff loggedUser = (Staff)Session["loggedUser"];
            
            RequestListPlaceHolder.Visible = true;

            ServiceRequestLogic serviceRequestLogic = new ServiceRequestLogic();
            ServiceRequest serviceRequestObj = serviceRequestLogic.selectById(Convert.ToInt32(ViewState["ServiceRequestID"]));

            serviceRequestObj.AssignedID = Convert.ToInt32(e.CommandArgument);
            serviceRequestObj.Status = "Assigned";

            int res = serviceRequestLogic.update(serviceRequestObj);

            RequestListRepeater.DataSource = new ServiceRequestLogic().getPendingRequests(loggedUser.AccountID);
            RequestListRepeater.DataBind();

            StaffListPlaceHolder.Visible = false;
        }
    } 
}