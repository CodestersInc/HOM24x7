using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Net.Mail;
using System.Web.UI.HtmlControls;

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

        Staff staff = new StaffLogic().getUserByEmail(email);

        if (staff != null)
        {
            String uname = staff.Username;
            String pass = staff.Password;
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

                Response.Redirect("login.aspx");

            }
            catch (Exception ex)
            {
                errorLbl.Text = "" + ex;
            }
        }
        else
        {
            errorLbl.Text = "Email address doesn't exist...!!";
        }
    }
}