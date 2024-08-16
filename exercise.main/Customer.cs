using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Customer
    {
        public Basket basket;
        public float wallet { get; set; }
        public Customer(Manager manager, float allowance)
        {
            this.basket = new Basket(manager);
            this.wallet = allowance;
        }

        public bool Add(Manager manager, string product)
        {
            if (manager.AddProduct(this.basket, product))
            {
                return true;
            }
            return false;
        }

        public bool Remove(Manager manager, string product)
        {
            if(manager.RemoveProduct(this.basket, product))
            {
                return true;
            }
            return false;
        }
    }
}
