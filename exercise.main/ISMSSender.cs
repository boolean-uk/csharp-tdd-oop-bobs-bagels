using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    // Interface for our SMS sender, the SMS app will implement this in the
    // TwilioReceive project, in Program.cs...

    // Everything in the SMS app is implemented as static, due to easier access to
    // methods and variables globally in the project... could've maybe also designed
    // them to be non-static? Too late now!

    // In any case, we aren't really passing an ISMSSender interface around,
    // we are simply declaring what methods classes implementing SMSSender should have...
    public interface ISMSSender
    {
        public static abstract Task SendSMS(string message);
        public static abstract string SMSBuilder(Basket basket);
    }
}
