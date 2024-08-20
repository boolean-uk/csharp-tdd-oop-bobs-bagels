using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.AspNet.Common;
using Twilio.TwiML;
using Twilio.TwiML.Fax;
using exercise.main;


namespace exercise.main
{
    [Route("api/TwilioController")]
    [ApiController]
    public class TwilioController
    {

        private Basket _basket;

        public TwilioController(Basket basket)
        {
            _basket = basket;
        }
        [HttpPost("orderBySms")]
        public IActionResult OrderBySms([FromForm] SmsRequest incomingMessage)
        {

           
            var sentFrom = incomingMessage.From;
            var body = incomingMessage.Body;
            var response = _basket.receiveSmsOrder(sentFrom, body);

            var messagingResponse = new MessagingResponse();
            messagingResponse.Message(response);

            return new ContentResult
            {
                Content = messagingResponse.ToString(),
                ContentType = "application/xml"
            };
        }

    }
}
