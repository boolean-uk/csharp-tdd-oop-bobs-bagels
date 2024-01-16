using exercise.main.items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public List<Product> Products {  get; set; } = new List<Product>();
        private int _capacity = 3;
        public int Capacity { get { return _capacity; } set { _capacity = value >= 0 ? value : 0; } }

        public bool Add(Bagel bagel)
        {
            if (Products.Count + 1 <= Capacity)
            {
                Product bagelProduct = new Product(bagel);
                Products.Add(bagelProduct);
                return true;
            }
            return false;
        }

        public bool Add(Coffee coffee)
        {
            if (Products.Count + 1 <= Capacity)
            {
                Product coffeeProduct = new Product(coffee);
                Products.Add(coffeeProduct);
                return true;
            }
            return false;
        }

        public bool Remove(Bagel bagel)
        {
            if (Products.Count - 1 >= 0 && Products.Any(p => p.Bagel != null && p.Bagel.Equals(bagel)))
            {
                int index = Products.FindIndex(p => p.Bagel != null && p.Bagel.Equals(bagel)); 
                Products.RemoveAt(index);
                return true;
            }

            return false;
        }

        public bool Remove(Coffee coffee)
        {
            if (Products.Count - 1 >= 0 && Products.Any(p => p.Coffee != null && p.Coffee.Equals(coffee)))
            {
                int index = Products.FindIndex(p => p.Coffee != null && p.Coffee.Equals(coffee));
                Products.RemoveAt(index);
                return true;
            }

            return false;
        }

        public double Cost()
        {
            return Products.Sum(p => p.Cost());
        }
    }
}






