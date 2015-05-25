using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using WebUtility;

public partial class generatepayslip : System.Web.UI.Page
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
        DataTable staffData = null;
        PaySlipLogic paysliplogic = new PaySlipLogic();

        int daysPayable;
        double monthlysalary;
        double basic;

        if (loggedUser.UserType == "Hotel Admin")
        {
            staffData = new StaffLogic().getStaffForPayroll(loggedUser.AccountID, fromDate, toDate);                       

            for (int i = 0; i < staffData.Rows.Count; i++)
            {
                daysPayable = new AttendanceLogic().getPayableDaysForStaff(fromDate, toDate, Convert.ToInt32(staffData.Rows[i]["StaffID"]));
                monthlysalary = (Convert.ToDouble(staffData.Rows[i]["Salary"]));
                basic = Math.Abs((monthlysalary / 30) * daysPayable);

                if(paysliplogic.create(new PaySlip(0,
                Convert.ToInt32(staffData.Rows[i]["StaffID"]),
                basic,
                0,
                0,
                0,
                0,
                0,
                basic,
                fromDate,
                toDate,
                daysPayable,
                DateTime.Now,
                DateTime.Now,
                loggedUser.StaffID,
                loggedUser.AccountID)) != null)
                {
                    Utility.MsgBox("Payslip generated successfully...!!", this.Page, this);
                }
                else
                {
                    Response.Redirect("ErrorPage500.html");
                }
            }
        }

        if (loggedUser.UserType == "Managerial Staff")
        {
            staffData = new StaffLogic().getStaffForPayroll(loggedUser.DepartmentID,loggedUser.AccountID, fromDate, toDate);

            for (int i = 0; i < staffData.Rows.Count; i++)
            {
                daysPayable = new AttendanceLogic().getPayableDaysForStaff(fromDate, toDate, Convert.ToInt32(staffData.Rows[i]["StaffID"]));

                if (daysPayable == 0)
                {
                    continue;
                }
                else
                {
                    monthlysalary = (Convert.ToDouble(staffData.Rows[i]["Salary"]));
                    basic = Math.Abs((monthlysalary / 30) * daysPayable);

                    if(paysliplogic.create(new PaySlip(0,
                    Convert.ToInt32(staffData.Rows[i]["StaffID"]),
                    basic,
                    0,
                    0,
                    0,
                    0,
                    0,
                    basic,
                    fromDate,
                    toDate,
                    daysPayable,
                    DateTime.Now,
                    DateTime.Now,
                    loggedUser.StaffID,
                    loggedUser.AccountID)) != null)
                    {
                        Utility.MsgBox("Payslip generated successfully...!!", this.Page, this);
                    }
                    else
                    {
                        Response.Redirect("ErrorPage500.html");
                    }
                }                
            }
        }
    }
}