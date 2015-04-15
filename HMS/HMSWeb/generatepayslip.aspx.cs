using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class generatepayslip : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];
        if (loggedUser == null || loggedUser.UserType != "Hotel Admin")
        {
            Response.Redirect("login.aspx?url=" + Request.Url);
        }
        if (loggedUser.UserType != "Hotel Admin")
        {
            Response.Redirect("home.aspx");
        }
        if (!IsPostBack)
        {
            DataTable dt = (new PaySlipLogic().getLastPaySlipGenerateDate(loggedUser.AccountID));

            txtFromDate.Text = (dt.Rows.Count > 0) ? Convert.ToDateTime(dt.Rows[0][0]).AddDays(1).ToString("dd-MM-yyyy") : DateTime.Now.ToString("dd-MM-yyyy");
            txtToDate.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
        }
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];
        DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
        DateTime toDate = Convert.ToDateTime(txtToDate.Text);
        int daysPayable = Convert.ToInt32((toDate - fromDate).TotalDays);

        DataTable staffData = new StaffLogic().getStaffForPayroll(loggedUser.AccountID);
        PaySlipLogic logic = new PaySlipLogic();

        for (int i = 0; i < staffData.Rows.Count; i++)
        {
            logic.create(new PaySlip(0,
            Convert.ToInt32(staffData.Rows[i]["StaffID"]),
            (Convert.ToDouble(staffData.Rows[i]["Salary"])) / daysPayable,
            0,
            0,
            0,
            0,
            0,
            (Convert.ToDouble(staffData.Rows[i]["Salary"])) / daysPayable,
            fromDate,
            toDate,
            daysPayable,
            DateTime.Now,
            DateTime.Now,
            loggedUser.StaffID,
            loggedUser.AccountID));
        }
        Response.Redirect("home.aspx");
    }
}