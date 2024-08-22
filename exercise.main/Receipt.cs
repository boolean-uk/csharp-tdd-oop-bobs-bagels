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
        private double _total;

        public List<Item> BoughtItems { get => _boughtItems; }
        public string ShopName;
        public double Total { get => _total; }
        #endregion
        
        public Receipt(List<Item> boughtItems, string shopName, double total)
        {
            _boughtItems = boughtItems;
            _shopName = shopName;
            _total = total;
        }

        public void PrintReceipt()
        {
            Console.WriteLine($"~~~ {_shopName} ~~~\n\n" +
                $"{DateTime.Now:yyyy-mm-dd HH:mm:ss}\n\n" +
                $"----------------------------\n");

            foreach (var item in _boughtItems)
            {
                Console.WriteLine($"{item.Variant} {item.GetType().Name}".PadRight(27) + $"{item.Quantity}".PadRight(4) + $"£{Math.Round(item.Price, 2)}");

                if (item is Bagel bagel)
                {
                    if (bagel.Fillings.Count > 0)
                    {
                        foreach (Filling filling in bagel.Fillings) 
                        {
                            Console.WriteLine($"|=> {filling.Variant} {filling.GetType().Name}".PadRight(27) + $"{filling.Quantity}".PadRight(3) + $" £{Math.Round(filling.Price, 2)}");
                        }
                    }
                }
            }

            Console.WriteLine("\n----------------------------\n" +
                $"Total: £{_total}\n\n" +
                $"Thank you\n" +
                $"for your order!");
        }
    }
}
