using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Store
    {
        private static List<Tuple<string, double, string, string>> _skuList;
        public static List<Tuple<string, double, string, string>> SkuList { get { return _skuList; } set { _skuList = value; } }

        static Store()
        {
            //Weakness: no quantity and not mutable. But I decided I won't implement that unless I have to.
            SkuList = new List<Tuple<string, double, string, string>>
            {
                new Tuple<string, double, string, string>("BGLO", 0.49,  "Bagel",   "Onion"         ),
                new Tuple<string, double, string, string>("BGLP", 0.39,  "Bagel",   "Plain"         ),
                new Tuple<string, double, string, string>("BGLE", 0.49,  "Bagel",   "Everything"    ),
                new Tuple<string, double, string, string>("BGLS", 0.49,  "Bagel",   "Sesame"        ),
                new Tuple<string, double, string, string>("COFB", 0.99,  "Coffee",  "Black"         ),
                new Tuple<string, double, string, string>("COFW", 1.19,  "Coffee",  "White"         ),
                new Tuple<string, double, string, string>("COFC", 1.29,  "Coffee",  "Capuccino"     ),
                new Tuple<string, double, string, string>("COFL", 1.29,  "Coffee",  "Latte"         ),
                new Tuple<string, double, string, string>("FILB", 0.12,  "Filling", "Bacon"         ),
                new Tuple<string, double, string, string>("FILE", 0.12,  "Filling", "Egg"           ),
                new Tuple<string, double, string, string>("FILC", 0.12,  "Filling", "Cheese"        ),
                new Tuple<string, double, string, string>("FILX", 0.12,  "Filling", "Cream Cheese"  ),
                new Tuple<string, double, string, string>("FILS", 0.12,  "Filling", "Smoked Salmon" ),
                new Tuple<string, double, string, string>("FILH", 0.12,  "Filling", "Ham"           )

            };
        }
        public Store()
        {

        }

        public static Tuple<string, double, string, string> getSkuInfo(string sku)
        {
            sku = sku.ToUpper();

            return SkuList.FirstOrDefault(t => t.Item1 == sku);
        }

        public static bool IsProductInInventory(string sKU)
        {
            bool isThere = false;
            foreach (Tuple<string, double, string, string> sku in SkuList)
            {
                if (sku.Item1 == sKU)
                {
                    isThere = true;
                    break;
                }
            }
            return isThere;
        }

        public static bool ChangeBasketSize(bool isManager, int newCapacity)
        {
            if (isManager && newCapacity > 0)
            {
                Basket.BasketCapacity = newCapacity;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
