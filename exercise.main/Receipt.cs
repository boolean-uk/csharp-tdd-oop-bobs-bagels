using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        Dictionary<Item, int> _qty;
        public Receipt()
        {
            _qty = new Dictionary<Item, int>();

            foreach (Item item in Inventory.inventory)
                if (item.name != "Filling")
                    _qty.Add(item, 0);
        }

        public void AddAll(List<Item> items)
        {
            foreach (Item item in items)
                foreach (KeyValuePair<Item, int> itm in _qty)
                    if (itm.Key.sKU == item.sKU)
                        _qty[itm.Key] += 1;
        }


        // Terribly sorry for the state of the code below
        // I misunderstood how the discount should be calculated at first
        // and tried to rewrite the method instead of creating a new one from scratch
        //
        public float PrintReceipt(List<Item> items)
        {

            Console.WriteLine(
@"


      ~~~~~~ Bob's Bagels ~~~~~~

         " + DateTime.Now.ToString() + @"

--------------------------------------");

            float totalCost = 0f;

            float fillingCost = 0f;

            // Get cost of fillings
            foreach (Item item in items)
            {
                if (item.name == "Bagel")
                    foreach (Item filling in item.GetFillings())
                        fillingCost += filling.cost;
            }

            foreach (Item item in Inventory.inventory)
            {
                int count = items.Count(itm => itm.sKU == item.sKU);
                if (count == 0)
                    continue;
                float cost = item.cost * count;
                Console.WriteLine("{0,-22} {1,-8} {2,-7}", item.variant + " " + item.name, count, $"£{Math.Round(cost, 3)}");

                float discounted;

                if (item.name == "Bagel")
                {
                    discounted = 3.99f;

                    while (count >= 12)
                    {
                        float discount = Math.Abs((item.cost*12)-discounted);

                        Console.WriteLine($"                 12 for 3.99:  -£{Math.Round(discount, 4)}");
                        cost -= discount;
                        count -= 12;
                        for (int i = 0; i < 12; i++)
                        {
                            Item itm = items.Find(it => it.sKU == item.sKU);
                            items.Remove(itm);
                        }
                    }

                    discounted = 2.49f;

                    while (count >= 6)
                    {
                        float discount = Math.Abs((item.cost * 6) - discounted);

                        Console.WriteLine($"                  6 for 2.49:  -£{Math.Round(discount, 4)}");
                        cost -= discount;
                        count -= 6;
                        for (int i = 0; i < 6; i++)
                        {
                            Item itm = items.Find(it => it.sKU == item.sKU);
                            items.Remove(itm);
                        }
                    }
                }

                if (item.name == "Coffee")
                {
                    discounted = 1.25f;
                    while (items.Count(itm => itm.sKU == item.sKU) > 0 && items.Count(it => it.name == "Bagel") > 0)
                    {
                        Item coffeeItem = items.Find(it => it.sKU == item.sKU);
                        Item bgle = items.Find(it => it.name == "Bagel");
                        float discount = Math.Abs(coffeeItem.cost + bgle.cost - discounted);

                        Console.WriteLine($"     Coffee & Bagel for 1.25:  -£{Math.Round(discount, 4)}");
                        cost -= discount;
                        items.Remove(coffeeItem);
                        items.Remove(bgle);
                    }
                }
                
                totalCost += cost;
            }

            Console.WriteLine("{0,-22} {1,-8} {2,-8}", "Fillings", "", $"£{Math.Round(fillingCost,3)}");

            totalCost += fillingCost;

            Console.WriteLine("--------------------------------------");

            Console.WriteLine("{0,-22} {1,-8} {2,-8}", "Total", "", $"£{Math.Round(totalCost, 4)}");

            Console.WriteLine("\n      Thank you for your order!");

            return totalCost;
        }

        public Dictionary<Item, int> qty { get { return qty; } }
    }
}
