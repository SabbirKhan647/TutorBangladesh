using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;


namespace Tutor.Public
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //Create the msg object to be sent
                MailMessage msg = new MailMessage();

                //Add your email address to the recipients
                msg.To.Add("ummebegum2013@gmail.com");


                //Configure the address we are sending the mail from
                MailAddress address = new MailAddress("ummebegum2013@gmail.com");


                msg.From = address;

                //Append their name in the beginning of the subject
                msg.Subject = txtName.Text + " email: "+txtEmail.Text +" :  " +txtsubject.Text;
                msg.Body = txtMessage.Text+"\n\n\n "+txtName.Text +"\nMobile: "+txtMobile .Text+"\n"+txtEmail .Text  ;

                //Configure an SmtpClient to send the mail.
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                client.EnableSsl = true; //only enable this if your provider requires it

                //Setup credentials to login to our sender email address ("UserName", "Password")
                NetworkCredential credentials = new NetworkCredential("ummebegum2013@gmail.com", "motijheel$$");

                client.Credentials = credentials;

                //Send the msg
                client.Send(msg);

                //Display some feedback to the user to let them know it was sent
                lblResult.Text = "Thank you for email, your message was sent. You will be contacted within 48 hours.";

                //Clear the form
                txtName.Text = "";
                txtMessage.Text = "";
                txtEmail.Text = "";
            }
            catch
            {
                //If the message failed at some point, let the user know
                lblResult.Text = "Your message failed to send, please try again.";
            }

        }
    }
}