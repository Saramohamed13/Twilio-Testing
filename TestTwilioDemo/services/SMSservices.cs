using Microsoft.Extensions.Options;

using TestTwilioDemo.General_settings;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TestTwilioDemo.services
{
    public class SMSservices:ISMSservices
    {
        private readonly TwilioSetting _twilio;

        public SMSservices(IOptions<TwilioSetting> twilio)
        {
            _twilio = twilio.Value;
        }
   

        public MessageResource sendSMS(string phoneNumber, string body)
        {
            TwilioClient.Init(_twilio.AccountSID, _twilio.AuthToken);

            var result = MessageResource.Create(
                    body: body,
                    from: new Twilio.Types.PhoneNumber(_twilio.TwilioPhoneNumber),
                    to: phoneNumber
                );

            return result;
        }

        public MessageResource sendWhatsApp(string phoneNumber, string body)
        {
            TwilioClient.Init(_twilio.AccountSID, _twilio.AuthToken);
            var messageOptions = new CreateMessageOptions(new PhoneNumber("whatsapp:+201207783584"));
            messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
            messageOptions.Body = "test saraaaaaa";
            var message = MessageResource.Create(messageOptions);
            return message;
         
        }
    }
}
