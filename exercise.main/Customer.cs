using exercise.main.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Customer
    {
        private readonly Basket _basket;

        public Customer()
        {
            _basket = new Basket();
        }
        public Basket Basket { get { return _basket; } }
        public void Order(IFood food)
        {
            _basket.Add(food);
        }

        public bool Order(IFood food, List<string> availableSkus)
        {
            if(food is Bagel)
            {
                Bagel bagel = (Bagel)food;
                if (availableSkus.Contains(bagel.Filling.Sku) && availableSkus.Contains(bagel.Sku))
                {
                    _basket.Add(food);
                    return true;
                } else
                {
                    return false;
                }
            }
            if (availableSkus.Contains(food.Sku))
            {
                _basket.Add(food);
                return true;
            }
            return false;
        }
    }
}
