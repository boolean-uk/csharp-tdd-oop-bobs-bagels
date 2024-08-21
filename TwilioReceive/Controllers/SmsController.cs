using exercise.main;
using Microsoft.IdentityModel.Tokens;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace TwilioReceive.Controllers
{
    public class SmsController : TwilioController
    {
        public TwiMLResult Index(SmsRequest incomingMessage)
        {
            ;
            Basket basket = TwilioApp.BagelShop.GrabBasket();

            // really simple, can only order one bagel at a time,
            // toppings have to be ordered seperately, disaster...
            string order = "";
            if (string.IsNullOrEmpty(incomingMessage.Body)) order = "BGLO";
            else order = incomingMessage.Body;

            bool result = basket.Add(order);

            // Get the phone number from the incoming message so we can store the msg
            string phoneNr = "";
            if (string.IsNullOrEmpty(incomingMessage.From)) phoneNr = "12345678";
            else phoneNr = incomingMessage.From;

            // Create a response...
            var messagingResponse = new MessagingResponse();
            string message = "";
            if (result) message = TwilioApp.SMSBuilder(basket);
            if (!result) message = "Your order was not accepted, sorry...";

            // Add the messages to the message history...
            TwilioApp.AddMessageHistory(phoneNr, order, "Incoming");
            TwilioApp.AddMessageHistory(phoneNr, message, "Outgoing");

            // Return the response...
            messagingResponse.Message(message);
            return TwiML(messagingResponse);
        }
    }
}
