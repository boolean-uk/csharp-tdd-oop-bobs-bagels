using System.Collections.Generic;
using System.Linq;
using static exercise.main.BasketManager;
using static exercise.main.Inventory;

namespace exercise.main
{
    public class BasketManager
    {
        private static int lastID = 0;
        private static int GetID()
        {
            lastID++;
            return lastID;
        }

        public class Bagel
        {
            public int ID {  get; private set; }
            public BagelVariant Variant { get; set; }
            public List<BagelFilling> Fillings { get; private set; }

            public Bagel(BagelVariant variant)
            {
                ID = GetID();
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
            public int ID { get; private set; }
            public CoffeeVariant Variant { get; set; }

            public Coffee(CoffeeVariant variant)
            {
                ID = GetID();
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
                Capacity = 6;
            }

            public void ChangeCapacity(int capacity)
            {
                Capacity = capacity;
            }

            public void Add(Bagel bagel)
            {
                if (Bagels.Count + Coffees.Count >= Capacity)
                    throw new Exception("Bagel was not added to basket, because basket is full.");

                Bagels.Add(bagel);
            }


            public void Add(Coffee coffee)
            {
                if (Bagels.Count + Coffees.Count >= Capacity)
                    throw new Exception("Coffee was not added to basket, because basket is full.");

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
