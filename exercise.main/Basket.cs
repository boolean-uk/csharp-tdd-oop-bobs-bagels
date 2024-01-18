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

        public double Cost(bool skipDiscount = false)
        {
            double fullPrice = Products.Sum(p => p.Cost());
            double discountedPrice = fullPrice;

            if (skipDiscount) return fullPrice;

            List<Coffee?> coffees = Products.Where(p => p.Coffee != null).Select(p => p.Coffee).ToList();
            coffees = coffees.OrderByDescending(c => c.Price).ToList();

            foreach (BagelVariant bagelVariant in Enum.GetValues(typeof(BagelVariant)))
            {
                int count = Products.Where(p => p.Bagel != null && p.Bagel.Variant.Equals(bagelVariant)).Count();
                Product product = Products.First(p => p.Bagel != null);
                double price = product != null && product.Bagel != null ? product.Bagel.Price : 0;


                if (count >= 12)
                {
                    int amt = count / 12;
                    count -= amt * 12;

                    discountedPrice += 3.99d * amt;
                    discountedPrice -= amt * 12 * price;
                }

                if (count >= 6)
                {
                    int amt = count / 6;
                    count -= amt * 6;

                    discountedPrice += 2.49d * amt;
                    discountedPrice -= amt * 6 * price;
                }

                while (coffees.Count > 0 && count > 0)
                {
                    Coffee coffee = coffees.First();
                    coffees.Remove(coffee);

                    discountedPrice += 1.25d;
                    discountedPrice -= price;
                    discountedPrice -= coffee.Price;
                }
            }
            return discountedPrice;
        }

        public string GetReceipt() { return new Receipt(Products).GetReceipt(); }
    }
}






