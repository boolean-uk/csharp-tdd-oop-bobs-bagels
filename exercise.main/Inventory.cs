using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tdd_bobs_bagels.Main;

namespace exercise.main
{
    public class Inventory
    {
        private int _capacity;
        private List<Basket> _baskets;

        public Inventory()
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
