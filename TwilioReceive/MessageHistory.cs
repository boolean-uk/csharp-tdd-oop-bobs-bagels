namespace TwilioReceive
{
    public class MessageHistory
    {
        private string _phoneNr;
        private List<string> _incomingMessages = new List<string>();
        private List<string> _outgoingMessages = new List<string>();

        public MessageHistory(string phoneNr)
        {
            _phoneNr = phoneNr;
        }

        public string PhoneNr { get { return _phoneNr; } }
        public List<string> IncomingMessages { get { return _incomingMessages; } }
        public List<string> OutgoingMessages { get { return _outgoingMessages; } }
    }
}
