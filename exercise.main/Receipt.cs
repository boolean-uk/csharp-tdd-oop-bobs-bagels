

using System.Text;

namespace BobsBagels.main
{
    public class Receipt
    {
        private StringBuilder _receiptBuilder = new();

        private void BuildTitle() { throw new NotImplementedException(); }
        private void BuilSeparator() { throw new NotImplementedException(); }
        private void BuildBasket(Basket basket) { throw new NotImplementedException(); }
        private void BuildTotal() { throw new NotImplementedException(); }
        private void BuildThanks() { throw new NotImplementedException(); }
        public string BuildReceipt(Basket basket) { throw new NotImplementedException(); }
    }
}
