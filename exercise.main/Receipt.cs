using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        private string _nameOfBranch;
        private Customer _customer;
        private DateTime _dateTime;
        public Receipt(string nameOfBranch, Customer customer)
        {
            _nameOfBranch = nameOfBranch;
            _customer = customer;
            _dateTime = DateTime.Now;
        }

        // For now: can create 1 list with all items. 
        // Can turn this list to have the special offer and the price of this
        // Can print out with less items if there is a special offer
        // Add amount
        public void PrintReceipt()
        {
            Console.WriteLine($"          ~~~{_nameOfBranch}~~~          \n");
            Console.WriteLine($"          {_dateTime}                \n");
            Console.WriteLine("   ------------------------------------------- \n");
            _customer.basket.AddDiscountIfThereIs();
            List<Item> toPrint = OrganizeBasketInGroups();
            foreach (Item item in toPrint)
            {
                int amount = 0;
                Item defaultItem = DefaultInventory.FindItemInInventoryBySKU(item.Sku);
                Item defaultSOItem = DefaultInventory.FindItemInSpecialOffersBySKU(item.Sku);
                if (defaultItem != null && item.Sku == defaultItem.Sku)
                {
                    amount += (int)Math.Round(item.Price / defaultItem.Price);
                } else if (defaultSOItem != null && item.Sku == defaultSOItem.Sku)
                {
                    amount += (int)Math.Round(item.Price / defaultSOItem.Price);
                }

                Console.WriteLine($"{amount}   {item.Variant.PadRight(30)} {item.Price}\n");
            }
            double total = Math.Round(_customer.basket.SumTotal(),2);
            Console.WriteLine("   ------------------------------------------- \n");
            Console.WriteLine($"Total                                    {total}");
            Console.WriteLine("                     Thank you                 ");
            Console.WriteLine("                  For your order!                   ");

        }

        public List<Item> OrganizeBasketInGroups(){
            List<Item> organized = _customer.basket.items
                .GroupBy(item => item.Sku)
                .Select(group => new Item(
                        sku: group.First().Sku,
                        price: group.Sum(item => item.Price),
                        name: group.First().Name,
                        variant: group.First().Variant
                    )).ToList();
            
            return organized;
        }

    }
}
