using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public static class Inventory
    {
        public static List<(string SKU, double Price, BagelType Variant)> bagels = new List<(string, double, BagelType)>
        {
            ("BGLO", 0.49, BagelType.Onion),
            ("BGLP", 0.39, BagelType.Plain),
            ("BGLE", 0.49, BagelType.Everything),
            ("BGLS", 0.49, BagelType.Sesame)

        };
        public static List<(string SKU, double Price, BagelFilling Filling)> fillings = new List<(string, double, BagelFilling)>
        {
            ("FILB", 0.12, BagelFilling.Bacon),
            ("FILE", 0.12, BagelFilling.Egg),
            ("FILC", 0.12, BagelFilling.Cheese),
            ("FILX", 0.12, BagelFilling.CreamCheese),
            ("FILS", 0.12, BagelFilling.SmokedSalmon),
            ("FILH", 0.12, BagelFilling.Ham)
        };

        public static List<(string SKU, double Price, CoffeeType Variant)> coffee = new List<(string, double, CoffeeType)>
        {
            ("COFB", 0.99, CoffeeType.Black),
            ("COFW", 1.19, CoffeeType.White),
            ("COFC", 1.29, CoffeeType.Cappuccino),
            ("COFL", 1.29, CoffeeType.Latte),
        };

        public static List<(string SKU, BagelType Variant, int specialAmount, double discountPrice)> BagelDiscountList = new List<(string SKU, BagelType Variant, int specialAmount, double discountPrice)>
        {
            ("BGLO", BagelType.Onion, 6, 2.49D),
            ("BGLP", BagelType.Plain, 12, 3.99D),
            ("BGLE", BagelType.Everything, 6, 2.49D)
        };

        public static List<(string SKU, CoffeeType Variant, int specialAmount, double discountPrice)> CoffeeDiscountList = new List<(string SKU, CoffeeType Variant, int specialAmount, double discountPrice)>
        {
            ("COFB", CoffeeType.Black, 1, 1.25D),
        };

        public static double CheckBagelPrice(Bagel bagel)
        {
            double sum = 0;

            sum += bagels.Where(x => x.Variant == bagel.mBagelType).ToList()[0].Price;
            if (bagel.mBagelFilling != BagelFilling.None)
                sum += fillings.Where(x => x.Filling == bagel.mBagelFilling).ToList()[0].Price;

            return sum;
        }

        public static double CheckFillingPrice(BagelFilling filling)
        {
            if (fillings.Any(x => x.Filling == filling))
                return fillings.Where(x => x.Filling == filling).ToList()[0].Price;
            return -1;
        }

        public static double GetFillingPrice(List<Bagel> bagelList)
        {
            double sum = 0;
            foreach (var bagel in bagelList)
            {
                if (bagel.mBagelFilling != BagelFilling.None)
                    sum += Inventory.fillings.Where(x => x.Filling == bagel.mBagelFilling).ToList()[0].Price;
            }

            return sum;
        }

        public static bool IsInInventory(BagelType bagelType)
        {
            return (bagels.Any(x => x.Variant == bagelType));
        }
        public static bool IsInInventory(BagelFilling item)
        {
            return (fillings.Any(x => x.Filling == item));
        }

        //public static bool IsInInventory(Coffee coffee)
        //{
        //    return (items.Any(x => x.Variant == item));
        //}

        //public static bool CheckBagelDiscount(List<Bagel> inBagels)
        //{
        //    foreach (var disc in BagelDiscountList)
        //    {
        //        if (inBagels.Where(x => x.mBagelType == disc.Variant).ToList().Count >= disc.specialAmount)
        //        {
        //            return true;

        //        }
        //    }
        //}
    }
}
