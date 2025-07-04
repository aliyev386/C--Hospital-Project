using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Helpers
{
    public static class GmailSender
    {
        public static void SendEmailWithAttachment(string toEmail, string subject, string body, string filePath)
        {
            string fromEmail = "aliyevomer386@gmail.com";
            string appPassword = "uoir wrgz xdxw pnry";

            MailMessage mail = new MailMessage(fromEmail, toEmail, subject, body);
            mail.Attachments.Add(new Attachment(filePath));

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(fromEmail, appPassword);
            smtp.Send(mail);
        }
    }
}
