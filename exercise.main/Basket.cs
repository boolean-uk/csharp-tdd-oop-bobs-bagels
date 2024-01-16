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



        public List<Item> BasketItems { get { return _basketItems; }set { _basketItems = value; } } 
        public int Capacity { get { return _capacity; } set { _capacity = value; } }


        Inventory inventory = new Inventory();

        public void AddItem(string Sku)
        {
            foreach (var itemInv in inventory.InventoryItems)
            {
                if (itemInv.Sku == Sku)
                {
                    BasketItems.Add(itemInv);
                }
            }

        }

        public bool RemoveBagel(string Sku)
        {
            bool result = false;

            foreach (var item in BasketItems)
            {
                if (item.Sku == Sku)
                {
                    BasketItems.Remove(item);
                }
            }


            return result;
        }

        public bool IsBasketFull()
        {
            if(BasketItems.Count >= Capacity)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public void ChangeBasketCapacity(int newCapacity)
        {
            if (BasketItems.Count <= Capacity)
            {
                Capacity = newCapacity;
            }

        }

        public double TotalCostBasket()
        {
            double result = 0d;
            foreach(var item in BasketItems)
            {
                result += item.Price;
            }
            return Math.Round(result, 2);
        }

        public double CostOfFilling()
        {
            throw new NotImplementedException();
        }

        public double CostOfBagel()
        {
            throw new NotImplementedException();
        }



    }
}
