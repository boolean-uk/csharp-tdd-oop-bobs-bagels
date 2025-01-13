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

        public float PrintReceipt(List<Item> items)
        {
            float totalCost = 0f;

            float fillingCost = 0f;

            List<Item> coffeeLeft = new List<Item>();
            foreach (Item item in items)
                if (item.name == "Coffee")
                {
                    coffeeLeft.Add(item);
                }

            foreach (Item item in Inventory.inventory)
            {
                int count = items.Count(itm => itm.sKU == item.sKU);
                if (count == 0)
                    continue;
                float cost = item.cost * count;
                Console.WriteLine("{0,-22} {1,-8} {2,-7}", item.variant + " " + item.name, count, $"£{cost}");

                if (item.name == "Bagel")
                {
                    float discounted = 3.99f;

                    while (count >= 12)
                    {
                        float discount = Math.Abs((item.cost*12)-discounted);

                        Console.WriteLine($"                 12 for 3.99:  -£{Math.Round(discount, 4)}");
                        cost -= discount;
                        count -= 12;
                    }

                    while (count >= 6)
                    {
                        float discount = Math.Abs((item.cost * 6) - discounted);

                        Console.WriteLine($"                  6 for 2.49:  -£{Math.Round(discount, 4)}");
                        cost -= discount;
                        count -= 6;
                    }
                }

                while (coffeeLeft.Count() > 0)
                    {
                        float discount = Math.Abs(1.25f - coffeeLeft.First().cost + item.cost);

                        Console.WriteLine($"     Coffee & Bagel for 1.25:  -£{Math.Round(discount, 4)}");
                        cost -= discount;
                        coffeeLeft.RemoveAt(0);
                    }

                totalCost += cost;
            }

            // Get cost of fillings
            foreach (Item item in items)
            {
                foreach (Item filling in item.GetFillings())
                    fillingCost += filling.cost;
            }

            Console.WriteLine("{0,-22} {1,-8} {2,-8}", "Fillings", "", $"£{Math.Round(fillingCost,3)}");

            totalCost += fillingCost;

            Console.WriteLine($"Total: £{Math.Round(totalCost, 4)}");

            return totalCost;
        }

        public Dictionary<Item, int> qty { get { return qty; } }
    }
}
