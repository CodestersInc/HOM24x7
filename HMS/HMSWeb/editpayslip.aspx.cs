using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class editpayslip : System.Web.UI.Page
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

            txtBasicSalary.Text = payslip.BasicSalary.ToString();
            txtConvAllowance.Text = payslip.ConvAllowance.ToString();
            txtBonus.Text = payslip.Bonus.ToString();
            txtPF.Text = payslip.PF.ToString();
            txtProTax.Text = payslip.ProfessionalTax.ToString();
            txtIncomeTax.Text = payslip.IncomeTax.ToString();

            lblTotalEarnings.Text = (Convert.ToInt32(txtBasicSalary.Text) + Convert.ToInt32(txtConvAllowance.Text) + Convert.ToInt32(txtBonus.Text)).ToString();
            lblTotalDeduction.Text = (Convert.ToInt32(txtPF.Text) + Convert.ToInt32(txtProTax.Text) + Convert.ToInt32(txtIncomeTax.Text)).ToString();
            lblNetPay.Text = "&#8377 " + (Convert.ToInt32(lblTotalEarnings.Text) + Convert.ToInt32(lblTotalDeduction.Text)).ToString();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("searchpayslip.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Staff loggedUser = (Staff)Session["loggedUser"];
        String[] str = lblNetPay.Text.Split(null);
        double netPay = Convert.ToDouble(str[1]);

        PaySlip payslip = new PaySlip();
        payslip.PaySlipID = Convert.ToInt32(Request.QueryString["ID"]);
        payslip.BasicSalary = Convert.ToDouble(txtBasicSalary.Text);
        payslip.ConvAllowance = Convert.ToDouble(txtConvAllowance.Text);
        payslip.Bonus = Convert.ToDouble(txtBonus.Text);
        payslip.PF = Convert.ToDouble(txtPF.Text);
        payslip.ProfessionalTax = Convert.ToDouble(txtProTax.Text);
        payslip.IncomeTax = Convert.ToDouble(txtIncomeTax.Text);
        payslip.NetPay = netPay;
        payslip.ApproverID = loggedUser.StaffID;
        payslip.AccountID = loggedUser.AccountID;

        if (new PaySlipLogic().update(payslip) == 1)
        {
            Response.Redirect("searchpayslip.aspx");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {        
        lblTotalEarnings.Text = (Convert.ToInt32(txtBasicSalary.Text) + Convert.ToInt32(txtConvAllowance.Text) + Convert.ToInt32(txtBonus.Text)).ToString();
        lblTotalDeduction.Text = (Convert.ToInt32(txtPF.Text) + Convert.ToInt32(txtProTax.Text) + Convert.ToInt32(txtIncomeTax.Text)).ToString();
        lblNetPay.Text = "&#8377 " + (Convert.ToInt32(lblTotalEarnings.Text) - Convert.ToInt32(lblTotalDeduction.Text)).ToString();

        btnUpdate.Visible = true;
        btnSave.Visible = false;
        txtBasicSalary.ReadOnly = true;
        txtConvAllowance.ReadOnly = true;
        txtBonus.ReadOnly = true;
        txtPF.ReadOnly = true;
        txtProTax.ReadOnly = true;
        txtIncomeTax.ReadOnly = true;
    }
}