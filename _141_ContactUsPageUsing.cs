using System;
using System.Net.Mail;
using System.Web.UI;

namespace _141_ContactUsPageUsing
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("YourGmailID@gmail.com");
                    mailMessage.To.Add("AdministratorID@YourCompany.com");
                    mailMessage.Subject = txtSubject.Text;

                    mailMessage.Body = "<b>Sender Name : </b>" + txtName.Text + "<br/>"
                        + "<b>Sender Email : </b>" + txtEmail.Text + "<br/>"
                        + "<b>Comments : </b>" + txtComments.Text;
                    mailMessage.IsBodyHtml = true;


                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new
                    System.Net.NetworkCredential("YourGmailID@gmail.com", "YourGmailPassowrd");
                    smtpClient.Send(mailMessage);

                    lblMessage.ForeColor = System.Drawing.Color.Blue;
                    lblMessage.Text = "Thank you for contacting us";

                    txtName.Enabled = false;
                    txtEmail.Enabled = false;
                    txtComments.Enabled = false;
                    txtSubject.Enabled = false;
                    Button1.Enabled = false;
                }
            }
            catch (Exception)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "There is an unkwon problem. Please try later";
            }
        }
    }
}