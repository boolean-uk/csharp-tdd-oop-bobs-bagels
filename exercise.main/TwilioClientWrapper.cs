using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace exercise.main
{
    public class TwilioClientWrapper
    {
        private readonly string _sid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
        public TwilioClientWrapper()
        {
            string _token = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
            TwilioClient.Init(_sid, _token);
        }
        public void SendSMS(string message)
        {
            MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber("+1234567890"),
                to: new Twilio.Types.PhoneNumber("+0987654321")
            );
        }
    }
}
