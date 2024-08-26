

using System.Text;

namespace BobsBagels.main
{
    public class Receipt
    {
        private StringBuilder _receiptBuilder = new();
        private int _receiptWidth = 40;

        private void BuildTitle() 
        {
            string bobsBagels = "~~~ Bob's Bagels ~~~";
            string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            _receiptBuilder.AppendLine();
            _receiptBuilder.Append(bobsBagels.PadLeft(bobsBagels.Length + 10));
            _receiptBuilder.AppendLine();
            _receiptBuilder.Append(dateTime.PadLeft(dateTime.Length + 12));
            _receiptBuilder.AppendLine();
            
        }
        private void BuilSeparator() 
        {
            _receiptBuilder.AppendLine();
            _receiptBuilder.Append("".PadRight(_receiptWidth, '-'));
            _receiptBuilder.AppendLine();
        }
        private void BuildBasket(Basket basket) 
        {
            foreach (var item in basket.Items)
            {
                string price = $"£{item.Value * item.Key.Price}";
                string quantity = $"{item.Value}".PadRight(3);
                string itemName = $"{item.Key.Variant} {item.Key.Name}";

                int rightPadding = RightPadding(price, quantity);

                _receiptBuilder.AppendLine();
                _receiptBuilder.Append(itemName.PadRight(rightPadding));
                _receiptBuilder.Append(quantity.PadRight(quantity.Length + 3));
                _receiptBuilder.Append(price);
                _receiptBuilder.AppendLine();
            }
        }

        private int RightPadding(string price, string quantity)
        {
            return _receiptWidth - price.Length - quantity.Length - 3;   
        }

        private void BuildTotal(Basket basket) 
        {
            string total = $"£{basket.Total()}";
            _receiptBuilder.Append("Total".PadRight(_receiptWidth - total.Length) + total);
            _receiptBuilder.AppendLine();
        }
        private void BuildThanks() 
        {
            string thanks = "Thank you";
            string order = "for your order!";
            _receiptBuilder.AppendLine();
            _receiptBuilder.Append(thanks.PadLeft(thanks.Length + 12));
            _receiptBuilder.AppendLine();
            _receiptBuilder.Append(order.PadLeft(order.Length + 10));

        }


        public string BuildReceipt(Basket basket) 
        {
            if (basket == null || basket.Count == 0) return "";
            BuildTitle();
            BuilSeparator();
            BuildBasket(basket);
            BuilSeparator();
            BuildTotal(basket);
            BuildThanks();
            return _receiptBuilder.ToString();
        }
    }
}
