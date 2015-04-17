using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class viewpayslip : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];
        if (loggedUser == null || (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff"))
        {
            Response.Redirect("login.aspx?url=" + Request.Url);
        }
        if (loggedUser.UserType != "Hotel Admin" && loggedUser.UserType != "Managerial Staff")
        {
            Response.Redirect("home.aspx");
        }
        if (!IsPostBack)
        {
            PaySlip payslip = new PaySlipLogic().selectById(Convert.ToInt32(Request.QueryString["ID"]));

            DataTable staff = new StaffLogic().getStaffMember(payslip.StaffID);
            staffInfoRepeater.DataSource = staff;
            staffInfoRepeater.DataBind();

            DateTime fromDate = payslip.FromDate;
            DateTime toDate = payslip.ToDate;
            int totalDays = Convert.ToInt32((toDate - fromDate).TotalDays);

            lblTotalDays.Text = totalDays.ToString();
            lblDaysPayable.Text = payslip.DaysPayable.ToString();

            lblBasicSalary.Text = payslip.BasicSalary.ToString();
            lblConvAllowance.Text = payslip.ConvAllowance.ToString();
            lblBonus.Text = payslip.Bonus.ToString();
            lblPF.Text = payslip.PF.ToString();
            lblProTax.Text = payslip.ProfessionalTax.ToString();
            lblIncomeTax.Text = payslip.IncomeTax.ToString();

            lblTotalEarnings.Text = (Convert.ToInt32(lblBasicSalary.Text) + Convert.ToInt32(lblConvAllowance.Text) + Convert.ToInt32(lblBonus.Text)).ToString();
            lblTotalDeduction.Text = (Convert.ToInt32(lblPF.Text) + Convert.ToInt32(lblProTax.Text) + Convert.ToInt32(lblIncomeTax.Text)).ToString();
            lblNetPay.Text = "&#8377 " + (Convert.ToInt32(lblTotalEarnings.Text) - Convert.ToInt32(lblTotalDeduction.Text)).ToString();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("createpayslip.aspx");
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

    }
}