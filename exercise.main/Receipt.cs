using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        private int _id;
        private Dictionary<Item, int> _items = new Dictionary<Item, int>();

        public int ID { get { return _id; } }

        public Receipt(Basket basket, int id)
        {
            _items = basket.Items;
            _id = id;
        }

        public void PrintReceipt()
        {
            float total = 0;
            float itemTotal = 0;

            Console.WriteLine("    ~~~ Bob's Bagels ~~~\n");
            Console.WriteLine($"    {DateTime.Now}\n");
            Console.WriteLine("----------------------------\n");

            foreach (Item item in _items.Keys)
            {
                Console.Write($"{item.Name}\t\t");
                Console.Write($"{_items[item]}".PadRight(5));

                itemTotal = item.Price * _items[item];
                Console.Write($"£{itemTotal}\n");

                total += itemTotal;
            }

            Console.WriteLine("\n----------------------------");
            Console.Write($"Total\t\t".PadRight(12));
            Console.WriteLine($"£{total}\n");
            Console.WriteLine("\t  Thank you\n\tfor you order!");
        }
    }
}
