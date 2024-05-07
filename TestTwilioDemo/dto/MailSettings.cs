namespace TestTwilioDemo.dto
{
    public class MailSettings
    {
        public string From { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
        public string Smtpserver { get; set; }

        public int Port { get; set; }
    }
}
