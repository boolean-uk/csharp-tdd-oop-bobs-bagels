using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;


namespace exercise.main
{
    public class Message : Receipt
    {
        private readonly string _accountSid;
        private readonly string _authToken;




        // Set environment variables

        public Message(Basket basket):base(basket)
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            _accountSid = config["Twilio_SID"]!;
            _authToken = config["Twilio_Token"]!;

            TwilioClient.Init(_accountSid, _authToken);
        }

        public void Send(string message)
        {
            var sms = MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber("+15034875253"),
                to: new Twilio.Types.PhoneNumber("+4746621718")
            );

            Console.WriteLine(sms.Sid);
        }

        public void SendReceipt(Basket basket) {

            StringBuilder sb = new();
            sb.AppendLine(_title);
            sb.AppendLine(_enter);
            sb.AppendLine($"{"",4}{_timeInfo}");
            sb.AppendLine(_line);
            sb.AppendLine(_enter);

            sb.AppendLine("Variant       Qty.    Price");
            Console.WriteLine(_enter);

            foreach (var product in _cashier)
            {
                int _qty = product.Value.qty;
                string _variant = product.Key;
                double _price = product.Value.price;
                sb.AppendLine(string.Format("{0}      {1}     {2}", _variant, _qty, _price));
                //Console.WriteLine($"{_qty},{_variant},{_price}");
                _totalPrice1 += _price * _qty;
            }
            sb.AppendLine(_enter);



            sb.AppendLine(_line);
            sb.AppendLine($"Price               £{_totalPrice1}");
            sb.AppendLine($"Discount           -£{_totalDiscount}");
            sb.AppendLine(_line);
            sb.AppendLine($"Total               £{_totalPrice}");
            sb.AppendLine(_enter);
            sb.AppendLine($"You saved a total of {_totalDiscount} \n    on this shop");
            sb.AppendLine(_enter);
            sb.AppendLine(_footer);

            Send(sb.ToString());
        }
























        /* public void SendOrderConfirmation(Basket basket)
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
                     Price = PriceCalculator.CalculateDiscounts([.. group]),
                     Discount = PriceCalculator.CalculateDiscounts([.. group])
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
         }*/


    }


}

