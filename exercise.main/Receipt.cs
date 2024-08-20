using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        private Dictionary<Item, int> _items;
        private List<Discount> _discounts;

        public int ID { get; set; }

        public Receipt(Basket basket)
        {
            _items = basket.Items;
            _discounts.Add(new Discount("BGLO", 6, 2.49f));
            _discounts.Add(new Discount("BGLP", 12, 3.99f));
            _discounts.Add(new Discount("BGLE", 6, 2.49f));
            _discounts.Add(new Discount("COFB", 1, 1.25f));
        }

        public string PrintReceipt()
        {
            float total = 0;
            float itemTotal = 0;
            StringBuilder message = new StringBuilder();

            if (_items.Count() == 0)
            {
                message.Append("No items in basket!");
                Console.Write(message.ToString());
                return message.ToString();
            }

            message.Append("    ~~~ Bob's Bagels ~~~\n\n");
            message.Append($"    {DateTime.Now}\n\n");
            message.Append("----------------------------\n\n");

            foreach (Item item in _items.Keys)
            {
                if (_items[item] > 0)
                {
                    message.Append($"{item.Name}\t\t");
                    message.Append($"{_items[item]}".PadRight(5));
                    itemTotal = item.Price * _items[item];
                    message.Append($"£{itemTotal}\n");
                    total += itemTotal;
                }
            }

            message.Append("\n----------------------------\n");
            message.Append($"Total\t\t".PadRight(12));
            message.Append($"£{total}\n\n");
            message.Append("\t  Thank you\n\tfor you order!\n");

            Console.Write(message.ToString());

            return message.ToString();
        }

        public Dictionary<Item, int> Items { get { return _items; } }
        public List<Discount> Discounts { get { return _discounts; } }
    }
}
