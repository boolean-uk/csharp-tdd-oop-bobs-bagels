using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        Inventory inventory;
        public Receipt()
        {
            inventory = new Inventory();
        }

        public void PrintReceipt(Basket basket)
        {
            //this info is always on a receipt
            StringBuilder receipt = new StringBuilder();
            receipt.AppendLine("\n    ~~~ Bob's Bagels ~~~");
            receipt.AppendLine($"\n    {DateTime.Now}");
            receipt.AppendLine("\n----------------------------\n");

            //here we look through the basket
            // string is the product sku, int is the amount of times it occurs
            Dictionary<string, int> order = new Dictionary<string, int>();

           foreach(var item in basket.basket)
           {
                if(!order.ContainsKey(item.coffeeOrBagel))
                {
                    order.Add(item.coffeeOrBagel, 1); //adds first
                }
                else
                {
                    order[item.coffeeOrBagel]++; //adds another
                }
                if (!order.ContainsKey(item.filling) && item.filling != string.Empty)
                {
                    order.Add(item.filling, 1); //adds first
                }
                else if(item.filling != string.Empty)
                {
                    order[item.filling]++; //adds another
                }
            }
           foreach(var item in order)
           {
                double cost = inventory.GetPrice(item.Key);
                string realProductName = $"{inventory.GetNameAndVariant(item.Key).variant} {inventory.GetNameAndVariant(item.Key).name}";
                receipt.Append($"{realProductName}");
                for(int i = 0; i <  19 - realProductName.Length; i++)
                {
                    receipt.Append(" ");
                }
                receipt.Append($"{item.Value}");
                for (int i = 0; i < 4 - item.Value.ToString().Length; i++)
                {
                    receipt.Append(" ");
                }
                receipt.AppendLine($"£{Math.Round(cost * item.Value, 2)}");

                //here discounts are printed for each item.
                if(basket.discounts.ContainsKey(item.Key) &&
                    Math.Round(basket.discounts[item.Key], 2) > 0.0)
                {
                    //item is here and discount exists
                    for(int i = 0; i < 25 - Math.Round(basket.discounts[item.Key], 2).ToString().Length; i++)
                    {
                        receipt.Append(" ");
                    }
                    receipt.AppendLine($"(-£{Math.Round(basket.discounts[item.Key], 2)})");
                    
                    //because of how discounts are applied, some need to be 0'd out
                    if(item.Key == "BGLO" || item.Key == "BGLE" || item.Key == "BGLS")
                    {
                        basket.discounts["BGLO"] = 0.0;
                        basket.discounts["BGLS"] = 0.0;
                        basket.discounts["BGLE"] = 0.0;
                    }
                }
            }

            receipt.AppendLine($"\n----------------------------");
            receipt.Append($"Total");

            double costTotal = basket.ShowCost();
            //turns out it already applies discouts so extension 2+3 at the same time it is
            for (int i = 0; i < 23 - costTotal.ToString().Length; i++)
            {
                receipt.Append(" ");
            }
            receipt.AppendLine($"£{costTotal}\n");
            receipt.AppendLine($"You saved a total of £{basket.GetDiscount()}\n      on this shop");
            receipt.AppendLine("\n        Thank you\n      for your order!");


            Console.WriteLine(receipt.ToString());
        }
    }
}
