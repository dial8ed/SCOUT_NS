using System;
using System.Net.Mail;

namespace SCOUT.Core.Messaging
{
    /// <summary>
    /// A message listener the outputs the message to a email
    /// </summary>
    public class EmailOutputHost : IUserMessageOutputHost
    {
        /// <summary>
        /// Constructs and sends a email from the UserMessage
        /// </summary>
        /// <param name="message">The UserMessage used to construct the email</param>
        private void SendEmail(UserMessage message)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("scout_ns@sts-us.net");
            mail.To.Add("jdial@sts-us.net");
            mail.Subject = string.Format("{0} Message Output from SCOUT NS", message.MessageType);
            mail.Body = message.Message;
            
            SmtpClient smtp = new SmtpClient("imail.sts-us.net");
            smtp.Send(mail);                    
        }

        public void ProcessMessage(UserMessageEventArgs args)
        {
            SendEmail(args.UserMessage);
        }
    }
}