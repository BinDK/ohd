using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Project3.Utils
{
    public class Utils
    {
        public static void SendMail(string from, string to, string subject, string body,string userName, string password)
        {
            MailMessage mailMessage = new MailMessage(from, to, subject, body);
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.IsBodyHtml = true;

            using var stmpClient = new SmtpClient("smtp.gmail.com");
            stmpClient.Port = 587;
            stmpClient.EnableSsl = true;
            stmpClient.Credentials = new NetworkCredential(userName,password);
            try
            {
                stmpClient.Send(mailMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
