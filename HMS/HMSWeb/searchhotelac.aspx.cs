using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class hacsearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SystemAdmin loggedUser = (SystemAdmin)Session["LoggedUser"];
        if (loggedUser == null || Session["UserType"].ToString() != "SystemAdmin")
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Repeater1.DataSource = new AccountLogic().search(txtName.Text, 0);
        Repeater1.DataBind();
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            AccountLogic accountLogic = new AccountLogic();
            accountLogic.delete(Convert.ToInt32(e.CommandArgument));
            Staff loggedUser = (Staff)Session["LoggedUser"];
            Repeater1.DataSource = accountLogic.search(txtName.Text, 0);
            Repeater1.DataBind();
        }
    }
}