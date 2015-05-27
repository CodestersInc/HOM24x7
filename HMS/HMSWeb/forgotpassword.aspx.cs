using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Net.Mail;
using System.Web.UI.HtmlControls;
using WebUtility;

public partial class forgotpassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        String senderemail = "hom24x7.codesters@gmail.com";
        String senderpass = "hom24x7926601";

        String email = txtEmail.Text;       
        String uname = null, pass = null;

        Staff staff = new StaffLogic().getUserByEmail(email);

        if (staff != null)
        {
            uname = staff.Username;
            pass = staff.Password;
        }
        else
        {
            Customer customer = new CustomerLogic().getUserByEmail(email);
            if (customer != null)
            {
                uname = customer.Username;
                pass = customer.Password;
            }
            else
            {
                Utility.MsgBox("Error: Email ID isn't registered with the system...!!", this.Page, this, "forgotpassword.aspx");
            }
        }

        String resetlink = "localhost:49306/resetpassword.aspx?attr1=" + uname + "&attr2=" + pass;

        SmtpClient smtp = new SmtpClient();
        MailMessage msg = new MailMessage();
        try
        {
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new System.Net.NetworkCredential(senderemail, senderpass);
            smtp.Timeout = 30000;

            msg.From = new MailAddress(senderemail);
            msg.To.Add(new MailAddress(email));
            msg.Subject = "Password Recovery";
            msg.IsBodyHtml = true;

            msg.Body = "Click on the below link to reset your password" +
                       "<br>" +
                       string.Format("<a href='http://hom24x7.somee.com/resetpassword.aspx?attr1={0}&attr2={1}'>Password Reset Link</a>", uname, pass);

            smtp.Send(msg);

            Utility.MsgBox("Password verification link has been sent to your email address...!!", this.Page, this, "login.aspx");
        }
        catch (Exception ex)
        {
            Utility.MsgBox("Error: Email sending failed...!!", this.Page, this, "forgotpassword.aspx");
        }        
    }
}