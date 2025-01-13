using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace exercise.main
{
    public class Receipt
    {
        private Basket _basket;
        private string _receipt;

        public Receipt(Basket basket)
        {
            this._basket = basket;
            this._receipt = getRecipt();
        }

        private string getRecipt()
        {
            string receipt = $"    ~~~ Bob's Bagels ~~~    \n\n    {DateTime.Now.ToString()}    \n\n----------------------------\n\n";
            

            foreach (Item item in _basket.Items)
            {
                string linereceipt = $"{item.GetItemName() + new String(' ', (23 - item.GetItemName().Length))}${
                    item.GetItemCost()}\n";
                receipt += linereceipt ;
                if (item.GetType() == typeof(Bagel))
                {
                    Bagel bagel = (Bagel)item;
                    foreach(Filling filling in bagel.Fillings)
                    {
                        receipt += $" Filling:{new String(' ', 19 - filling.Name.Length)}{filling.Name}\n";
                    }
                }
                if (item.GetType() == typeof(Discount))
                {
                    Discount discount = (Discount)item;
                    receipt += $"{new String(' ', 22)}({Math.Round(discount.GetOriginalPrice() - discount.GetItemCost(), 2)})\n";
                }
            }
            receipt += "\n----------------------------\n\n";
            receipt += $"Total                  {_basket.GetCost()}\n";
            return receipt;
        }

        public bool printReceipt()
        {
            Console.WriteLine(_receipt);
            return true;
        }
        public bool sendReceipt()
        {
            var accountSid = "Fill in here";
            var authToken = "Fill in here";
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
              new PhoneNumber("+4741583032"));
            messageOptions.From = new PhoneNumber("+12564877399");
            messageOptions.Body = _receipt;


            var message = MessageResource.Create(messageOptions);
            Console.WriteLine(message.Body);
            return true;
        }
    }
}