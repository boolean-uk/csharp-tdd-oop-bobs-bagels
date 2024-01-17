using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<Item> _basketItems = new List<Item>();
        private int _capacity;

        public Basket(List<Item> basketItems, int capacity)
        {
            _basketItems = basketItems;
            _capacity = capacity;
        }

        public Basket(int capacity)
        {
            _capacity = capacity;
        }

        public Basket()
        {

        }

        public List<Item> BasketItems { get { return _basketItems; } set { _basketItems = value; } } 
        public int Capacity { get { return _capacity; } set { _capacity = value; } }


        Inventory inventory = new Inventory();

        public void AddItem(string Sku)
        {        
            foreach (var itemInv in inventory.InventoryItems)
            {
                if (itemInv.Sku == Sku)
                {
                    Console.WriteLine($"Item: {itemInv.Name} {itemInv.Variant} has been added to basket");
                    BasketItems.Add(itemInv);                
                }
            }
        }

        public bool RemoveBagel(string Sku)
        {
            bool result = true;
            Item item = BasketItems.Where(x => x.Sku == Sku).First();
            if(item == null)
            {
                return false;
            }
            BasketItems.Remove(item);
            Console.WriteLine($"Item: {item.Name} {item.Variant} has been removed from basket");
            return result;
        }

        public bool IsBasketFull()
        {
            if(BasketItems.Count >= Capacity)
            {
                Console.WriteLine("Basket is full");
                return true;
            } else
            {
                Console.WriteLine("Basket is not full");
                return false;
            }
        }

        public void ChangeBasketCapacity(int newCapacity)
        {
            if (BasketItems.Count <= Capacity)
            {
                Capacity = newCapacity;
                Console.WriteLine("Capacity of basket has been changed");
            }

        }

        public double TotalCostBasket()
        {
            double result = 0d;
            foreach(var item in BasketItems)
            {
                result += item.Price;
            }
            Console.WriteLine("The total cost of basket is: " + Math.Round(result, 2));
            return Math.Round(result, 2);
        }
    }
}
