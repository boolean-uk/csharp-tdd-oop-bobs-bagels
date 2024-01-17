using Microsoft.AspNetCore.Mvc;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;

namespace exercise.main
{
    /// <summary>
    /// Api endpoint for SMS
    /// </summary>
    [ApiController]
    [Route("sms")]
    public class SmsController : TwilioController
    {
        /// <summary>
        /// Order by SKU from Bagel store. Request.Body should be of form: "BGLO, COFW, ..."
        /// </summary>
        /// <param name="request">Order by SKU from Bagel store. Request.Body should be of form: "BGLO, COFW, ...</param>
        /// <returns></returns>
        [HttpPost]
        public TwiMLResult CreateOrder(SmsRequest request)
        {
            var res = new MessagingResponse();
            res.Message(TwilioUtil.HandleNewOrder(request.Body));
            return TwiML(res);
        }

        /// <summary>
        /// Get all the previous messages from SId.
        /// </summary>
        /// <param name="SId"></param>
        /// <returns></returns>
        [HttpGet("{SId}")]
        public TwiMLResult GetAllPreviousMessages(string SId)
        {
            var res = new MessagingResponse();
            var content = MessageResource.Read(SId).ToList();
            if (content.Count > 0)
            {
                res.Message(string.Join("\n", content));
            }
            else
            {
                res.Message($"No messages found for SId: {SId}");
            }
            return TwiML(res);
        }

        /// <summary>
        /// Simplified Order for testing.
        /// </summary>
        /// <param name="content">Body should be a list of valid SKU</param>
        /// <returns></returns>
        [HttpPost("simple")]
        public TwiMLResult SimpleCreateOrder(List<string> content)
        {
            var res = new MessagingResponse();
            res.Message(TwilioUtil.HandleNewOrder(string.Join(",", content)));
            return TwiML(res);
        }
    }
}
