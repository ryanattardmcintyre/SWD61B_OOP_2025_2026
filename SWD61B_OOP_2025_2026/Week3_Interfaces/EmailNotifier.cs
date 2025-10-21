using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Week3_Interfaces
{
    public class EmailNotifier : INotifier, INotificationStylist
    {
        public EmailNotifier()
        {
            notifications = new List<string>();
        }

        private List<string> notifications;
        public List<string> Notifications
        {
            get { return notifications; }
        }

        public void Notify(string message)
        {
            MailMessage myEmail = new MailMessage("noreply@gmail.com", "recipient@gmail.com");
            //replace the above email address with hardcoded existent ones
            myEmail.Subject = "Default subject";
            myEmail.Body = message;
            
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = 586;
            smtpClient.Credentials = new NetworkCredential("username", "password");
            smtpClient.Send(myEmail);
        }

        public void Notify(string message, string recipient)
        {
            MailMessage myEmail = new MailMessage("noreply@gmail.com", recipient);
            //replace the above email address with hardcoded existent ones
            myEmail.Subject = "Default subject";
            myEmail.Body = message;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = 586;
            smtpClient.Credentials = new NetworkCredential("username", "password");
            smtpClient.Send(myEmail);
        }

        public void Notify(string message, string recipient, string from)
        {
            MailMessage myEmail = new MailMessage(from, recipient);
            //replace the above email address with hardcoded existent ones
            myEmail.Subject = "Default subject";
            myEmail.Body = $"<p {Style("blue")}>{message}</p>";

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = 586;
            smtpClient.Credentials = new NetworkCredential("username", "password");
            smtpClient.Send(myEmail);
        }

        public string Style(string color)
        {
            return $"style=\"color:{color}\"";
        }

        public string Style(bool bold, bool italic, bool underline)
        {
            string style = "style=\"";
            if(bold)
            {
                style += "font-weight:bold;";
            }
            style += "\"";
            return style;
        }
    }
}
