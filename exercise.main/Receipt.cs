using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        private Dictionary<ItemDto, int> _amountOfItems;
        private double _totalCost;
        private double _totalCostWithoutDiscount;

        public Receipt(Basket basket)
        {
            _amountOfItems = basket.GetItemAmounts();
            _totalCost = basket.GetTotalCost();
            _totalCostWithoutDiscount = basket.GetTotalCostWithoutDiscount();
        }
        
        public string GetCurrentDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

      

        public string PrintItemAmounts()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(KeyValuePair<ItemDto, int> item in _amountOfItems)
            {
                stringBuilder.Append($"{item.Key.Name} {item.Key.Variant}       {item.Value} x {item.Key.Price} \n") ;
            }
            return stringBuilder.ToString();
        }

        public void PrintReceipt()
        {
            Console.WriteLine("\n~~~ Bob's Bagels ~~~\n");
            Console.WriteLine(GetCurrentDateTime());
            Console.WriteLine("\n--------------------\n");
            Console.WriteLine(PrintItemAmounts());
            Console.WriteLine("--------------------");
            Console.WriteLine($"          {_totalCostWithoutDiscount}");
            Console.WriteLine($"Discount: {Math.Round(_totalCostWithoutDiscount - _totalCost, 2)}");
            Console.WriteLine("--------------------");
            Console.WriteLine($"Total:    {_totalCost}\n");
            Console.WriteLine("Thank you");
            Console.WriteLine("for your order!");

        }
    }
}
