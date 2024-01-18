using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace exercise.main
{
    public class MessageService
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        public MessageService()
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            _accountSid = config["Twilio:accountSid"]!;
            _authToken = config["Twilio:authToken"]!;

            TwilioClient.Init(_accountSid, _authToken);
        }

        private void Send(string message)
        {
            var sms = MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber("+12029336384"),
                to: new Twilio.Types.PhoneNumber("+4741556615")
            );

            Console.WriteLine(sms.Sid);
        }

        public void SendOrderConfirmation(Basket basket)
        {
            StringBuilder sb = new();
            sb.AppendLine("Bob's Bagels\n");
            sb.AppendLine("Your order:\n");
            var foodGroups = basket.GetContents()
                .GroupBy(x => x.FullName)
                .Select(group => new
                {
                    Name = group.Key,
                    Count = group.Count(),
                    Price = PriceCalculator.CalculateDiscounts([..group]),
                    Discount = PriceCalculator.CalculateDiscounts([..group]) 
                });
            foreach (var group in foodGroups)
            {
                sb.AppendLine($" -{group.Name} {group.Count},  {group.Price:0.00}$");
                if (group.Discount > 0)
                {
                    sb.AppendLine($"    Discount: -({group.Discount:0.00})$");
                }
            }
            sb.AppendLine($"\nTotal: {basket.GetTotalPrice():0.00}$");
            sb.AppendLine("\nThank you for your purchase!");
            Send(sb.ToString());
        }
    }
}
