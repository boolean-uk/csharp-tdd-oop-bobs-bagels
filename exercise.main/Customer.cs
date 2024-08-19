using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Customer
    {
        Basket basket = new Basket();
        Inventory inventory = new Inventory();
        double funds = 0;
        public Customer(double funds)
        {
            this.funds = funds;
        }


        public bool AddToBasket(string name, string variant, double remainingFunds)
        {
            throw new NotImplementedException();
        }
        public bool AddToBasket(string name, string variant, double remainingFunds, string filling)
        {
            throw new NotImplementedException();
        }

        public void ViewMenu()
        {
            foreach (var item in inventory.stock)
            {
                Console.WriteLine(item.Value.name + " " + item.Value.variant
                    + " " + item.Value.price);
            }
        }
    }
}
