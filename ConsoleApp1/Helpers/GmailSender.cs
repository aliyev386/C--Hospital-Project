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
        public static void SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                string fromEmail = "aliyevomer386@gmail.com";
                string appPassword = "hawt heay olud qvyr";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromEmail);
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(fromEmail, appPassword);

                smtp.Send(mail);

                Console.WriteLine("Email sended successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while sending the email: {ex.Message}");
            }
        }
    }
}
