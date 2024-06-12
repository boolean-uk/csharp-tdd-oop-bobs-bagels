using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class BobsBagels
    {
        private int _capacity;
        private List<Basket> _baskets;

        public BobsBagels()
        {
            _capacity = 10;
            _baskets = new List<Basket>();
        }

        public int Capacity { get => _capacity; set => _capacity = value; }
        public List<Basket> Baskets { get => _baskets; }

        public void AddBasket(Basket basket)
        {
            Baskets.Add(basket);
        }

        public void RemoveBasket(Basket basket)
        {
            if (!Baskets.Contains(basket)) { throw new Exception("Basket does not exist"); }

            Baskets.Remove(basket);
        }

        public void IncreaseCapacity(int capacity)
        {
            Capacity += capacity;

            foreach (Basket basket in Baskets)
            {
                basket.Capacity = Capacity;
            }
        }
    }
}