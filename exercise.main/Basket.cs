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

        public Basket(int basketSize)
        {
            _basketSize = basketSize;
        }

        public void AddToBasket(Product product)
        {
            if (BasketSize == 0)
            {
                throw new ArgumentException("No more room in basket");
            }
            Products.Add(product);
            BasketSize -= 1;
        }

        public void RemoveFromBasket(Product product)
        {
            if (!Products.Exists(p => p.Equals(product)))
            {
                throw new ArgumentException("No bagel here matches that request");
            }
            Products.Remove(product);
            BasketSize += 1;
        }

        public void ExpandBasket(int expansion)
        {
            BasketSize += expansion;
        }

        public List<Product> Products { get { return _products; } set { _products = value; } }
        public int BasketSize { get { return _basketSize; } set { _basketSize = value; } }
    }
}
