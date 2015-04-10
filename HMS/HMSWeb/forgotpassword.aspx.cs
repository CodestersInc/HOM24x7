using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Net.Mail;

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
        int uid = 0;

        Staff staff = new StaffLogic().getUserByEmail(email);

        if (staff != null)
        {
            uid = staff.StaffID;

            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential(senderemail, senderpass);
                smtp.Timeout = 30000;

                MailMessage msg = new MailMessage(senderemail,
                    to: email, subject: "Password Recovery",
                    body: "Click on the below link to reset your password" +
                           Environment.NewLine +
                           "localhost:49306/resetpassword.aspx?ID=" + uid);

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