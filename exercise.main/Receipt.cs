using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using basket.main;
using item.main;

namespace exercise.main
{
    public class Receipt : Basket
    {
        private List<Item> _basketItems;
        private double _totalPrice;
        private double _discountPrice;
        public Receipt(Basket basket) 
        {
            // To have acces to the basket
            _basketItems = basket.basketItems;
            _totalPrice = basket.GetTotalPrice();
            _discountPrice = basket.DiscountPrice();
        }    

        public string GetDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd, HH:mm:ss");
        }

        public string PrintListBasketItems()
        {
            // Dictionary to store amount of Items
            Dictionary<string, int> amountItems = new Dictionary<string, int>();

            // count amount of items for each item
            foreach(Item item in _basketItems)
            {
                if(amountItems.ContainsKey(item.Sku))
                {
                    amountItems[item.Sku]++;
                } 
                else
                {
                    amountItems[item.Sku] = 1;
                }
            }

            // TODO implement the DiscountPrice 
            StringBuilder sb = new StringBuilder();
            foreach (var pair in amountItems)
            {
                Item item = _basketItems.First(item => item.Sku == pair.Key);
                if (item != null)
                {
                    double totalPriceForItem = pair.Value * item.Price;
                    sb.AppendLine($"{item.Variant} {item.Name}     {pair.Value}    £ {totalPriceForItem:F2}");
                     
                    // 
                    DiscountPrice();
                    _totalPrice += totalPriceForItem;
                }
            }
   
            return sb.ToString();
        }
       
        // TODO totalPrice and discountPrice is not calculated in the print receipt
        public void PrintReceipt()
        {
            Console.WriteLine("\n     ~~~ Bob's Bagels ~~~    \n");
            Console.WriteLine($"      {GetDateTime()}       \n");
            Console.WriteLine("-------------------------------\n");
            Console.WriteLine("\n");
            Console.WriteLine(PrintListBasketItems());
            Console.WriteLine("-------------------------------\n");
            Console.WriteLine($"Discount price        £ {_discountPrice:F2}");
            Console.WriteLine($"Total                 £ {_totalPrice:F2} \n");
            Console.WriteLine("\n");
            Console.WriteLine("        Thank you \n      for your order!    \n");
        }
    }
}
