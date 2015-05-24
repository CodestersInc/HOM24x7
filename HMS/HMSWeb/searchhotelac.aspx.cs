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
        var User = Session["loggedUser"];
        if (!(User is SystemAdmin))
            Response.Redirect("login.aspx");
        SystemAdmin loggedUser = (SystemAdmin)User;

        if (loggedUser == null || Session["UserType"].ToString() != "SystemAdmin")
        {
            Response.Redirect("login.aspx?url=" + Request.Url);
        }
        if (!IsPostBack)
        {
            Repeater1.DataSource = new AccountLogic().search("", 0);
            Repeater1.DataBind();
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            AccountLogic accountLogic = new AccountLogic();
            accountLogic.delete(Convert.ToInt32(e.CommandArgument));
            Staff loggedUser = (Staff)Session["LoggedUser"];

            searchResultArea.Visible = true;
            Repeater1.DataSource = accountLogic.search("", 0);
            Repeater1.DataBind();
        }
    }
}