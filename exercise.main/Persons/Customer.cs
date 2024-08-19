using exercise.main.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Persons
{
    public class Customer
    {
        private Basket _basket;
        public Basket Basket { get => _basket; }
        public Customer() 
        { 
            _basket = new Basket(); 
        }
        public bool AddItemToBasket(Item item)
        {
            if (_basket.Capacity <= 0)
            {
                return false;
            } else
            {
                _basket.Add(item);
                return true;
            }
        }

        public bool RemoveItemFromBasket(Item bagel)
        {
            _basket.Remove(bagel);
            return true;
        }
    }
}
