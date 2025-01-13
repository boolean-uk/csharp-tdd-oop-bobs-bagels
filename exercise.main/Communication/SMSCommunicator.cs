using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.SMS;

namespace exercise.main.Communication
{
    public class SMSCommunicator : ICommunicator
    {
        public void Send(string message)
        {
            //Likely to recieve this from session data or something simmilar(?)
            string number = "123456789";
            TwilioClient.SendSMS(number, message);
        }
    }
}
