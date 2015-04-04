using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using BusinessLogic;


public partial class createplan : System.Web.UI.Page
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

        if (!IsPostBack)
        {
            componentRepeater.DataSource = new ComponentLogic().selectAll(loggedUser.AccountID);
            componentRepeater.DataBind();

            //Fill ddlFloor
            DataTable dt1 = new FloorLogic().selectFloorsWithoutPlan(loggedUser.AccountID);
            ddlFloor.DataSource = dt1;
            ddlFloor.DataValueField = "FloorID";
            ddlFloor.DataTextField = "FloorNumber";
            ddlFloor.DataBind();
            txtPlanComponentData.Text = "";
            txtPlanData.Text = "";
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        FloorPlan plan = new FloorPlanLogic().create(new FloorPlan(0,
            txtPlanData.Text,
            Convert.ToInt32(floorHiddenField.Value),
            ""));
        if (plan!=null)
        {
            String data = txtPlanComponentData.Text;
            String[] entries = data.Split('#');

            PlanComponentLogic planComponentLogic = new PlanComponentLogic();
            PlanComponent planComponent = new PlanComponent();

            for (int i = 0; i < entries.Length-1; i++)
            {
                String[] entryDetail = entries[i].Split('&');
                planComponent.RoomID = Convert.ToInt32(entryDetail[0]);
                planComponent.PlanComponentStyle = entryDetail[1];
                planComponent.PlanID = plan.PlanID;
                planComponentLogic.create(planComponent);
            }
        }
        Response.Redirect("home.aspx");
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("searchplan.aspx");
    }

    protected void createPlan_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        planBuilderPlaceHolder.Visible = true;        
        Session["CurrentFloor"] = ddlFloor.SelectedValue.ToString();
        floorHiddenField.Value = ddlFloor.SelectedValue;
        selectionRepeater.DataSource = new RoomLogic().getRooms(Convert.ToInt32(floorHiddenField.Value), loggedUser.AccountID);
        selectionRepeater.DataBind();
        floorNumberPlaceHolder.Visible = false;
    }
}