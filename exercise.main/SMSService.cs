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
            string accountSid = "ACe8a22079a5b2c1f05a9f9eac2b9dad4d";
            string authToken = "817382517d1cd449a373228598a0096e";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: receiptMessage,
                from: new Twilio.Types.PhoneNumber("+14159916511"),
                to: new Twilio.Types.PhoneNumber("+4790146419"));

            Console.WriteLine(message.Body);
        }
    }
}
