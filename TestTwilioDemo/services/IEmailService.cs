using TestTwilioDemo.dto;

namespace TestTwilioDemo.services
{
    public interface IEmailService
    {
        void SendEmail(Message message);
    }
}
