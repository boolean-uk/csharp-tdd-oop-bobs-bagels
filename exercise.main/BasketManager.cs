using System.Collections.Generic;
using System.Linq;
using static exercise.main.Inventory;

namespace exercise.main
{
    public class BasketManager
    {
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
                return Variant.Price + Fillings.Sum(f => f.Price);
            }

            public void AddFilling(BagelFilling filling)
            {
                Fillings.Add(filling);
            }
        }

        public class Coffee
        {
            public CoffeeVariant Variant { get; set; }

            public Coffee(CoffeeVariant variant)
            {
                Variant = variant;
            }
        }

        public class Order
        {
            public List<Bagel> Bagels { get; private set; }
            public List<Coffee> Coffees { get; private set; }
            public int Capacity { get; private set; }

            public Order()
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
                return Bagels.Sum(b => b.Cost()) + Coffees.Sum(c => c.Variant.Price);
            }
        }
    }
}
