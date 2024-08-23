using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;

namespace exercise.main
{
    public class SmsController
    {
        private string _accountSid = "";
        private string _authToken = "";
        public SmsController(string accountSid, string authToken)
        {
            _accountSid = accountSid;
            _authToken = authToken;
        }
        
        public bool SendMessage(string sms, string phoneNumber, string phoneNumberFrom)
        {
            if (string.IsNullOrEmpty(sms) || string.IsNullOrEmpty(_accountSid) || string.IsNullOrEmpty(_authToken))
            {
                return false;
            }

            TwilioClient.Init(_accountSid, _authToken);

            var messageOptions = new CreateMessageOptions(
              new PhoneNumber(phoneNumber));
            messageOptions.From = new PhoneNumber(phoneNumberFrom);
            messageOptions.Body = sms;


            var message = MessageResource.Create(messageOptions);
            Console.WriteLine(message.Body);

            return true;
        }

        /*
        [HttpPost]
        public TwiMLResult ReceiveMessage()
        {
            var messagingResponse = new MessagingResponse();

            return TwiML(messagingResponse);
        }*/
    }
}
