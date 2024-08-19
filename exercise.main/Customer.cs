using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Customer
    {
        public Basket basket; //Basket containing all products the customer wants to buy
        public float wallet { get; set; } //Money that the customer can spend
        public Customer(Manager manager, float allowance)
        {
            this.basket = new Basket(manager);
            this.wallet = allowance;
        }

        public bool Add(Manager manager, string product)
        {
            //Ask the manager to add a product to our basket
            if (manager.AddProduct(this.basket, product))
            {
                return true;
            }
            return false;
        }

        public bool Remove(Manager manager, string product)
        {
            //Ask the manager to remove a product from our basket
            if(manager.RemoveProduct(this.basket, product))
            {
                return true;
            }
            return false;
        }

        public float TotalCost()
        {
            //Check the basket for the total cost
            return basket.TotalCost();
        }

        public float HowMuch(Manager manager, string product)
        {
            //Ask the manager how much it costs
            return manager.HowMuchProduct(product);
        }

        public bool AddFilling(Manager manager, string filling, string product)
        {
            //Ask the manager to add the filling
            if(manager.AddFilling(this.basket, filling, product))
            {
                return true;
            }
            return false;
        }

        public float HowMuchFillings(Manager manager)
        {
            //Ask the manager how much all fillings cost
            return manager.HowMuchFillings();
        }
    }
}
