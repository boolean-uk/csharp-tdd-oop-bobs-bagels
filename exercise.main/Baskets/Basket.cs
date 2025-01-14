using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Products;

namespace exercise.main.Baskets
{
    public class Basket : IBasket
    {
        public int Capacity { get; set; }

        public List<Product> BasketItems { get; private set; }

        public Basket(int capacity)
        {
            BasketItems = new List<Product>();
            Capacity = capacity;
        }

        public void AddItem(Product p)
        {
            if (BasketItems.Count < Capacity) {
                BasketItems.Add(p);
                return;
            }

            throw new BasketCapacityReachedException();
        }

        public bool Contains(Product p)
        {
            return BasketItems.Contains(p);
        }

        public double GetTotalCost()
        {

            return BasketItems.Select(p => p.Price).Sum();
        }

        public bool IsFull()
        {
            return BasketItems.Count >= Capacity;
        }

        public void RemoveItem(Product p)
        {
            if (Contains(p)) {
                BasketItems.Remove(p);
                return;
            }

            throw new ItemNotInBasketException();
        }

        public void SetCapacity(int newCapacity)
        {
            int nItemsToRemove = BasketItems.Count - newCapacity;

            if (nItemsToRemove > BasketItems.Count)
            {
                BasketItems.Clear();
            }
            else if (nItemsToRemove > 0)
            {
                BasketItems.RemoveRange(BasketItems.Count - nItemsToRemove, nItemsToRemove);
            }

            Capacity = newCapacity;
        }

        public bool checkForBagelDiscount()
        {
            return (BasketItems.Where(product => product.Name.Equals("Bagel")).Count() % 6 == 0);
        }

        public bool checkForBagelAndCoffeeDiscount()
        {
            return (BasketItems.Where(product => product.Name.Equals("Bagel")).Count() > 0
                && BasketItems.Where(product => product.Name.Equals("Coffee")).Count() > 0);
        }
    }
}
