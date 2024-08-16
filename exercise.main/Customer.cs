using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Customer : Person
    {
        private List<Product> basket;

        public Customer(string name) : base(name)
        {
            this.basket = new List<Product>();
        }

        public bool addItemToBascet(productType p)
        {
            if (basket.Count >= Core.basketMaxSize)
            {
                return false;
            }
            else 
            {
                basket.Add(new Product(p));
                return true;
            }
        }

        public bool removeItemFromBasket(productType p) {
            if (basket.Contains(new Product(p))) 
            {
                basket.Remove(new Product(p));
                return true;
            } 
            else 
            { 
                return false;  
            }
        }

        public List<Product> GetBasket() { return basket; }


    }
}
