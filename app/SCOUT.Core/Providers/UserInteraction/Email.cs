using System.Collections.Generic;
using System.Net.Mail;

namespace SCOUT.Core.Data
{
    public static class Email
    {
        private static string m_from = "scout_ns@sts-us.net";
      
        public static void SendMail(string to, string subject, string body)
        {
            SmtpClient smtp;
            smtp = new SmtpClient("imail.sts-us.net");
            smtp.Port = 25;
            MailMessage mail = new MailMessage(m_from, to, subject, body);

            smtp.Send(mail);
            
        }
    }
}