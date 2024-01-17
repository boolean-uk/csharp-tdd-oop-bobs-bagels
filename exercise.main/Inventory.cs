using System.Collections.Generic;

namespace exercise.main
{
    public class Inventory
    {
        public interface IInventoryItem
        {
            string SKU { get; }
            string Name { get; }
            double Price { get; }
        }

        public class BagelVariant : IInventoryItem
        {
            public string SKU { get; private set; }
            public string Name { get; private set; }
            public double Price { get; private set; }

            public BagelVariant(string sku, string name, double price)
            {
                SKU = sku;
                Name = name;
                Price = price;
            }

            public static readonly IEnumerable<BagelVariant> AllVariants = new List<BagelVariant>
            {
                new BagelVariant("BGLO", "Onion", 0.49),
                new BagelVariant("BGLP", "Plain", 0.39),
                new BagelVariant("BGLE", "Everything", 0.49),
                new BagelVariant("BGLS", "Sesame", 0.49)
            };
        }

        public class BagelFilling : IInventoryItem
        {
            public string SKU { get; private set; }
            public string Name { get; private set; }
            public double Price { get; private set; }

            public BagelFilling(string sku, string name, double price)
            {
                SKU = sku;
                Name = name;
                Price = price;
            }

            public static readonly IEnumerable<BagelFilling> AllFillings = new List<BagelFilling>
        {
            new BagelFilling("FILB", "Bacon", 0.12),
            new BagelFilling("FILE", "Egg", 0.12),
            new BagelFilling("FILC", "Cheese", 0.12),
            new BagelFilling("FILX", "Cream Cheese", 0.12),
            new BagelFilling("FILS", "Smoked Salmon", 0.12),
            new BagelFilling("FILH", "Ham", 0.12)
        };
        }

        public class CoffeeVariant : IInventoryItem
        {
            public string SKU { get; private set; }
            public string Name { get; private set; }
            public double Price { get; private set; }

            public CoffeeVariant(string sku, string name, double price)
            {
                SKU = sku;
                Name = name;
                Price = price;
            }

            public static readonly IEnumerable<CoffeeVariant> AllVariants = new List<CoffeeVariant>
        {
            new CoffeeVariant("COFB", "Black", 0.99),
            new CoffeeVariant("COFW", "White", 1.19),
            new CoffeeVariant("COFC", "Cappuccino", 1.29),
            new CoffeeVariant("COFL", "Latte", 1.29)
        };
        }
    }
}