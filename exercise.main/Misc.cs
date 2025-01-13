using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Items;

namespace exercise.main
{
    public static class Misc
    {
        public static void BagelDiscount(Dictionary<string, Pair<Item, int>> items, List<Tuple<Item, int, float>> priceLog, int count, float price)
        {
            foreach (var row in items.Where(row => row.Key.Contains("BGL") && row.Value.Right >= count))
            {
                priceLog.Add(new(row.Value.Left, count, price));
                row.Value.Right -= count;
                if (row.Value.Right <= 0)
                {
                    items.Remove(row.Key);
                } 
            }
        }

        public static void CoffeeAndBagle(Dictionary<string, Pair<Item, int>> items, List<Tuple<Item, int, float>> priceLog, float price)
        {
            var coffeeRows = items.Where(row => row.Key.Contains("COF")).ToList();
            var bagelRows = items.Where(row => row.Key.Contains("BGL")).ToList();

            for (int i = 0; i < Math.Min(coffeeRows.Count(), bagelRows.Count()); i++)
            {
                var coffee = coffeeRows[i];
                var bagel = bagelRows[i];
            }

        }
    }
}
