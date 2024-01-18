﻿using exercise.main.Foods;
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

        public Customer(Basket basket)
        {
            _basket = basket;
        }
        public Basket Basket { get { return _basket; } }
        public void Order(IFood food)
        {
            _basket.Add(food);
        }

        public void Order(IFood food, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Order(food);
            }
        }

        public bool Order(IFood food, List<string> availableSkus)
        {
            if(food is Bagel bagel)
            {
                if(bagel.Fillings.All(f => availableSkus.Contains(f.Sku)))
                {
                    _basket.Add(food);
                    return true;
                }
                return false;
            }
            else if (availableSkus.Contains(food.Sku))
            {
                _basket.Add(food);
                return true;
            }
            return false;
        }
    }
}
