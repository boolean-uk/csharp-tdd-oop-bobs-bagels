using System.Collections.Generic;
using System.Linq;
using static exercise.main.BasketManager;
using static exercise.main.Inventory;

namespace exercise.main
{
    public class BasketManager
    {
        public class Product
        {
            public int ID { get; private set; }
            public InventoryItem Item { get; private set; }
            public List<InventoryItem> Fillings { get; private set; }

            public Product(InventoryItem variant)
            {
                ID = GetID();
                Item = variant;
                Fillings = new List<InventoryItem>();
            }

            public virtual double Cost()
            {
                return Item.Price;
            }
        }

        public class Bagel : Product
        {
            public Bagel(InventoryItem variant) : base(variant) { }

            public void AddFilling(InventoryItem filling)
            {
                Fillings?.Add(filling);
            }

            public override double Cost()
            {
                double fillingsCost = Fillings?.Sum(f => f.Price) ?? 0;
                return Item.Price + fillingsCost;
            }
        }

        public class Coffee : Product
        {
            public Coffee(InventoryItem variant) : base(variant) { }
        }

        private static int lastID = 0;
        private static int GetID()
        {
            lastID++;
            return lastID;
        }

        public class Order
        {
            public List<Product> Products { get; private set; }
            public int Capacity { get; private set; }

            public Order()
            {
                Products = new List<Product>();
                Capacity = 30;
            }

            public void ChangeCapacity(int capacity)
            {
                Capacity = capacity;
            }

            public void Add(Product product)
            {
                if (Products.Count >= Capacity)
                    throw new Exception("Product was not added to basket, because basket is full.");

                Products.Add(product);
            }

            public void Remove(Product product)
            {
                Products.Remove(product);
            }

            public double Cost()
            {
                OrderCostManager costManager = new OrderCostManager();
                return costManager.Cost(this);
            }
        }
    }
}
