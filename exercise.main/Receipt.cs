using exercise.main.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        #region Properties
        private List<Item> _boughtItems;
        private string _shopName;

        public List<Item> BoughtItems { get => _boughtItems; }
        public string ShopName;
        #endregion
        
        public Receipt(List<Item> boughtItems, string shopName)
        {
            _boughtItems = boughtItems;
            _shopName = shopName;
        }

        public void PrintReceipt()
        {
            double total = 0;

            Console.WriteLine($"~~~ {_shopName} ~~~\n\n" +
                $"{DateTime.Now:yyyy-mm-dd HH:mm:ss}\n\n" +
                $"----------------------------\n");

            foreach (var item in _boughtItems)
            {
                total += item.Price;
                Console.WriteLine($"{item.Variant} {item.GetType().Name} {item.Quantity} £{Math.Round(item.Price, 2)}");
            }

            Console.WriteLine("\n----------------------------\n" +
                $"Total: £{total}\n\n" +
                $"Thank you\n" +
                $"for your order!");
        }
    }
}
