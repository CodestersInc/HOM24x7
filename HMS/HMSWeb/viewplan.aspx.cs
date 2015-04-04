using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class viewplan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["LoggedUser"];
        if (loggedUser == null || loggedUser.UserType != "Hotel Admin")
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            componentRepeater.DataSource = new ComponentLogic().selectAll(loggedUser.AccountID);
            componentRepeater.DataBind();

            selectionRepeater.DataSource = new RoomLogic().getRemainingRooms(Convert.ToInt32(Request.QueryString["ID"]));
            selectionRepeater.DataBind();

            planCanvasRepeater.DataSource = new FloorPlanLogic().getPlan(Convert.ToInt32(Request.QueryString["ID"]));
            planCanvasRepeater.DataBind();
            planComponentRepeater.DataSource = new PlanComponentLogic().selectAll(Convert.ToInt32(Request.QueryString["ID"]));
            planComponentRepeater.DataBind();
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
            if (new PlanComponentLogic().deleteAll(Convert.ToInt32(Request.QueryString["ID"]))>=0)
            {
                String data = txtPlanComponentData.Text;
                String[] entries = data.Split('#');

                PlanComponentLogic planComponentLogic = new PlanComponentLogic();
                PlanComponent planComponent = new PlanComponent();

                for (int i = 0; i < entries.Length - 1; i++)
                {
                    String[] entryDetail = entries[i].Split('&');
                    planComponent.RoomID = Convert.ToInt32(entryDetail[0]);
                    planComponent.PlanComponentStyle = entryDetail[1];
                    planComponent.PlanID = Convert.ToInt32(Request.QueryString["ID"]);
                    planComponent.ComponentID = 0;
                    planComponentLogic.create(planComponent);
                }
                Response.Redirect("home.aspx");
            }
        }
        else
        {
            Response.Redirect("ErrorPage500.html");
        }
    }
}