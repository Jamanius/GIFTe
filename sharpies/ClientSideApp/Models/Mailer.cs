using System.Net.Mail;


namespace ClientSideApp.Models
{
    public class Mailer
    {
        public void Send(string address, string subject, string body, int giftId)
        {
            MailMessage mail = new MailMessage();

            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Credentials = new System.Net.NetworkCredential("userName", "password");
            smtpServer.Port = 587; // Gmail works on this port

            //need to set up an email address to send these thing from.
            mail.From = new MailAddress("myemail@gmail.com");
            mail.To.Add(address);
            mail.Subject = subject;
            mail.Body = body;
           // mail.GiftId = giftId;

            smtpServer.Send(mail);
        }
    }
}