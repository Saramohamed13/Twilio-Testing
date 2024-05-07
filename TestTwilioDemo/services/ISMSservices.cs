using Twilio.Rest.Accounts;
using Twilio.Rest.Api.V2010.Account;
namespace TestTwilioDemo.services
{
    public interface ISMSservices
    {
        MessageResource sendSMS(string phoneNumber, string body);
        MessageResource sendWhatsApp(string phoneNumber, string body);
    }
}
