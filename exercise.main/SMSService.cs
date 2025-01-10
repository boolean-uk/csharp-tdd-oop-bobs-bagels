using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Threading.Tasks;

namespace exercise.main

{

    public class SMSService
    {


       

        public SMSService()
        {

        }

        public void SendSMS(string receiptMessage)
        {
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: receiptMessage,
                from: new Twilio.Types.PhoneNumber("+14159916511"),
                to: new Twilio.Types.PhoneNumber("+4790146419"));

            Console.WriteLine(message.Body);
        }
    }
}
