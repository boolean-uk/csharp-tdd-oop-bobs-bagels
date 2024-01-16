using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class BobsBagels
    {
        private Dictionary<string, int> _stock;
        private int _capacity;
        private List<Basket> _baskets;

        public BobsBagels()
        {
            _stock = new Dictionary<string, int>() 
            {
                {"Onion", 100}, {"Plain", 100}, {"Everything", 100}, {"Sesame", 100}
            };

            _capacity = 10;
            _baskets = new List<Basket>();
        }

        public Dictionary<string, int> Stock { get => _stock; }
        public int Capacity { get => _capacity; set => _capacity = value; }
        public List<Basket> Baskets { get => _baskets; }

        public void AddBasket(Basket basket)
        {
            Baskets.Add(basket);
        }

        public void RemoveBasket(Basket basket)
        {
            if (Baskets.Contains(basket))
            {
                Baskets.Remove(basket);
            }
            else
            {
                throw new Exception("Basket does not exist");
            }
        }
    }
}