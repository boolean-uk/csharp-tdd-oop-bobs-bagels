/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace exercise.main
{
    public class SMSService
    {
        private string _accountSid;
        private string _authToken;

        public SMSService()
        {
            _accountSid = "AccountSID";
            _authToken = "AuthToken";
            TwilioClient.Init(_accountSid, _authToken);
        }

        public void SendSummary(Basket basket, string phoneNumber)
        {
            string message = "";
            message += "Bob's Bagels\n";
            message += "Your order:\n";

            Dictionary<string, int> counts = basket.getCount(basket.Items);
            List<string> printedSKUs = new List<string>();

            foreach (var item in basket.Items)
            {
                if (!printedSKUs.Contains(item.SKU))
                {
                    string itemName = item.GetType().Name + " " + item.Variant.ToString();
                    string quantity = counts[item.SKU].ToString();
                    double originalPrice = Math.Round(basket.GetPrice(counts[item.SKU], item.Price, false), 2);
                    double discountPrice = Math.Round(basket.GetPrice(counts[item.SKU], item.Price, true), 2);
                    string discounted = "";

                    if (discountPrice != originalPrice)
                    {
                        discounted = $"(-£{Math.Round(originalPrice - discountPrice, 2)})";
                    }

                    message += (itemName + " " + quantity + " £" + discountPrice.ToString());

                    if (discounted != "")
                    {
                        message += ("\nDiscount: "+ discounted);
                    }

                    message += "\n";

                    printedSKUs.Add(item.SKU);
                }
            }

            message += "Total: " + basket.GetTotal();
            message += "\nThank you for your purchase!";

            var SMS = MessageResource.Create
            {
                body: message;
                from: new Twilio.Types.PhoneNumber("Bobs phone number");
                to: new Twilio.Types.PhoneNumber(phoneNumber);
            };

            Console.WriteLine(SMS.Sid);
        }

    }
}*/
