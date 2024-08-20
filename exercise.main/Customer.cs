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
        Manager manager = new Manager();
        double funds = 0;
        public Customer(double funds)
        {
            this.funds = funds;
            if(funds == 2222.0)
            {
                manager.ChangeCapcity(200); // this is for extension tests
            }
        }


        public bool AddToBasket(string name, string variant)
        {
            if(manager.ConfirmOrder(name, variant, funds - basket.ShowCost(), basket.GetSize()))
            {
                //manager says yes
                // funds OK! Capcity OK! Item exists OK!
                Basket.BasketItem basketItem = new Basket.BasketItem(inventory.GetCode(name, variant));
                basket.Add(basketItem);
                return true;
            }
            return false;
        }
        public bool AddToBasket(string name, string variant, string filling)
        {
            if (manager.ConfirmOrder(name, variant, funds - basket.ShowCost(), basket.GetSize()))
            {
                //manager says yes
                // funds OK! Capcity OK! Item exists OK!

                //now we check filling 
                if (manager.ConfirmOrder("Filling", filling, funds - basket.ShowCost(), basket.GetSize()) && (name == "Bagel"))
                {
                    Basket.BasketItem basketItem = new Basket.BasketItem(inventory.GetCode(name, variant), inventory.GetCode("Filling", filling));
                    basket.Add(basketItem);
                    return true;
                }
            }
            return false;
        }

        public bool Purchase()
        {
            throw new NotImplementedException();
        }

        public bool RemoveItem(string name, string variant)
        {
            return basket.RemoveFromBasket(name, variant); 
        }

        public double ShowCost()
        {
            return basket.ShowCost(); 
        }

        public void ViewMenu()
        {
            Console.WriteLine("SKU\tName\tVariant\tPrice\tSpecial offers");
            foreach (var item in inventory.stock)
            {
                string printLine = item.Value.name + " " + item.Value.variant
                    + " " + item.Value.price;
                if(item.Value.name == "Bagel")
                {
                    printLine += " 6 for 2.49 / 12 for 3.99";
                }
                else if (item.Value.name == "Coffee")
                {
                    printLine += " Coffee & Bagel for 1.25";
                }
                Console.WriteLine(printLine);
            }
        }
    }
}
