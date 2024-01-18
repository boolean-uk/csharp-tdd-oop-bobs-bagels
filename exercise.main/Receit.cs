using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace exercise.main
{
    public class Receit
    {
        
        private Dictionary<string, float> bundle = new Dictionary<string, float> { ["6"] = 2.49F, ["12"] = 3.99F, ["2"] = 1.25F };
        string date = DateTime.Now.Date.ToString().Split(" ")[0];
        string time = DateTime.Now.TimeOfDay.ToString().Split(".")[0];

        public void PrintReceit(float totalprice, List<Item> _basket)
        {

            List<float> savedAmount = new List<float>();

            Console.WriteLine("     ~~~ Bob's Bagels ~~~");
            Console.WriteLine("");
            Console.WriteLine($"      {date} {time}");
            Console.WriteLine("");
            Console.WriteLine("------------------------------");

            List<string> skuUnique = _basket.Select(x => x.SKU).Distinct().ToList();
            List<Item> bundleSkip = new List<Item>();


            foreach (Item item in _basket)
            {
                if (bundleSkip.Contains(item))
                {
                    continue;
                }

                string itemName = $"{item.Variant} {item.Name}";

                int countItems = (item.isInBundle()) ? item.ListBundleIds().Count() : _basket.Where(x => !x.isInBundle()).Count(x => x.SKU == item.SKU);  // how many identical items in basket 

                // for receipt string formatting
                string res = $"{item.Variant} {item.Name}";
                int spt = (countItems > 9) ? 21 : 22;
                int spacing = spt - res.Length;

                float itemPrice = item.Price * countItems;
                string savedPrice = "";

                // this item is in one of the bundle types
                if (item.isInBundle())
                {
                    List<string> bundleIDS = item.ListBundleIds();

                    bundleSkip.AddRange(_basket.Where(x => bundleIDS.Contains(x.ID)).ToList());

                    string countIt = $"{item.ListBundleIds().Count()}";
                    float res2 = Math.Abs(itemPrice - bundle[countIt]);  // discount amount

                    savedAmount.Add(res2);

                    savedPrice = $"{res2:0.00}";
                    itemPrice = bundle[$"{countIt}"];

                    if (item.ListBundleIds().Count() == 2)
                    {
                        itemName = "Bagel & Coffee";
                        spacing = 8;
                    }

                    countItems = item.ListBundleIds().Count();

                }

                string spaces = new String(' ', spacing);

                Console.WriteLine($"{itemName}{spaces}{countItems}  £{itemPrice}");

                if (savedPrice.Length > 1)
                {

                    Console.WriteLine($"                      (-£{savedPrice})");
                }

            }

            string totalResult = $"{totalprice:0.00}";

            Console.WriteLine("------------------------------");
            Console.WriteLine($"Total                    £{totalResult}");
            Console.WriteLine("");
            Console.WriteLine($"   You saved a total of £{savedAmount.Sum():0.00}");
            Console.WriteLine("         on this shop");
            Console.WriteLine(" ");
            Console.WriteLine("           Thank you");
            Console.WriteLine("        for your order!");

        }

    }

}
