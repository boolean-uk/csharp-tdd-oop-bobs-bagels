using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<Product> _products = [];
        private int _basketSize;
        private float _total;

        public Basket(int basketSize)
        {
            _basketSize = basketSize;
        }

        public void AddToBasket(Product product)
        {
            if(ConfirmAdd(product))
            {
                if (BasketSize == 0)
                {
                    throw new ArgumentException("No more room in basket");
                }
                Products.Add(product);
                BasketSize -= 1;
                Total += product.Price;
            }
            
        }

        public void RemoveFromBasket(Product product)
        {
            if (!Products.Exists(p => p.Equals(product)))
            {
                throw new ArgumentException("No bagel here matches that request");
            }
            Products.Remove(product);
            BasketSize += 1;
            Total -= product.Price;
        }

        public void ExpandBasket(int expansion)
        {
            BasketSize += expansion;
        }

        public string DisplayTotal()
        {
            return $"The total of your basket is {Total}";
        }

        public bool ConfirmAdd(Product product)
        {
            Console.WriteLine($"The price of the product is {product.Price}, would you like to add to basket? y/n");
            string answer = Console.ReadLine();
            if (answer == "y")
            {
                return true;
            }
            Console.WriteLine("Hope you find something else you'd like");
            return false;
        }


        public List<Product> Products { get { return _products; } set { _products = value; } }
        public int BasketSize { get { return _basketSize; } set { _basketSize = value; } }

        public float Total { get { return _total; } set { _total = value; } }
    }
}
