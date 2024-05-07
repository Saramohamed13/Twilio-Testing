using MimeKit;
using TestTwilioDemo.dto;
using MailKit.Net.Smtp;
namespace TestTwilioDemo.services
{
    public class EmailService:IEmailService
    {
        private readonly MailSettings _emailConfig;
        public EmailService(MailSettings emailConfig) => _emailConfig = emailConfig;
       

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Axnos", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $@"
                <html>
                <body>
                    
                    <img src='https://axnos.com/wp-content/uploads/2024/03/Abstract_Illustrative_Stream_Studio_Logo-removebg-preview__1_-removebg-preview-1.png'>
                       <p>{message.Content}</p>
                </body>
                </html>";
         

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(_emailConfig.Smtpserver, _emailConfig.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

                client.Send(mailMessage);
            }
            catch
            {
                //log an error message or throw an exception or both.
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
