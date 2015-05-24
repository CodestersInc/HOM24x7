using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class receptionisthome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            planCanvasRepeater.DataSource = new FloorPlanLogic().getPlan(26);
            planCanvasRepeater.DataBind();

            DataTable dt = new PlanComponentLogic().selectAllRoomComponents(26);

            RoomLogic roomLogic = new RoomLogic();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string status = roomLogic.selectById(Convert.ToInt32(dt.Rows[i]["RoomID"])).Status;
                string color = null;
                switch (status)
                {
                    case "Booked": color = "#607D8B";
                        break;
                    case "Empty": color = "#4CAF50";
                        break;
                    case "Occupied": color = "#C0CA33";
                        break;
                    case "Under Maintenance": color = "#795548";
                        break;
                }
                dt.Rows[i]["PlanComponentStyle"] = dt.Rows[i]["PlanComponentStyle"].ToString().Replace("gray", color);
            }

            roomComponentRepeater.DataSource = dt;
            roomComponentRepeater.DataBind();

            otherComponentRepeater.DataSource = new PlanComponentLogic().selectAllOtherComponents(26);
            otherComponentRepeater.DataBind();
        }
    }
}