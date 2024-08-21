using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace exercise
{
    public class TextMessage
    {

        public void SendMessage(List<Product> items, decimal total)
        {
            var accountSid = "[accountSid]"; //insert when testing
            var authToken = "[authToken]"; //insert when testing
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
            new PhoneNumber("+4741424344")); //insert your own number
            messageOptions.From = new PhoneNumber("+15005550006"); //insert twilio number 
            messageOptions.Body = FormatMessage(items, total);


            var message = MessageResource.Create(messageOptions);
            //Console.WriteLine(message.Body); //For testing with test credentials
        }

        //Build the body of the message 
        private string FormatMessage(List<Product> items, decimal total)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Thank you for ordering from Bob's Bagels");
            stringBuilder.AppendLine("Please see your order summary below:\n");

            HashSet<string> processedSKUs = new HashSet<string>();
            string text = string.Empty; 

            foreach (Product item in items)
            {
                if (!processedSKUs.Contains(item.SKU))
                {
                    List<Product> sameProduct = items.FindAll(x => x.SKU == item.SKU);
                    int quantity = sameProduct.Count();
                    decimal price = sameProduct.Sum(x => x.Price);

                    stringBuilder.AppendLine($"{item.Variant} {item.Name} {quantity} £{Math.Round(price, 2)}");
                 
                    processedSKUs.Add(item.SKU);
                }
            }

            stringBuilder.AppendLine($"\nOrder Total: £{Math.Round(total, 2)}");

            DateTime deliveryTime = DateTime.Now.AddMinutes(20); //20 minute delivery time
            string formattedDelivery = deliveryTime.ToString("yyyy-MM-dd HH:mm");

            stringBuilder.AppendLine($"\nExpected delivery time: {formattedDelivery}");

            return stringBuilder.ToString();
        }
    }

}
