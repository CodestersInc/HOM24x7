﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using WebUtility;

public partial class viewplan : System.Web.UI.Page
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
            selectionRepeater.DataSource = new RoomLogic().getRemainingRooms(Convert.ToInt32(Request.QueryString["ID"]));
            selectionRepeater.DataBind();

            componentRepeater.DataSource = new ComponentLogic().selectAll(loggedUser.AccountID);
            componentRepeater.DataBind();

            planCanvasRepeater.DataSource = new FloorPlanLogic().getPlan(Convert.ToInt32(Request.QueryString["ID"]));
            planCanvasRepeater.DataBind();
            
            roomComponentRepeater.DataSource = new PlanComponentLogic().selectAllRoomComponents(Convert.ToInt32(Request.QueryString["ID"]));
            roomComponentRepeater.DataBind();

            otherComponentRepeater.DataSource = new PlanComponentLogic().selectAllOtherComponents(Convert.ToInt32(Request.QueryString["ID"]));
            otherComponentRepeater.DataBind();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["LoggedUser"];

        FloorPlan floorPlan = new FloorPlan();
        floorPlan.PlanID = Convert.ToInt32(Request.QueryString["ID"]);
        floorPlan.PlanStyle = txtPlanData.Text;
        floorPlan.Image = "";
        
        if (new FloorPlanLogic().update(floorPlan) == 1)
        {
            if (new PlanComponentLogic().deleteAll(Convert.ToInt32(Request.QueryString["ID"])) >= 0)
            {
                PlanComponentLogic planComponentLogic = new PlanComponentLogic();
                PlanComponent planComponent = new PlanComponent();

                String roomComponentData = txtRoomComponentData.Text;
                String[] rooms = roomComponentData.Split('#');

                for (int i = 0; i < rooms.Length - 1; i++)
                {
                    String[] roomDetail = rooms[i].Split('&');
                    planComponent.RoomID = Convert.ToInt32(roomDetail[0]);
                    planComponent.PlanComponentStyle = roomDetail[1];
                    planComponent.PlanID = Convert.ToInt32(Request.QueryString["ID"]);
                    planComponent.ComponentID = 0;
                    planComponentLogic.create(planComponent);
                }

                String otherComponentData = txtOtherComponentData.Text;
                String[] components = otherComponentData.Split('#');

                for (int i = 0; i < components.Length - 1; i++)
                {
                    String[] componentDetail = components[i].Split('&');
                    planComponent.RoomID = 0;
                    planComponent.PlanComponentStyle = componentDetail[1];
                    planComponent.PlanID = Convert.ToInt32(Request.QueryString["ID"]);
                    planComponent.ComponentID = Convert.ToInt32(componentDetail[0]);
                    planComponentLogic.create(planComponent);
                }
                Utility.MsgBox("Plan details updated ssuccessfully...!!", this.Page, this, "searchplan.aspx");
            }
            else
            {
                Utility.MsgBox("Error: Plan updation failed...!!", this.Page, this, "searchplan.aspx");
            }
        }
        else
        {
            Utility.MsgBox("Error: Plan updation failed...!!", this.Page, this, "searchplan.aspx");            
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}