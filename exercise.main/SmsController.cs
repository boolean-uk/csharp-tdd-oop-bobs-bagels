using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;

namespace exercise.main
{
    public class SmsController : TwilioController
    {
        public TwiMLResult Index(SmsRequest request)
        {
            var res = new MessagingResponse();
            res.Message(TwilioUtil.HandleNewOrder(request.Body));
            return TwiML(res);
        }

        public TwiMLResult GetAllPreviousMessages(SmsRequest request)
        {
            var res = new MessagingResponse();
            res.Message(string.Join("\n", MessageResource.Read(request.AccountSid).ToList()));
            return TwiML(res);
        }
    }
}
