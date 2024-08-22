using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace exercise.main
{
    public static class NotificationSender
    {

        public static void SendReceipt(string rec)
        {
            string accountsid = Environment.GetEnvironmentVariable("TWILIO_ACT_ID");
            string authtoken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            TwilioClient.Init(accountsid, authtoken);

            StringBuilder sb = new StringBuilder();
            DateTime now = DateTime.Now;
            DateTime pickup = now.AddMinutes(30);

            sb.AppendLine("\n\nOrder confirmation: ");
            sb.AppendLine($"Your order is ready for pickup at {pickup}\n\n");
            sb.AppendLine(rec);
            
            var message =  MessageResource.Create(
                    body: sb.ToString(),
                    from: new Twilio.Types.PhoneNumber("+16502295844"),
                    to: new Twilio.Types.PhoneNumber("+4793458577")
            );
        }
    }
}
