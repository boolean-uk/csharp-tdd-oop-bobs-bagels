using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static exercise.main.Core;

namespace exercise.main
{
    public class Core
    {
        public class BagelVariant
        {
            public string Name { get; private set; }
            public double Price { get; private set; }

            public BagelVariant(string name, double price)
            {
                Name = name;
                Price = price;
            }

            public static BagelVariant Onion => new BagelVariant("Onion", 0.49);
            public static BagelVariant Plain => new BagelVariant("Plain", 0.39);
            public static BagelVariant Everything => new BagelVariant("Everything", 0.49);
            public static BagelVariant Sesame => new BagelVariant("Sesame", 0.49);
        }

        public class BagelFilling
        {
            public string Name { get; private set; }
            public double Price { get; private set; }

            public BagelFilling(string name, double price)
            {
                Name = name;
                Price = price;
            }

            public static BagelFilling Bacon => new BagelFilling("Bacon", 0.12);
            public static BagelFilling Egg => new BagelFilling("Egg", 0.12);
            public static BagelFilling Cheese => new BagelFilling("Cheese", 0.12);
            public static BagelFilling CreamCheese => new BagelFilling("Cream Cheese", 0.12);
            public static BagelFilling SmokedSalmon => new BagelFilling("Smoked Salmon", 0.12);
            public static BagelFilling Ham => new BagelFilling("Ham", 0.12);

            public static IEnumerable<BagelFilling> GetAll()
            {
                return typeof(BagelFilling)
                    .GetProperties(BindingFlags.Public | BindingFlags.Static)
                    .Where(p => p.PropertyType == typeof(BagelFilling))
                    .Select(p => (BagelFilling)p.GetValue(null));
            }
        }

        public class CoffeeVariant
        {
            public string Name { get; private set; }
            public double Price { get; private set; }

            public CoffeeVariant(string name, double price)
            {
                Name = name;
                Price = price;
            }

            public static CoffeeVariant Black => new CoffeeVariant("Black", 0.99);
            public static CoffeeVariant White => new CoffeeVariant("White", 1.19);
            public static CoffeeVariant Cappuccino => new CoffeeVariant("Cappuccino", 1.29);
            public static CoffeeVariant Latte => new CoffeeVariant("Latte", 1.29);
        }

        public class Bagel
        {
            public BagelVariant Variant { get; set; }
            public List<BagelFilling> Fillings { get; private set; }

            public Bagel(BagelVariant variant)
            {
                Variant = variant;
                Fillings = new List<BagelFilling>();
            }

            public double Cost()
            {
                return Variant.Price + Fillings.Sum(x => x.Price);
            }

            public void AddFilling(BagelFilling filling)
            { 
                Fillings.Add(filling); 
            }
        }

        public class Coffee
        {
            public CoffeeVariant Variant { get; set;}

            public Coffee(CoffeeVariant variant)
            {
                Variant = variant;
            }
        }

        public class Basket
        {
            public List<Bagel> Bagels { get; private set; }
            public List<Coffee> Coffees { get; private set;}
            public int Capacity { get; private set; }

            public Basket()
            {
                Bagels = new List<Bagel>();
                Coffees = new List<Coffee>();
            }

            public void ChangeCapacity(int capacity)
            {
                Capacity = capacity;
            }

            public void Add(Bagel bagel)
            {
                Bagels.Add(bagel);
            }
            public void Add(Coffee coffee)
            {
                Coffees.Add(coffee);
            }

            public void Remove(Bagel bagel)
            {
                Bagels.Remove(bagel);
            }
            public void Remove(Coffee coffee)
            {
                Coffees.Remove(coffee);
            }

            public double Cost()
            {
                return Bagels.Sum(bagel => bagel.Cost()) + Coffees.Sum(coffee => coffee.Variant.Price);
            }
        }
    }
}
