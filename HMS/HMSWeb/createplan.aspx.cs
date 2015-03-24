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

        if (loggedUser == null || loggedUser.UserType != "Hotel Admin")
        {
            Response.Redirect("login.aspx?url=" + Request.Url);
        }

        if (!IsPostBack)
        {
            Repeater1.DataSource = new ComponentLogic().selectAll(loggedUser.AccountID);
            Repeater1.DataBind();

            //Fill ddlFloor
            DataTable dt1 = new FloorLogic().selectFloorsWithoutPlan(loggedUser.AccountID);
            ddlFloor.DataSource = dt1;
            ddlFloor.DataValueField = "FloorID";
            ddlFloor.DataTextField = "FloorNumber";
            ddlFloor.DataBind();

            txtData.Text = "";
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }

    protected void createPlan_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];

        planBuilderPlaceHolder.Visible = true;
        //ViewState["FloorNumber"] = ddlFloor.SelectedValue.ToString();
        Session["CurrentFloor"] = ddlFloor.SelectedValue.ToString();
        floorHiddenField.Value = ddlFloor.SelectedValue;
        selectionRepeater.DataSource = new RoomLogic().getRooms(Convert.ToInt32(floorHiddenField.Value), loggedUser.AccountID);
        selectionRepeater.DataBind();
        floorNumberPlaceHolder.Visible = false;
    }
    protected void btnNewRoom_Click(object sender, EventArgs e)
    {
        Response.Redirect("createroom.aspx");
    }
}