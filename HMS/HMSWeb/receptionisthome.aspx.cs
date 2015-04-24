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
            DataTable dt = new FloorPlanLogic().getPlan(26);
            canvas.Attributes["style"] = (dt.Rows[0]["PlanStyle"].ToString());            

            roomComponentRepeater.DataSource = new PlanComponentLogic().selectAllRoomComponents(26);
            roomComponentRepeater.DataBind();

            otherComponentRepeater.DataSource = new PlanComponentLogic().selectAllOtherComponents(26);
            otherComponentRepeater.DataBind();
        }
    }
}